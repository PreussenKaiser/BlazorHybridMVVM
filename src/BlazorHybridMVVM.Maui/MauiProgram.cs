using BlazorHybridMVVM.Components.ViewModels;
using BlazorHybridMVVM.Core.Services;
using BlazorHybridMVVM.Infrastructure.Services;

namespace BlazorHybridMVVM.Maui;

/// <summary>
/// 
/// </summary>
public static class MauiProgram
{
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<IForecastService, ForecastService>()
						.AddSingleton<IndexViewModel>()
						.AddSingleton<CounterViewModel>()
						.AddSingleton<FetchDataViewModel>();

		return builder.Build();
	}
}
