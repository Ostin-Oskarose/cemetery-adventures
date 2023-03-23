using Cemetery_Adventure_Logic;

namespace Cemetery_Adventure.Outputs
{
    public class Output
    {
        public static void Init()
        {
            Console.CursorVisible = false;
        }

        public static void DisplayBoard(Game game)
        {
            for (int i = 0; i < game.GameBoard.BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < game.GameBoard.BoardArray.GetLength(1); j++)
                {
                    if (game.GameBoard.BoardArray[i, j] == null)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    Console.Write($"{game.GameBoard.BoardArray[i, j].Symbol} ");
                }
                Console.WriteLine();
            }
        }
    }
}
