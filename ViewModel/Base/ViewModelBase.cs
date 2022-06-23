using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cinema_Dictionary.ViewModel.Base;

internal abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
{

    private bool _disposed;

    public void Dispose()
    {
        Dispose(true);
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    protected virtual bool Dispose(bool disposing)
    {
        if (!disposing || _disposed) return true;

        _disposed = true;
        return _disposed;
    }
}
