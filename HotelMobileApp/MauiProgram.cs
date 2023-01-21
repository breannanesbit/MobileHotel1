using HotelMobileApp.ViewModel;
using Microsoft.Extensions.Logging;

using HotelFinal.Services;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui;

namespace HotelMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


#if DEBUG
            builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton<HotelService>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<PublicClient>();
            builder.UseMauiCommunityToolkit();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://local:7000") });

            builder.Services.AddHttpClient("ServerAPI",
            client => client.BaseAddress = new Uri(Preferences.Get("ServerAPIBaseAddress", "https://local:7000")));

            return builder.Build();
        }
    }
}