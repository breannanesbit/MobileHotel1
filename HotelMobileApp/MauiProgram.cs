using HotelMobileApp.ViewModel;
using Microsoft.Extensions.Logging;
using HotelFinal.Services;


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

          
            
          
            //builder.UseMauiCommunityToolkit();
            //builder.Services.AddHttpClient<PublicClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

#if DEBUG
            builder.Logging.AddDebug();

#endif
            builder.Services.AddSingleton<HotelService>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<PublicClient>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://local:7000") });

            return builder.Build();
        }
    }
}