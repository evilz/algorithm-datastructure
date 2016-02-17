using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Visualizer.ViewParts
{
    /// <summary>
    /// Interaction logic for CellGridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        public GridView()
        {
            InitializeComponent();
        }

        public CellGridViewModel[][] Cells
        {
            get { return (CellGridViewModel[][])GetValue(CellsProperty); }
            set { SetValue(CellsProperty, value); }
        }
        public static readonly DependencyProperty CellsProperty = DependencyProperty.Register(nameof(Cells), typeof(CellGridViewModel[][]), typeof(GridView), new PropertyMetadata());

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var elm = ((Rectangle)sender);
            var context = elm.DataContext as CellGridViewModel;
            context?.OnClick(context);

        }

        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            var elm = ((Rectangle)sender);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var context = elm.DataContext as CellGridViewModel;
                context?.OnClick(context);
            }
        }
    }
}
