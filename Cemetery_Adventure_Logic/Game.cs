using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.GameBoard;

namespace Cemetery_Adventure_Logic
{
    public class Game
    {
        private int _width = 50;
        private int _height = 40;
        private Player _player;
        private int Floor;

        public Board GameBoard { get; set; }

        public Game()
        {
            _player = new Player("Player", (1, 1), 10, 1, 0);
            Floor = 1;
            GameBoard = new Board(_height, _width, _player, Floor);
        }

        public void Update()
        {
            PlayerTurn();
        }

        public void PlayerTurn()
        {
            var move = _player.GetMove();
            if (ValidateMove(move))
            {
                GameBoard.MoveEntity(_player.Position, move);
                _player.Move(move.X, move.Y);
            }

        }

        public bool ValidateMove((int X, int Y) move)
        {
            return WithinBounds(move);

            bool WithinBounds((int X, int Y) move)
            {
                return move is { X: >= 0, Y: >= 0 } && move.X < _width && move.Y < _height;
            }
        }

    }
}