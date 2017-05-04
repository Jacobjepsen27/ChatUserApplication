using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ChatUserApplication.WebSockets
{
    public static class WebSocketManagerExtensions
    {
        //For DI
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddTransient<WebSocketConnectionManager>();
            //Adds the implementation of WebSocketHandler to DI (fx. ChatMessageHandler)
            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(WebSocketHandler))
                {
                    services.AddSingleton(type);
                }
            }
            return services;
        }

         
        public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app,
                                                              PathString path,
                                                              WebSocketHandler handler)
        {
            return app.Map(path, (_app) => _app.UseMiddleware<WebSocketManagerMiddleware>(handler));
            //return app.Use(async (context, next) => {
                
            //});
        }

        public static IApplicationBuilder MapWebSocketUserManager(this IApplicationBuilder app,
                                                              PathString path,
                                                              WebSocketHandler handler)
        {
            return app.Map(path, (_app) => _app.UseMiddleware<WebSocketUserManagerMiddleware>(handler));
        }
    }
}
