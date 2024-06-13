using Microsoft.Extensions.Logging;
using System;
using SQLite;
using SQLitePCL;
using MauiApp1.Repositories;

namespace MauiApp1
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
            
#endif
            builder.Services.AddSingleton<CustomerRepository>();
            builder.Services.AddSingleton<CompoRepository>();

            return builder.Build();
        }
    }
}
