﻿using Model.MineSweeper;

namespace ViewModel
{
    public class GameViewModel
    {
        private readonly IGame _game;
        public GameViewModel(IGame game)
        {
            _game = game;
            Board = new GameBoardViewModel(game.Board);
        }

        public GameBoardViewModel Board { get; }
    }
}
