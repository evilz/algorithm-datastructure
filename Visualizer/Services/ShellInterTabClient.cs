using System.Windows;
using Dragablz;

namespace Visualizer.Services
{
    public class ShellInterTabClient : IInterTabClient
    {
        public INewTabHost<Window> GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            var view = new ShellViewModel(false).View;
            return new NewTabHost<Window>(view, view.ShellTabablzControl);
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            return TabEmptiedResponse.CloseWindowOrLayoutBranch;
        }
    }
}
