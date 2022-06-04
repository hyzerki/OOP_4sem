using Lab6.ViewModel;
using System;
using System.Windows.Input;

namespace Lab6.Commands
{
    internal class SwitchViewCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        MainViewModel mainViewModel;

        public SwitchViewCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string? param = parameter as string;
            if (param is not null)
            {
                switch (param)
                {
                    case "Catalog":
                        mainViewModel.SelectedViewModel = new CatalogViewModel(mainViewModel);
                        break;
                    case "AddBook":
                        mainViewModel.SelectedViewModel = new AddBookToCatalogViewModel(mainViewModel);
                        break;
                    case "Cart":
                        mainViewModel.SelectedViewModel = new CartViewModel(mainViewModel);
                        break;
                    case "ADO":
                        mainViewModel.SelectedViewModel = new ADODemoViewModel(mainViewModel);
                        break;
                    case "EventsDemo":
                        mainViewModel.SelectedViewModel = new EventsDemoViewModel(mainViewModel);
                        break;
                }

            }
        }
    }
}
