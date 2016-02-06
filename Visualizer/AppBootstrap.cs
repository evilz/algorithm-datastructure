using System;
using System.Windows;

namespace Visualizer
{
    class AppBootstrap
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App { ShutdownMode = ShutdownMode.OnLastWindowClose };
            app.InitializeComponent();

            new ShellViewModel().View.Show();

            app.Run();
        }
    }
}
