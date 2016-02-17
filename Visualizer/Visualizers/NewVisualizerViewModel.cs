using System;
using System.Windows;
using Dragablz;
using Visualizer.Services;

namespace Visualizer.Visualizers
{
    public class NewVisualizerViewModel : HeaderedItemViewModel
    {
        private readonly Action<NewVisualizerViewModel> _onCreate;

        public NewVisualizerViewModel(Action<NewVisualizerViewModel> onCreate)
        {
            _onCreate = onCreate;
            Header = "NEW VIZUALIZER SETTINGS";
            Content = new NewVisualizerView() {DataContext = this};
        }

        private VisualizerType _selectedVisualizerType;

        public VisualizerType SelectedVisualizerType
        {
            get { return _selectedVisualizerType; }
            set
            {
                if (_selectedVisualizerType == value) return;
                _selectedVisualizerType = value;
                OnPropertyChanged();
            }
        }

        private int _rowCount;

        public int RowCount
        {
            get { return _rowCount; }
            set
            {
                if (_rowCount == value) return;
                _rowCount = value;
                OnPropertyChanged();
            }
        }

        private int _colCount;

        public int ColCount
        {
            get { return _colCount; }
            set
            {
                if (_colCount == value) return;
                _colCount = value;
                OnPropertyChanged();
            }
        }

        public Size GridSize => new Size(ColCount, RowCount);

        public RelayCommand Create
        {
            get { return new RelayCommand(() => _onCreate?.Invoke(this)); }
        }

    }
}