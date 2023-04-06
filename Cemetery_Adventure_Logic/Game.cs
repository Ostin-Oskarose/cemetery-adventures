using Cemetery_Adventure_Logic.Entity;
using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.Entity.Character.Enemy;
using Cemetery_Adventure_Logic.GameBoard;

namespace Cemetery_Adventure_Logic
{
    public class Game
    {
        private const int InitialBoardWidth = 30;
        private const int InitialBoardHeight = 30;
        private const int MessageBufferSize = 5;
        public Player Player;
        public int Floor;
        private readonly CollisionHandler _collisionHandler = new CollisionHandler();
        private DateTime LastEnemyUpdate = DateTime.Now;
        public bool PlayerIsAlive => Player.IsAlive;
        public bool NewLevel { get; private set; }
        public Board GameBoard { get; set; }
        public MessageBuffer MessageBuffer { get; private set; }

        public Game(string playerName)
        {
            Player = new Player(playerName, (1, 1), 20, 5, 0);
            Floor = 1;
            GameBoard = new Board(InitialBoardHeight, InitialBoardWidth, Player, Floor);
            MessageBuffer = new MessageBuffer(MessageBufferSize);
        }

        public Game(Player player, int floor)
        {
            Player = player;
            Floor = floor;
            GameBoard = new Board(InitialBoardHeight, InitialBoardWidth, Player, Floor);
            MessageBuffer = new MessageBuffer(MessageBufferSize);
        }

        public void Update()
        {
            NewLevel = false;
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

        public void CharacterTurn(Character character)
        {
            var move = character.GetMove();
            if (!GameBoard.ValidateMoveWithinBounds(move)) return;
            if (!GameBoard.IsOccupied(move))
            {
                GameBoard.MoveEntity(character.Position, move);
                character.Move(move.X, move.Y);
            }
            else
            {
                switch (_collisionHandler.GetCollisionType(move, GameBoard))
                {
                    case CollisionType.Character:
                        _collisionHandler.ResolveCharacterCollision(character, move, GameBoard, MessageBuffer);
                        return;
                    case CollisionType.Obstacle:
                        _collisionHandler.ResolveObstacleCollision(character, move, this, GameBoard);
                        break;
                    case CollisionType.Item:
                        _collisionHandler.ResolveItemCollision(character, Player, move, GameBoard, MessageBuffer);
                        break;
                }
            }
        }

        public void RemoveDeadEnemies()
        {
            foreach (var enemy in GameBoard.EnemyList.Where(enemy => !enemy.IsAlive))
            {
                GameBoard.RemoveEntity(enemy.Position);
                DropItemsOrGiveKey(enemy);
                MessageBuffer.Add($"{enemy.Name} died");
            }
            GameBoard.EnemyList.RemoveAll(enemy => !enemy.IsAlive);
        }

        private void DropItemsOrGiveKey(Enemy enemy)
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
        }

        public void NextFloor(Stairs stairs, Character character)
        {
            var random = new Random();
            var height = random.Next((InitialBoardHeight / 2), InitialBoardHeight);
            var width = random.Next((InitialBoardWidth / 2), InitialBoardWidth);

            Floor = stairs.LevelNumber + 1;
            character.Move(1, 1);
            GameBoard = new Board(height, width, Player, Floor);
            Player.RemoveItemFromInventory("Key");
            MessageBuffer.Add("You use the key");
            NewLevel = true;
        }
    }
}