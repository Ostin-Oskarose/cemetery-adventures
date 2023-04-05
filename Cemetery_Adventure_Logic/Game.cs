using System.Runtime.InteropServices;
using Cemetery_Adventure_Logic.Entity;
using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.GameBoard;

namespace Cemetery_Adventure_Logic
{
    public class Game
    {
        private const int Width = 30;
        private const int Height = 30;
        private const int MessageBufferSize = 5;
        public Player Player;
        public int Floor;
        private DateTime LastEnemyUpdate = DateTime.Now;
        public bool PlayerIsAlive => Player.IsAlive;

        public Board GameBoard { get; set; }
        public MessageBuffer MessageBuffer { get; private set; }

        public Game(string playerName)
        {
            Player = new Player(playerName, (1, 1), 20, 5, 0);
            Floor = 1;
            GameBoard = new Board(Height, Width, Player, Floor);
            MessageBuffer = new MessageBuffer(MessageBufferSize);
        }

        public Game(Player player, int floor)
        {
            Player = player;
            Floor = floor;
            GameBoard = new Board(Height, Width, Player, Floor);
            MessageBuffer = new MessageBuffer(MessageBufferSize);
        }

        public void Update()
        {//TODO Monsters can kill each other
            PlayerTurn();
            if (DateTime.Now - LastEnemyUpdate > TimeSpan.FromSeconds(0.5))
            {
                EnemiesTurn();
                LastEnemyUpdate = DateTime.Now;
            }
            RemoveDeadEnemies();
        }

        public void PlayerTurn()
        {
            CharacterTurn(Player);
        }

        public void EnemiesTurn()
        {
            foreach (var enemy in GameBoard.EnemyList)
            {
                enemy.SearchForPlayer(Player);
                CharacterTurn(enemy);
            }
        }

        public CollisionType GetCollisionType((int X, int Y) position)
        {
            switch (GameBoard.BoardArray[position.Y, position.X])
            {
                case Character:
                    return CollisionType.Character;
                case Obstacle:
                    return CollisionType.Obstacle;
                case FloorItem:
                    return CollisionType.Item;
                default:
                    throw new ArgumentException();
            }
        }

        public void CharacterTurn(Character character)
        {
            var move = character.GetMove();
            if (GameBoard.ValidateMoveWithinBounds(move))
            {
                if (GameBoard.IsOccupied(move))
                {
                    switch (GetCollisionType(move))
                    {
                        case CollisionType.Character:
                            ResolveCharacterCollision(character, move);
                            return;
                        case CollisionType.Obstacle:
                            var obstacle = GameBoard.BoardArray[move.Y, move.X];
                            if (obstacle is Stairs stairs && character is Player && Player.CheckForKey())
                            {
                                CreateNewBoard(stairs, character);
                            }
                            return;

                        case CollisionType.Item:
                            if (character != Player) return;

                            var item = ((FloorItem)GameBoard.BoardArray[move.Y, move.X]).Item;

                            MessageBuffer.Add($"You found a {item.Name}");

                            if (Player.SameTypeItem(item))
                            {
                                var worstItem = Player.WorstItem(item);
                                if (worstItem == item) break;
                                Player.RemoveItemFromInventory(worstItem.Name);
                            }

                            MessageBuffer.Add($"You equip the {item.Name}");
                            Player.AddItemToInventory(item);
                            Player.UpdateStatistics(item);
                            break;
                    }
                }

                GameBoard.MoveEntity(character.Position, move);
                character.Move(move.X, move.Y);
            }
        }

        private void ResolveCharacterCollision(Character character, (int X, int Y) move)
        {
            var target = GameBoard.BoardArray[move.Y, move.X] as Character;
            if (target != character)
            {
                var damage = character.Attack(target);
                MessageBuffer.Add($"{character.Name} attacks {target.Name} for {damage} damage");
            }
        }

        public void RemoveDeadEnemies()
        {
            foreach (var enemy in GameBoard.EnemyList)
            {
                if (!enemy.IsAlive)
                {
                    foreach (var item in enemy.GetInventory())
                    {
                        if (item.Name == "Key")
                        {
                            MessageBuffer.Add("You found a key");
                            Player.AddItemToInventory(item);
                        }
                        else
                        {
                            GameBoard.BoardArray[enemy.Position.Y, enemy.Position.X] =
                                new FloorItem(item, enemy.Position);
                        }
                    }

                    if (GameBoard.BoardArray[enemy.Position.Y, enemy.Position.X] == enemy)
                    {
                        GameBoard.RemoveEntity(enemy.Position);
                    }

                    MessageBuffer.Add($"{enemy.Name} died");
                }
            }

            GameBoard.EnemyList.RemoveAll(enemy => !enemy.IsAlive);
        }

        private void CreateNewBoard(Stairs stairs, Character character)
        {
            Random random = new Random();
            int height = random.Next((Height / 2), Height);
            int width = random.Next((Width / 2), Width);

            Floor = stairs.LevelNumber + 1;
            character.Move(1, 1);
            GameBoard = new Board(height, width, Player, Floor);
            Player.RemoveItemFromInventory("Key");
            MessageBuffer.Add("You use the key");
            Console.Clear();//TODO get method from Output.cs
        }
    }
}