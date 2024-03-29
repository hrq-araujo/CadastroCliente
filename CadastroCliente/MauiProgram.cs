﻿using Microsoft.Extensions.Logging;
using CadastroCliente.ViewModels;

namespace CadastroCliente
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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddTransient<RegisterPageView>();
            builder.Services.AddTransient<RegisterPageViewModel>();

            builder.Services.AddTransient<UpdatePageView>();
            builder.Services.AddTransient<UpdatePageViewModel>();

            return builder.Build();
        }
    }
}
