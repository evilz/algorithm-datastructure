using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragablz;
using Dragablz.Dockablz;
using Visualizer.Services;
using Visualizer.Visualizers;

namespace Visualizer
{
    public class ShellViewModel : ViewModelBase<ShellView>
    {
        private readonly IInterTabClient _interTabClient = new ShellInterTabClient();
        private readonly ObservableCollection<HeaderedItemViewModel> _items;
        private readonly ObservableCollection<HeaderedItemViewModel> _toolItems = new ObservableCollection<HeaderedItemViewModel>();

        // selected view ??

        public ShellViewModel() : base(new ShellView())
        {
            _items = new ObservableCollection<HeaderedItemViewModel>(new HeaderedItemViewModel[] { NewItemFactory() });
        }

        public ShellViewModel(bool addCreateTab) : base(new ShellView())
        {
            _items = addCreateTab
                ? new ObservableCollection<HeaderedItemViewModel>(new[] { NewItemFactory() })
                : new ObservableCollection<HeaderedItemViewModel>();
        }

        public ShellViewModel(params HeaderedItemViewModel[] items) : base(new ShellView())
        {
            _items = new ObservableCollection<HeaderedItemViewModel>(items);
        }

        public Func<HeaderedItemViewModel> NewItemFactory => () => new NewVisualizerViewModel(CreateVizualizer);

        public Action<NewVisualizerViewModel> CreateVizualizer
        {
            get
            {
                return (tabModel) =>
                {
                    var index = Items.IndexOf(tabModel);
                    var newModel = GetVisualizerModel(tabModel);
                    Items.Insert(index, newModel);
                    Items.Remove(tabModel);
                };
            }
        }

        private static HeaderedItemViewModel GetVisualizerModel(NewVisualizerViewModel tabModel)
        {
            return TabViewFactory.VisualizerTypeViews[tabModel.SelectedVisualizerType].Invoke(tabModel.GridSize);
        }

        public ObservableCollection<HeaderedItemViewModel> Items
        {
            get { return _items; }
        }

        public static Guid TabPartition
        {
            get { return new Guid("2AE89D18-F236-4D20-9605-6C03319038E6"); }
        }

        public IInterTabClient InterTabClient
        {
            get { return _interTabClient; }
        }

        public ObservableCollection<HeaderedItemViewModel> ToolItems
        {
            get { return _toolItems; }
        }

        public ItemActionCallback ClosingTabItemHandler
        {
            get { return ClosingTabItemHandlerImpl; }
        }

        /// <summary>
        /// Callback to handle tab closing.
        /// </summary>        
        private static void ClosingTabItemHandlerImpl(ItemActionCallbackArgs<TabablzControl> args)
        {
            //in here you can dispose stuff or cancel the close

            //here's your view model:
            var viewModel = args.DragablzItem.DataContext as HeaderedItemViewModel;
            //Debug.Assert(viewModel != null);

            //here's how you can cancel stuff:
            //args.Cancel(); 
        }

        public ClosingFloatingItemCallback ClosingFloatingItemHandler
        {
            get { return ClosingFloatingItemHandlerImpl; }
        }

        /// <summary>
        /// Callback to handle floating toolbar/MDI window closing.
        /// </summary>        
        private static void ClosingFloatingItemHandlerImpl(ItemActionCallbackArgs<Layout> args)
        {
            //in here you can dispose stuff or cancel the close

            //here's your view model: 
            var disposable = args.DragablzItem.DataContext as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            //here's how you can cancel stuff:
            //args.Cancel(); 
        }
    }
}
