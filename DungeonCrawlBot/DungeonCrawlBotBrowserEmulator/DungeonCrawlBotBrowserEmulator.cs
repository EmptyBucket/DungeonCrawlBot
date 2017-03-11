using System;
using System.Threading;
using WatiN.Core;

namespace DungeonCrawlBot.DungeonCrawlBotBrowserEmulator
{
    public static class DungeonCrawlBotBrowserEmulator
    {
        public static void Start()
        {
            const string host = "arcanemastermind";
            var url = $"http://crawl.akrasiac.org:8080/#watch-{host}";

            var thread = new Thread(() =>
            {
                var ie = new IE(url) {Visible = false, AutoClose = true};
                while (true)
                {
                    var enteredKeys = Console.ReadLine();
                    if (enteredKeys == "register")
                    {
                        var registerCommand = Command.Register;
                        registerCommand.CommandParams["username"] = Console.ReadLine();
                        registerCommand.CommandParams["password"] = Console.ReadLine();
                        registerCommand.CommandParams["email"] = Console.ReadLine();
                        var registerScript = registerCommand.ToString();
                        ie.RunScript(registerScript);
                    }
                    else if (enteredKeys == "login")
                    {
                        var loginCommand = Command.Login;
                        loginCommand.CommandParams["username"] = Console.ReadLine();
                        loginCommand.CommandParams["password"] = Console.ReadLine();
                        var loginScript = loginCommand.ToString();
                        ie.RunScript(loginScript);
                    }
                    else if (enteredKeys == "send")
                    {
                        var sendMessage = Command.SendMessage;
                        sendMessage.CommandParams["text"] = Console.ReadLine();
                        var sendScript = sendMessage.ToString();
                        ie.RunScript(sendScript);
                    }
                    else if (enteredKeys == "exit")
                    {
                        ie.Dispose();
                        break;
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}