using Discord.Interactions;

namespace fitnessChallenge.Commands;

public class MySlashModule : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("ping", "replies with pong")]
    public async Task PingAsync()
    {
        await RespondAsync("pong");
    }
}