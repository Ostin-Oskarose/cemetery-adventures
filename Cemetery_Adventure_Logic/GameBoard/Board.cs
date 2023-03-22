using Cemetery_Adventure_Logic.Entity.Character.Enemy;
using Cemetery_Adventure_Logic.Entity;
using Cemetery_Adventure_Logic.Entity.Character;

namespace Cemetery_Adventure_Logic.GameBoard
{
    public class Board
    {
        private int Width { get; }
        private int Height { get; }
        public List<Enemy> EnemyList { get; }
        public Entity.Entity[,] BoardArray { get; set; }

        public Board(int height, int width, Player player)
        {
            Width = width;
            Height = height;
            EnemyList = new List<Enemy>();
            BoardArray = new Entity.Entity[Height, Width];
            BoardArray[player.Position.Y, player.Position.X] = player;
            CreateBorders();
            GenerateEnemies();
        }

        private void CreateBorders()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if ((i == 0 || i == Height - 1) || (j == 0 || j == Width - 1))
                    {
                        BoardArray[i, j] = new BoardItem((j, i), "#");
                    }
                }
            }
        }

        private void GenerateEnemies()
        {
            Random random = new Random();
            //TODO Change to ceil minAmount
            int minAmount = (Height * Width) / 300 + 1;
            int maxAmount = (Height *  Width) / 120;

            foreach (var enemy in Enum.GetValues<Enemies>())
            {
                int amount = random.Next(minAmount, maxAmount);
                CreateEnemies(enemy, amount);
            }
        }

        private void CreateEnemies(Enemies enemy, int amount)
        {
            Random random = new Random();

            for (int i = 0; i < amount; i++)
            {
                do
                {
                    int x = random.Next(0, Height - 1);
                    int y = random.Next(0, Width - 1);

                    if (BoardArray[x, y] == null)
                    {
                        BoardArray[x, y] = enemy switch
                        {
                            Enemies.Skeleton => new Skeleton((x, y))
                        };
                        EnemyList.Add((Enemy)BoardArray[x, y]);
                        break;
                    }
                } while (true);
            }
        }

        public void MoveEntity((int X, int Y) entityPosition, (int X, int Y) targetPosition)
        {
            var entity = BoardArray[entityPosition.Y, entityPosition.X];
            BoardArray[entityPosition.Y, entityPosition.X] = null;
            BoardArray[targetPosition.Y, targetPosition.X] = entity;
        }
    }
}
