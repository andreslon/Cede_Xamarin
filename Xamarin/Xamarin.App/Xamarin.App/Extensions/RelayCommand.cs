using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Xamarin.App.Extensions
{
    public class RelayCommand : ICommand
    {
        private Action action;
        private Func<bool> condition;
        public RelayCommand(Action action, Func<bool> condition)
        {
            this.action = action;
            this.condition = condition;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (condition != null)
            {
                return condition();
            }
            return true;
        }
        public void Execute(object parameter)
        {
            action();
        }
    }
}
