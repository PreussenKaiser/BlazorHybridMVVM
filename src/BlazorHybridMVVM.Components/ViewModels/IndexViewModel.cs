namespace BlazorHybridMVVM.Components.ViewModels;

/// <summary>
/// The view model for the Index page.
/// </summary>
public class IndexViewModel : BaseViewModel
{
	/// <summary>
	/// Initializes <see cref="IndexViewModel"/>.
	/// </summary>
	public IndexViewModel()
		=> this.Title = "Hello, World!";
}
