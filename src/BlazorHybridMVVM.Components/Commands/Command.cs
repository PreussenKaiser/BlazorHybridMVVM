using System.Windows.Input;

namespace BlazorHybridMVVM.Components.Commands;

/// <summary>
/// Represents an executable command
/// </summary>
public class Command : ICommand
{
    /// <summary>
    /// Occurs when changes occur that affect whether or not the command should execute.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// The action to execute.
    /// </summary>
    private readonly Action<object> execute;

    /// <summary>
    /// A functioning determining if the action can execute.
    /// </summary>
    private readonly Func<object, bool> canExecute;

    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class.
    /// </summary>
    /// <param name="execute">The action to execute.</param>
    /// <exception cref="ArgumentNullException"/>
    public Command(Action<object> execute)
    {
        if (execute is null)
            throw new ArgumentNullException(nameof(execute));

        this.execute = execute;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class.
    /// </summary>
    /// <param name="execute">The action to execute.</param>
    /// <exception cref="ArgumentNullException"/>
    public Command(Action execute)
        : this(o => execute())
    {
        if (execute is null)
            throw new ArgumentNullException(nameof(execute));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Command"/> class.
    /// </summary>
    /// <param name="execute">The action to execute.</param>
    /// <param name="canExecute">A functioning determining if the action can execute.</param>
    public Command(Action<object> execute, Func<object, bool> canExecute)
        : this(execute)
        => this.canExecute = canExecute;



    /// <summary>
    /// Determines if the command can be executed.
    /// </summary>
    /// <param name="parameter">The command's parameter.</param>
    /// <returns>Whether the action can be executed or not.</returns>
    public bool CanExecute(object parameter)
    {
        if (this.canExecute is not null)
            return this.canExecute(parameter);

        return true;
    }

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="parameter">The action's parameter.</param>
    public void Execute(object parameter)
        => this.execute(parameter);
}
