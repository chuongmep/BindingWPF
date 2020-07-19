using System;
using System.Windows.Input;

namespace BindingWPF
{
    public class RelayCommand : ICommand
    {private readonly Action _act;

        public RelayCommand(Action act)
        {
            _act = act;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _act();
        }
    }
}
