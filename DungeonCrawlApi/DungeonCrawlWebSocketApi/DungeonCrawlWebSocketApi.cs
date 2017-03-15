using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClientWebSocket = System.Net.WebSockets.Managed.ClientWebSocket;

namespace DungeonCrawlApi.DungeonCrawlWebSocketApi
{
    public class DungeonCrawlWebSocketApi : IDungeonCrawlApi
    {
        private readonly ClientWebSocket _clientWebSocket;

        public DungeonCrawlWebSocketApi()
        {
            _clientWebSocket = new ClientWebSocket();
        }

        private async Task SendSocketMessage(string json)
        {
            var bytes = Encoding.UTF8.GetBytes(json);
            var arraySegment = new ArraySegment<byte>(bytes);
            await _clientWebSocket.SendAsync(arraySegment, WebSocketMessageType.Binary, true, CancellationToken.None)
                .ConfigureAwait(false);
        }

        public async Task ConnectAsync(string socketServer) =>
            await _clientWebSocket.ConnectAsync(new Uri(socketServer), CancellationToken.None)
                .ConfigureAwait(false);

        public async Task WatchAsync(string username)
        {
            var serializeObject = JsonConvert.SerializeObject(new
            {
                username,
                msg = "watch"
            });
            await SendSocketMessage(serializeObject)
                .ConfigureAwait(false);
        }

        public async Task RegisterAsync(string username, string password, string email)
        {
            var serializeObject = JsonConvert.SerializeObject(new
            {
                username, password, email,
                msg = "register"
            });
            await SendSocketMessage(serializeObject)
                .ConfigureAwait(false);
        }

        public async Task LoginAsync(string username, string password)
        {
            var serializeObject = JsonConvert.SerializeObject(new
            {
                username, password,
                msg = "login"
            });
            await SendSocketMessage(serializeObject)
                .ConfigureAwait(false);
        }

        public async Task SendMessageAsync(string message)
        {
            var serializeObject = JsonConvert.SerializeObject(new
            {
                msg = "chat_msg",
                text = message
            });
            await SendSocketMessage(serializeObject)
                .ConfigureAwait(false);
        }

        public async Task GoLobby()
        {
            var serializeObject = JsonConvert.SerializeObject(new
            {
                msg = "go_lobby"
            });
            await SendSocketMessage(serializeObject)
                .ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (_clientWebSocket.State == WebSocketState.Open)
                _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            _clientWebSocket.Dispose();
        }

        public IWebProxy Proxy
        {
            get => _clientWebSocket.Options.Proxy;
            set => _clientWebSocket.Options.Proxy = value;
        }
    }
}