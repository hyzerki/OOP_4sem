using Lab6.View;
using System.Windows.Input;

namespace Lab6.Commands
{
    public static class SampleRoutedCommand
    {
        public static RoutedUICommand SampleCommand = new RoutedUICommand("Sample Command", "SampleCommand", typeof(MainView));
    }
}
