using BlazorHybridMVVM.Components.Commands;
using BlazorHybridMVVM.Core.Models;
using BlazorHybridMVVM.Core.Services;

using System.Windows.Input;

namespace BlazorHybridMVVM.Components.ViewModels;

/// <summary>
/// The view model for the FetchData page.
/// </summary>
public class FetchDataViewModel : BaseViewModel
{
	/// <summary>
	/// The service to get forecasts with.
	/// </summary>
	private readonly IForecastService forecastService;

	/// <summary>
	/// Weather forecasts.
	/// </summary>
	private IEnumerable<WeatherForecast> forecasts;

	/// <summary>
	/// Initializes <see cref="FetchDataViewModel"/>.
	/// </summary>
	public FetchDataViewModel(IForecastService forecastService)
	{
		this.forecastService = forecastService;
		this.forecasts = new List<WeatherForecast>();

		this.Title = "Weather Forecast";
		this.GetForecastCommand = new Command(async ()
			=> await this.GetForecastAsync());
	}

	/// <summary>
	/// The command to execute in order too fetch data.
	/// </summary>
	public ICommand GetForecastCommand { get; }

	/// <summary>
	/// Gets weather forecasts.
	/// </summary>
	public IEnumerable<WeatherForecast> Forecasts
	{
		get => this.forecasts;
		private set => this.SetProperty(ref this.forecasts, value);
	}

	/// <summary>
	/// Gets forecasts from the service.
	/// </summary>
	/// <returns>The service to get forecasts from.</returns>
	private async Task GetForecastAsync()
	{
		var forecasts = await this.forecastService.GetForecastAsync(DateTime.Now);

		this.Forecasts = forecasts;
	}
}
