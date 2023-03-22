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
    }
}
