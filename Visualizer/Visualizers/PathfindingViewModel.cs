using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Algorithms.GraphTraversal;
using Dragablz;
using Visualizer.Services;
using Visualizer.ViewParts;

namespace Visualizer.Visualizers
{
    public class PathfindingViewModel : HeaderedItemViewModel
    {
        private readonly Size _gridSize;

        public PathfindingViewModel(Size gridSize)
        {
            _gridSize = gridSize;
            Header = "PATHFINDING";
            
            Content = new PathfindingView() { DataContext = this };

            Cells = Enumerable.Range(0, (int)gridSize.Height)
                .Select(y => Enumerable.Range(0, (int)gridSize.Width)
                .Select(x => new CellGridViewModel(x,y, OnCellClick)).ToArray()).ToArray();
            OnPropertyChanged("Cells");


            PlayCommand = new RelayCommand(Play, CanPlay);
        }
        

        private bool CanPlay()
        {
            return _startCell != null && _endCell != null;
        }

        public CellGridViewModel[][] Cells { get; private set; }


        #region Right PAnel // TODO : create specific view and viewmodel


        // TODO add map string / func des algo
        // binder dans la dropdown

        // add selected Algo

        public CellColorActionViewModel[] CellColorActions { get; } = new CellColorActionViewModel[]
        {
            new CellColorActionViewModel("Start","Start point of the path",'S',Colors.Chartreuse),
            new CellColorActionViewModel("End","End point of the path",'E',Colors.Firebrick),
            new CellColorActionViewModel("Wall","Can't walk on it",'W',Colors.Gainsboro),

        };

        private CellColorActionViewModel _selectedAction;
        public CellColorActionViewModel SelectedAction
        {
            get
            {
                return _selectedAction;
            }
            set
            {
                if (_selectedAction == value) return;
                _selectedAction = value;
                foreach (var item in CellColorActions)
                {
                    item.IsSelected = item == _selectedAction;
                }
                OnPropertyChanged();
            }
        }

        private int _delay = 200;
       

        public int Delay
        {
            get
            {
                return _delay;
            }
            set
            {
                if (_delay == value) return;
                _delay = value;
                OnPropertyChanged();
            }
        }



        public RelayCommand PlayCommand { get; set; }


        public RelayCommand BackCommand { get; } = new RelayCommand(() => { });
      
        public RelayCommand PauseCommand { get; } = new RelayCommand(() => { });
        public RelayCommand NextCommand { get; } = new RelayCommand(() => { });


        #endregion

        private void OnCellClick(CellGridViewModel cell)
        {
            if (SelectedAction != null)
            {
                // TODO : add dico for this
                if (SelectedAction.Code == 'S') SetStartCell(cell);
                if (SelectedAction.Code == 'E') SetEndCell(cell);

                cell.BackgroundBrush = SelectedAction.BackgroundBrush;
            }
        }


        private CellGridViewModel _startCell;
        private CellGridViewModel _endCell;

        private void SetStartCell(CellGridViewModel cell)
        {
            _startCell?.CleanCell();
            _startCell = cell;
            
        }

        private void SetEndCell(CellGridViewModel cell)
        {
            _endCell?.CleanCell();
            _endCell = cell;
        }

        private async void Play()
        {
            // if hasStart and has end
            if (!CanPlay()) return;

            foreach (var exploredCell in AStar.Explore(_startCell, GetNeighbours, GetCost, Heuristic, IsEnd))
            {
                exploredCell.BackgroundBrush = new SolidColorBrush(Colors.Aquamarine);
                await Task.Delay(Delay);
            }

            foreach (var exploredCell in AStar.FindPath(_startCell, GetNeighbours, GetCost, Heuristic, IsEnd))
            {
                exploredCell.BackgroundBrush = new SolidColorBrush(Colors.Blue);
            }

        }

        private bool IsEnd(CellGridViewModel cellGridViewModel)
        {
            return cellGridViewModel == _endCell;
        }

        private double Heuristic(CellGridViewModel current)
        {
            double heuristic = Math.Abs(current.X - _endCell.X) + Math.Abs(current.Y - _endCell.Y);
            var dx1 = current.X - _endCell.X;
            var dy1 = current.Y - _endCell.Y;
            var dx2 = _startCell.X - _endCell.X;
            var dy2 = _startCell.Y - _endCell.Y;
            var cross = Math.Abs(dx1*dy2 - dx2*dy1);
            //heuristic += cross*0.05;
            return heuristic;
        }

        private int GetCost(CellGridViewModel cellGridViewModel, CellGridViewModel gridViewModel)
        {
            return 1;
        }

        private IEnumerable<CellGridViewModel> GetNeighbours(CellGridViewModel cellGridViewModel)
        {
            var y = cellGridViewModel.Y;
            var x = cellGridViewModel.X;
           
            if (y > 0 && IsWalkable(Cells[y - 1][x])) yield return Cells[y - 1][x]; // top
            if (x < _gridSize.Width-1 && IsWalkable(Cells[y][x + 1])) yield return Cells[y][x+1];// right
            if (y < _gridSize.Height-1 && IsWalkable(Cells[y + 1][x])) yield return Cells[y+1][x];// bottom
            if (x > 0 && IsWalkable(Cells[y][x - 1])) yield return Cells[y][x-1]; // top

        }

        private bool IsWalkable(CellGridViewModel cell)
        {
            return cell.BackgroundBrush.Color != Colors.Gainsboro; // TODO CLEAN this code !!
        }
    }
}
