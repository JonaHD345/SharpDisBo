using SharpDisBo.Manager;
using SharpDisBo.Service;

Console.WriteLine("\r\n   _____ _                      _____  _     ____        \r\n  / ____| |                    |  __ \\(_)   |  _ \\       \r\n | (___ | |__   __ _ _ __ _ __ | |  | |_ ___| |_) | ___  \r\n  \\___ \\| '_ \\ / _` | '__| '_ \\| |  | | / __|  _ < / _ \\ \r\n  ____) | | | | (_| | |  | |_) | |__| | \\__ \\ |_) | (_) |\r\n |_____/|_| |_|\\__,_|_|  | .__/|_____/|_|___/____/ \\___/ \r\n                         | |                             \r\n                         |_|                             \r\n");
Console.WriteLine($"(c) {DateTime.Now.Year} by github.com/jonahd345");
Console.WriteLine(" ");
Console.WriteLine(" ");

RegistryService registryService = new RegistryService();
string token = registryService.GetValue(@"Software\jonahd345\SharpDisBo", "LastUsedToken");

if (token != null)
{
  Console.WriteLine("Last used token: " + token);
  bool answer = false;
  bool validAnswer = false;

  while (!validAnswer)
  {
    Console.WriteLine("Do you wan't use it? Type y for YES or n for NO");
    string answerString = Console.ReadLine();

    switch (answerString)
    {
      case "y":
        answer = true;
        validAnswer = true;
        break;
      case "n":
        answer = false;
        validAnswer = true;
        break;
    }
  }
  if (!answer)
  {
    token = null;
  }
}
if (token == null)
{
  Console.Write("Enter your token: ");
  token = Console.ReadLine();
  registryService.SetValue(@"Software\jonahd345\SharpDisBo", "LastUsedToken", token);
}
Console.WriteLine(" ");
Console.WriteLine("To exit, press any key");
Console.WriteLine(" ");
Console.WriteLine("Discord Bot log:");

DiscordBot discordBot = new DiscordBot(token);
await discordBot.StartBot();

Console.ReadLine();