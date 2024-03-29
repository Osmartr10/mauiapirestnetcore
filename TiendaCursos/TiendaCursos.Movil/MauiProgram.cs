﻿using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.Logging;
using TiendaCursos.Movil.Repositorios;

namespace TiendaCursos.Movil
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
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5141/")
            });
            builder.Services.AddScoped<IRepositorio, Repositorio>();
            builder.Services.AddSweetAlert2();
            return builder.Build();
        }
    }
}
