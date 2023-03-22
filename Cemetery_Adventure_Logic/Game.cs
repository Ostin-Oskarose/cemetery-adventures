using Cemetery_Adventure_Logic.GameBoard;

namespace Cemetery_Adventure_Logic
{
    public class Game
    {
        private int _width = 50;
        private int _height = 40;
        public Board GameBoard { get; set; }

        public Game()
        {
            GameBoard = new Board(_height, _width);
        }
    }
}