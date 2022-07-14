using BlazorHybridMVVM.Core.Models;
using BlazorHybridMVVM.Core.Services;

namespace BlazorHybridMVVM.Infrastructure.Services;

/// <summary>
/// 
/// </summary>
public class ForecastService : IForecastService
{
	/// <summary>
	/// 
	/// </summary>
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing",
		"Chilly", "Cool",
		"Mild", "Warm",
		"Balmy", "Hot",
		"Sweltering", "Scorching"
	};

	/// <summary>
	/// 
	/// </summary>
	/// <param name="startDate"></param>
	/// <returns></returns>
	public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
		=> Task.FromResult(Enumerable.Range(1, 5)
									 .Select(index => new WeatherForecast
		{
			Date = startDate.AddDays(index),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		}).ToArray());
}

