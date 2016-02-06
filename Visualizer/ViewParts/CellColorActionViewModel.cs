using System.Windows.Media;
using Visualizer.Services;

namespace Visualizer.ViewParts
{
    public class CellColorActionViewModel : ViewModelBase
    {
        public CellColorActionViewModel(string name, string description, char code, Color backgroundColor)
        {
            Name = name;
            Description = description;
            Code = code;
            BackgroundBrush = new SolidColorBrush(backgroundColor);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                RaisePropertyChanged();
            }
        }

        public char Code
        {
            get { return _code; }
            set
            {
                if (value == _code) return;
                _code = value;
                RaisePropertyChanged();
            }
        }
        
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

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        private string _name;

        private string _description;

        private char _code;

        private bool _isSelected;

        private SolidColorBrush _backgroundBrush;
    }
}

