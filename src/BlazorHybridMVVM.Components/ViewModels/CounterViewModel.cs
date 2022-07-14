using BlazorHybridMVVM.Components.Commands;

using System.Windows.Input;

namespace BlazorHybridMVVM.Components.ViewModels;

/// <summary>
/// The view model for the Counter page.
/// </summary>
public class CounterViewModel : BaseViewModel
{
    /// <summary>
    /// Initializes <see cref="CounterViewModel"/>.
    /// </summary>
    public CounterViewModel()
    {
        this.Title = "Counter";
        this.IncrementCommand = new Command(this.IncrementCount);
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets the command to execute when the counter is incremented.
    /// </summary>
    public ICommand IncrementCommand { get; }

    /// <summary>
    /// Increments <see cref="Count"/> by one.
    /// </summary>
    private void IncrementCount()
        => this.Count++;
}
