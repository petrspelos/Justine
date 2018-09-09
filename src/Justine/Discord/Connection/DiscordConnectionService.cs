using System;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.Net;
using Discord.WebSocket;
using Justine.Settings;

namespace Justine.Discord.Connection
{
    public class DiscordConnectionService : ConnectionService
    {
        private readonly DiscordSocketClient discordClient;
        private readonly JustineSettings justineSettings;

        public DiscordConnectionService(JustineSettings justineSettings, DiscordSocketClient discordClient)
        {
            this.justineSettings = justineSettings;
            this.discordClient = discordClient;
            discordClient.Log += Log;
        }

        private Task Log(LogMessage arg)
        {
            System.Console.WriteLine(arg.Message);
            return Task.CompletedTask;
        }

        public async Task ConnectAsync()
        {
            await TryLoginAsync();
            await discordClient.StartAsync();
        }

        private async Task TryLoginAsync()
        {
            try
            {
                var token = justineSettings.Get(Constants.SettingKeyDiscordToken);
                await discordClient.LoginAsync(TokenType.Bot, token);
            }
            catch (HttpException e)
            {
                if(e.HttpCode == HttpStatusCode.Unauthorized)
                {
                    throw new ArgumentException("Invalid token");
                }
            }
        }
    }
}
