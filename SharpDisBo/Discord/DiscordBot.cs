using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using SharpDisBo.Discord.Handler;

namespace SharpDisBo.Manager
{
  public class DiscordBot
  {
    private DiscordSocketClient _client;

    private String _token;

    public DiscordBot(String token)
    {
      this._token = token;
    }

    public async Task StartBot()
    {
      this._client = new DiscordSocketClient();
      this._client.Log += this.Log;

      this._client.Ready += Client_Ready;
      this._client.SlashCommandExecuted += SlashCommandHandler.OnSlashCommand;

      await _client.LoginAsync(TokenType.Bot, this._token);
      await _client.StartAsync();
    }

    public async Task StopBot()
    {
      await _client.LogoutAsync();
      await _client.StopAsync();
    }

    public async Task Client_Ready()
    {
      await _client.SetActivityAsync(new Game("github.com/jonahd345", ActivityType.Watching));

      SlashCommandBuilder globalCommand = new SlashCommandBuilder();
      globalCommand.WithName("hello");
      globalCommand.WithDescription("This is the hello command");

      try
      {
        await this._client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
      }
      catch (HttpException exception)
      {
        string json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
        Console.WriteLine(json);
      }
    }

    private Task Log(LogMessage msg)
    {
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    }
  }
}
