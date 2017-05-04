using ChatUserApplication.WebSockets.WebSocketImplementation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ChatUserApplication.WebSockets
{
    public class WebSocketUserManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private WebSocketHandler _webSocketHandler { get; set; }

        public WebSocketUserManagerMiddleware(RequestDelegate next,
                                          WebSocketHandler webSocketHandler)
        {
            _next = next;
            _webSocketHandler = webSocketHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            //If not websocketrequest, return
            if (!context.WebSockets.IsWebSocketRequest)
                return;

            var socket = await context.WebSockets.AcceptWebSocketAsync(); //Upgrades the protocol to Websockets
            await _webSocketHandler.GetOnlineUsers(socket);
            await _webSocketHandler.OnDisconnected(socket);
        }
    }
}
