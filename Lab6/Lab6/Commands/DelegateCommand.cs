using System;
using System.Windows.Input;

namespace Lab6.Commands
{
    internal class DelegateCommand : ICommand
    {
        Action executable;
        Func<bool>? canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object? parameter)
        {
            if (canExecute is not null)
            {
                return canExecute();
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            if (executable is not null)
            {
                executable();
            }
        }

        public DelegateCommand(Action executable, Func<bool> canExecute)
        {
            this.executable = executable;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action executable)
        {
            this.executable = executable;
        }
    }
}
