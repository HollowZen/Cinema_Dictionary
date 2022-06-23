using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Cinema_Dictionary.Infrastructure.Command.Base;

internal class RelayCommand : ICommand
{
    #region Поля

    private readonly Action<object> _Execute;
    private readonly Predicate<object> _CanExecute;

    #endregion // Поля 

    #region Конструктор

    public RelayCommand(Action<object> execute) : this(execute, null) { }
    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        if (execute == null) throw new ArgumentNullException("execute");

        _Execute = execute;
        _CanExecute = canExecute;
    }

    #endregion // Конструктор 

    #region ICommand Члены

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
        return _CanExecute == null ? true : _CanExecute(parameter);
    }
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
    public void Execute(object parameter) { _Execute(parameter); }

    #endregion // ICommand Члены
}
