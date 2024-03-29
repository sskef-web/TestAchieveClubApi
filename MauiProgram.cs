using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace TestAchieveClubApi
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://sskef.site/api/")
    });

            return builder.Build();
        }
    }
}
