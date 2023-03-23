﻿using Cemetery_Adventure_Logic.Entity.Character.Enemy;
using Cemetery_Adventure_Logic.Entity;
using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.Item.Equipment;

namespace Cemetery_Adventure_Logic.GameBoard
{
    public class Board
    {
        private int Width { get; }
        private int Height { get; }
        public List<Enemy> EnemyList { get; }
        public Entity.Entity[,] BoardArray { get; set; }

        private Random random = new Random();

        public Board(int height, int width, Player player, int floor)
        {
            Width = width;
            Height = height;
            EnemyList = new List<Enemy>();
            BoardArray = new Entity.Entity[Height, Width];
            BoardArray[player.Position.Y, player.Position.X] = player;
            CreateBorders();
            CreateStairs(floor);
            GenerateEnemies(floor);
            GiveKeyToEnemy();
            CreateTombs();
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

        private void GenerateEnemies(int floor)
        {
            int minAmount = (int)Math.Ceiling((double)(Height * Width / 300 + 1));
            int maxAmount = (int)Math.Ceiling((double)(Height *  Width / 120));
            var availableEnemiesList = Enum.GetValues<Enemies>().Where(x => (int)x < floor).ToList();

            foreach (var enemy in availableEnemiesList)
            {
                int amount = random.Next(minAmount, maxAmount);
                CreateEnemies(enemy, amount);
            }
        }

        private void CreateEnemies(Enemies enemy, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                do
                {
                    int x = random.Next(0, Width - 1);
                    int y = random.Next(0, Height - 1);

                    if (BoardArray[y, x] == null)
                    {
                        BoardArray[y, x] = enemy switch
                        {
                            Enemies.Rat => new Rat((x, y)),
                            Enemies.Skeleton => new Skeleton((x, y)),
                            Enemies.Ghoul => new Ghoul((x, y)),
                            Enemies.Zombie => new Zombie((x, y)),
                            Enemies.Vampire => new Vampire((x, y)),
                            Enemies.Necromancer => new Necromancer((x, y))

                        };
                        EnemyList.Add((Enemy)BoardArray[y, x]);
                        break;
                    }
                } while (true);
            }
        }

        private void GiveKeyToEnemy()
        {
            var randomIndex = random.Next(EnemyList.Count);
            var key = new Key();
            EnemyList[randomIndex].AddItemToInventory(key);
        }

        public void MoveEntity((int X, int Y) entityPosition, (int X, int Y) targetPosition)
        {
            var entity = BoardArray[entityPosition.Y, entityPosition.X];
            BoardArray[entityPosition.Y, entityPosition.X] = null;
            BoardArray[targetPosition.Y, targetPosition.X] = entity;
        }

        public void CreateTombs()
        {
            var numTombs = random.Next(15, 25);
            for (var i = 0; i < numTombs; i++)
            {
                var x = random.Next(1, Width - 2);
                var y = random.Next(1, Height - 2);
                if (BoardArray[y, x] == null)
                {
                    BoardArray[y, x] = new BoardItem((y, x), "+");
                }
            }
        }

        public void CreateStairs(int floor)
        {
            while (true)
            {
                var x = random.Next(1, Width - 2);
                var y = random.Next(1, Height - 2);
                if (BoardArray[y, x] == null)
                {
                    BoardArray[y, x] = new Stairs((y, x), floor);
                    break;
                }
            }
        }

        public bool IsOccupied((int X, int Y) position)
        {
            return BoardArray[position.Y, position.X] != null;
        }

        public void RemoveEntity((int X, int Y) position)
        {
            BoardArray[position.Y, position.X] = null;
        }
    }
}
