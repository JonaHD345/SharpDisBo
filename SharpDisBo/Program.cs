using SharpDisBo.Manager;

Console.WriteLine("\r\n   _____ _                      _____  _     ____        \r\n  / ____| |                    |  __ \\(_)   |  _ \\       \r\n | (___ | |__   __ _ _ __ _ __ | |  | |_ ___| |_) | ___  \r\n  \\___ \\| '_ \\ / _` | '__| '_ \\| |  | | / __|  _ < / _ \\ \r\n  ____) | | | | (_| | |  | |_) | |__| | \\__ \\ |_) | (_) |\r\n |_____/|_| |_|\\__,_|_|  | .__/|_____/|_|___/____/ \\___/ \r\n                         | |                             \r\n                         |_|                             \r\n");
Console.WriteLine("(c) by github.com/jonahd345");
Console.WriteLine(" ");
Console.WriteLine(" ");

Console.Write("Enter your token: ");
String token = Console.ReadLine();
Console.Write("To exit, press any key");
Console.WriteLine(" ");

DiscordBot discordBot = new DiscordBot(token);
await discordBot.StartBot();

Console.ReadLine();