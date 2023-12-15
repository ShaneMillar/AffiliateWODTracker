using AffiliateWODTracker.Mobile.Service;
using AffiliateWODTracker.Mobile.Views.Home;
using AffiliateWODTracker.Mobile.Views.Workouts;
using Microsoft.Extensions.Logging;

namespace AffiliateWODTracker.Mobile
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

            builder.Services.AddSingleton<HttpClientService>();
            builder.Services.AddSingleton<MemberService>();
            builder.Services.AddSingleton<WODService>();

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<AddWorkout>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
