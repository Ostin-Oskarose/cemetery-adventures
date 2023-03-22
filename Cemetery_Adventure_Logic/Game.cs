﻿using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.GameBoard;

namespace Cemetery_Adventure_Logic
{
    public class Game
    {
        private int _width = 50;
        private int _height = 40;
        private Player _player;

        public Board GameBoard { get; set; }

        public Game()
        {
            _player = new Player("Player", (1, 1), 10, 1, 0);
            GameBoard = new Board(_height, _width, _player);
        }

        public void Start()
        {
            var gameRunning = true;
            while (gameRunning)
            {
                _player.Turn();
            }
        }
    }
}