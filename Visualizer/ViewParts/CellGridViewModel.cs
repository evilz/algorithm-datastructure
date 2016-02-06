using System;
using System.Windows.Media;
using Visualizer.Services;

namespace Visualizer.ViewParts
{
    public class CellGridViewModel : ViewModelBase
    {
        public int X { get; }
        public int Y { get; }
        public static readonly SolidColorBrush DefaultBackgroundBrush =new SolidColorBrush(Colors.White);

        public CellGridViewModel(int x, int y,Action<CellGridViewModel> onClick)
        {
            X = x;
            Y = y;
            BackgroundBrush = DefaultBackgroundBrush;
            OnClick = onClick;
        }

        public void CleanCell()
        {
            BackgroundBrush = DefaultBackgroundBrush;
        }

        
        private SolidColorBrush _backgroundBrush;
        public SolidColorBrush BackgroundBrush
        {
            get { return _backgroundBrush; }
            set
            {
                if (Equals(value, _backgroundBrush)) return;
                _backgroundBrush = value;
                RaisePropertyChanged();
            }
        }

        private Action<CellGridViewModel> _onClick;
        public Action<CellGridViewModel> OnClick
        {
            get { return _onClick; }
            set
            {
                if (Equals(value, _onClick)) return;
                _onClick = value;
                RaisePropertyChanged();
            }
        }
    }
}
