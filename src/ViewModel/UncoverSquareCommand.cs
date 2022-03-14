﻿using Cells;
using Model.Data;
using Model.MineSweeper;
using System.Diagnostics;
using System.Windows.Input;

namespace ViewModel
{
    internal class UncoverSquareCommand : ICommand
    {
        public ICell<IGame> Game { get; }
        public Vector2D Position { get; }
        public UncoverSquareCommand(ICell<IGame> game, Vector2D position)
        {
            Game = game;
            Position = position;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Game.Value = Game.Value.UncoverSquare(Position);
        }
    }
}
