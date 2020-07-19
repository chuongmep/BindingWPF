using System;
using System.Threading;
using System.Windows;
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

    public class CloseCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Window myWin = parameter as Window;
            myWin.Close();
        }
    }
}
