using BlazorHybridMVVM.Core.Models;

namespace BlazorHybridMVVM.Core.Services;

/// <summary>
/// 
/// </summary>
public interface IForecastService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startDate"></param>
    /// <returns></returns>
    Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
}
