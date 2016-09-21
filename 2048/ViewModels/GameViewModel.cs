using _2048.Models;
using _2048.Utilities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using _2048.Views;

namespace _2048.ViewModels
{
    public class GameViewModel : ObservableObject
    {
        private List<CellViewModel> _cells;

        public List<CellViewModel> Cells
        {
            get { return _cells; }
        }

        public int Width { get { return gameGrid.Width; } }
        public int Height { get { return gameGrid.Height; } }

        public int Score { get { return gameGrid.Score; } }

        private GameGrid gameGrid;

        public GameViewModel()
        {
            NewGame();
        }

        private void NewGame()
        {
            gameGrid = new GameGrid(Properties.Settings.Default.Width, Properties.Settings.Default.Height);
            Debug.WriteLine("new game");
            CreateCells();
            RaisePropertyChangedEvent("Width");
            RaisePropertyChangedEvent("Height");
            RaisePropertyChangedEvent("Cells");
            RaisePropertyChangedEvent("Score");
        }

        private void CreateCells()
        {
            _cells = new List<CellViewModel>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    _cells.Add(new CellViewModel(gameGrid.Cells[x, y].Value, x, y));
                }
            }
        }

        private void UpdateCells()
        {
            foreach (CellViewModel cell in _cells)
            {
                int x = cell.X;
                int y = cell.Y;
                cell.Value = gameGrid.Cells[x, y].Value;
            }
        }

        private ICommand _newGameCommand;
        public ICommand NewGameCommand
        {
            get
            {
                if (null == _newGameCommand)
                    _newGameCommand = new DelegateCommand(param => NewGame());
                return _newGameCommand;
            }
        }

        private ICommand _optionsCommand;
        public ICommand OptionsCommand
        {
            get
            {
                if (null == _optionsCommand)
                    _optionsCommand = new DelegateCommand(param => Options());
                return _optionsCommand;
            }
        }

        private void Options()
        {
            OptionsView view = new OptionsView();
            view.Show();
        }

        private ICommand _moveUpCommand;

        public ICommand MoveUpCommand
        {
            get
            {
                if (null == _moveUpCommand)
                    _moveUpCommand = new DelegateCommand(param => MoveUp(), param => CanMove());
                return _moveUpCommand;
            }
        }

        private ICommand _moveDownCommand;

        public ICommand MoveDownCommand
        {
            get
            {
                if (null == _moveDownCommand)
                    _moveDownCommand = new DelegateCommand(param => MoveDown(), param => CanMove());
                return _moveDownCommand;
            }
        }

        private ICommand _moveLeftCommand;

        public ICommand MoveLeftCommand
        {
            get
            {
                if (null == _moveLeftCommand)
                    _moveLeftCommand = new DelegateCommand(param => MoveLeft(), param => CanMove());
                return _moveLeftCommand;
            }
        }

        private ICommand _moveRightCommand;

        public ICommand MoveRightCommand
        {
            get
            {
                if (null == _moveRightCommand)
                    _moveRightCommand = new DelegateCommand(param => MoveRight(), param => CanMove());
                return _moveRightCommand;
            }
        }

        public void MoveUp()
        {
            Move(Direction.Up);
        }

        public void MoveDown()
        {
            Move(Direction.Down);
        }

        public void MoveLeft()
        {
            Move(Direction.Left);
        }

        public void MoveRight()
        {
            Debug.WriteLine("Right");
            Move(Direction.Right);
        }

        private bool CanMove()
        {
            return true;
        }

        private void Move(Direction dir)
        {
            if (gameGrid.MoveRequest(dir))
            {
                UpdateCells();
                RaisePropertyChangedEvent("Score");
            }
        }
    }
}