// See https://aka.ms/new-console-template for more information

using DotNetEnv;
using System;
using fitnessChallenge.Services;

Console.WriteLine("Welcome to the fitness bot Discord server!");

Env.Load();

var token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");
var guildId = Environment.GetEnvironmentVariable("GUILD_ID");

Console.WriteLine("This is the Token: " + token);
Console.WriteLine("This is the GuildId: " + guildId);

if(token == null) throw new Exception("Token not set");
if(guildId == null) throw new Exception("Guild Id not set");

var discordService = new DiscordService(token, ulong.Parse(guildId));
await discordService.InitDiscordBot();

await Task.Delay(-1);
