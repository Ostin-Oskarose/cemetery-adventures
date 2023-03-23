using Cemetery_Adventure_Logic.Entity;
using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.GameBoard;

namespace Cemetery_Adventure_Logic
{
    public class Game
    {
        private int _width = 20;
        private int _height = 20;
        public Player Player;
        private int Floor;
        private DateTime LastEnemyUpdate = DateTime.Now;
        public bool PlayerIsAlive => Player.IsAlive;

        public Board GameBoard { get; set; }

        public Game()
        {
            Player = new Player("Player", (1, 1), 10, 1, 0);
            Floor = 1;
            GameBoard = new Board(_height, _width, Player, Floor);
        }

        public void Update()
        {
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

        public bool ValidateMoveWithinBounds((int X, int Y) move)
        {
            return move is { X: >= 0, Y: >= 0 } && move.X < _width && move.Y < _height;
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
                case BoardItem:
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
            if (ValidateMoveWithinBounds(move))
            {
                if (GameBoard.IsOccupied(move))
                {
                    switch (GetCollisionType(move))
                    {
                        case CollisionType.Character:
                            var target = GameBoard.BoardArray[move.Y, move.X] as Character;
                            if (target != character)
                            {
                                character.Attack(target);
                            }
                            break;
                        case CollisionType.Obstacle:
                            var obstacle = GameBoard.BoardArray[move.Y, move.X];
                            if (obstacle is Stairs stairs && character is Player)
                            {
                                Floor = stairs.LevelNumber + 1;
                                GameBoard = new Board(_height, _width, Player, Floor);
                            }
                            break;
                    }
                }
                else
                {
                    GameBoard.MoveEntity(character.Position, move);
                    character.Move(move.X, move.Y);
                }
            }
        }

        public void RemoveDeadEnemies()
        {
            foreach (var enemy in GameBoard.EnemyList)
            {
                if (!enemy.IsAlive)
                {
                    GameBoard.RemoveEntity(enemy.Position);
                }
            }

            GameBoard.EnemyList.RemoveAll(enemy => !enemy.IsAlive);
        }
    }
}