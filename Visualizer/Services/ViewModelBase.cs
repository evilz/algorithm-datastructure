using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Visualizer.Services
{
    public class ViewModelBase<TViewType> : INotifyPropertyChanged
        where TViewType : FrameworkElement
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public TViewType View { get; }

        public ViewModelBase(TViewType view)
        {
            View = view;
            View.DataContext = this;
        }
        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
