using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorHybridMVVM.Components.ViewModels;

/// <summary>
/// The base view model.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// The pages title.
    /// </summary>
    private string title;

    /// <summary>
    /// Handles component changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Gets or the pages title.
    /// </summary>
    public string Title
    {
        get => this.title;
        protected set => this.SetProperty(ref this.title, value);
    }

    /// <summary>
    /// Notifies the view that a property has changed.
    /// </summary>
    /// <param name="propertyName">The property which changed.</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Sets a property and notifies that it has changed.
    /// </summary>
    /// <typeparam name="T">The property's type.</typeparam>
    /// <param name="backingStore">The property's backing field.</param>
    /// <param name="value">The value to set the backing field to.</param>
    /// <param name="propertyName">The property which changed.</param>
    protected virtual void SetProperty<T>(ref T backingStore, T value,
                                          [CallerMemberName] string propertyName = "")
    {
        // Don't need to set if the value is the same.
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return;

        backingStore = value;

        this.OnPropertyChanged(propertyName);
    }
}
