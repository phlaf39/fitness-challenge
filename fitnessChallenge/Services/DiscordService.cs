using System.Reflection;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace fitnessChallenge.Services;

public class DiscordService(string tokenKey, ulong guildId)
{
    private static DiscordSocketClient? _client;
    private static int lightWeightCounter;
    private static InteractionService _interactionService;
    // private static Command
    public async Task InitDiscordBot()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;
        await _client.LoginAsync(TokenType.Bot, tokenKey);
        await _client.StartAsync();
        _client.MessageReceived += MessageReceived;
        _client.Ready += ClientReady;
    }

    private async Task ClientReady()
    {
        // _interactionService = new InteractionService(_client);
        // await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        // await _interactionService.RegisterCommandsToGuildAsync(guildId); // or RegisterCommandsGloballyAsync()
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
    
    private async Task MessageReceived(SocketMessage message)
    {
        // Ignore messages from other bots or system messages
        if (message.Author.IsBot || message.Source != MessageSource.User)
            return;
        if ((lightWeightCounter % 3) == 0)
        {
            await message.Channel.SendMessageAsync("Fucking light weight looser");
        }
        else if (message.Content == "!ping")
        {
            await message.Channel.SendMessageAsync("Pong!");
        }
        else
        {
            await message.Channel.SendMessageAsync("Go exercice");
        }
        lightWeightCounter++;
    }
}