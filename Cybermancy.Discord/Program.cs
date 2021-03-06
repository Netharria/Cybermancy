// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Cybermancy.Core;
using Cybermancy.Discord;
using Cybermancy.Discord.LevelingModule;
using Cybermancy.Discord.LoggingModule;
using Cybermancy.Discord.SharedModule;
using Cybermancy.Discord.Utilities;
using DSharpPlus;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.SlashCommands;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nefarius.DSharpPlus.Extensions.Hosting;
using Nefarius.DSharpPlus.Interactivity.Extensions.Hosting;
using Nefarius.DSharpPlus.SlashCommands.Extensions.Hosting;
using OpenTracing;
using OpenTracing.Mock;
using Serilog;

Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(x =>
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        x.AddConfiguration(configuration);
    })
    .ConfigureLogging((context, x) => x
        .AddSerilog(new LoggerConfiguration().WriteTo.Console().CreateLogger())
        .AddConfiguration(context.Configuration))
    .ConfigureServices((context, services) =>
        services
        .AddCoreServices(context.Configuration)
        .AddSingleton<ITracer>(provider => new MockTracer())
        .AddHttpClient()
        .AddDiscord(options =>
        {
            options.Token = context.Configuration["token"];
            options.TokenType = TokenType.Bot;

            options.AutoReconnect = true;
            options.MinimumLogLevel = LogLevel.Debug;
            options.Intents = DiscordIntents.All;
        })
        .AddDiscordInteractivity(options =>
        {
            options.PaginationBehaviour = PaginationBehaviour.WrapAround;
            options.ResponseBehavior = InteractionResponseBehavior.Ack;
            options.ResponseMessage = "That's not a valid button";
            options.Timeout = TimeSpan.FromMinutes(2);
            options.PaginationDeletion = PaginationDeletion.DeleteMessage;
            options.AckPaginationButtons = true;
        })
        .AddDiscordSlashCommands(
            x =>
            {
                if (x is not SlashCommandsConfiguration config) return;
                //Enables dependancy injection for commands
                config.Services = services.BuildServiceProvider();
            },
            x =>
            {
                if (x is not SlashCommandsExtension extension) return;
                extension.RegisterCommands<ExampleSlashCommand>(ulong.Parse(context.Configuration["guildId"]));
                extension.RegisterCommands<EmptySlashCommands>();
                extension.RegisterCommands<LevelCommands>(ulong.Parse(context.Configuration["guildId"]));
                extension.RegisterCommands<LeaderboardCommands>(ulong.Parse(context.Configuration["guildId"]));
                extension.RegisterCommands<LevelSettingsCommands>(ulong.Parse(context.Configuration["guildId"]));
                extension.RegisterCommands<LevelingAdminCommands>(ulong.Parse(context.Configuration["guildId"]));
                extension.RegisterCommands<RewardCommands>(ulong.Parse(context.Configuration["guildId"]));
                extension.RegisterCommands<LogSettingsCommands>(ulong.Parse(context.Configuration["guildId"]));
                extension.RegisterCommands<ModuleCommands>(ulong.Parse(context.Configuration["guildId"]));
            })
        .AddDiscordHostedService()
        .AddMediatR(Assembly.GetExecutingAssembly())
        .AddHostedService<TickerBackgroundService>()
        .BuildServiceProvider()
    )
    .UseConsoleLifetime()
    .Build()
    .Run();
