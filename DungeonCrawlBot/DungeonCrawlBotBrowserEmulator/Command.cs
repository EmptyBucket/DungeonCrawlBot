namespace DungeonCrawlBot.DungeonCrawlBotBrowserEmulator
{
    public class Command
    {
        public string CommandName { get; set; }

        public CommandParams CommandParams { get; set; }

        public override string ToString() =>
            $"require(['comm'], function(comm) {{ comm.send_message('{CommandName}', {{{CommandParams}}}); }});";

        public static Command Register => new Command
        {
            CommandName = "register",
            CommandParams = new CommandParams
            {
                {"username", ""},
                {"password", ""},
                {"email", ""}
            }
        };

        public static Command Login => new Command
        {
            CommandName = "login",
            CommandParams = new CommandParams
            {
                {"username", ""},
                {"password", ""}
            }
        };

        public static Command SendMessage => new Command
        {
            CommandName = "chat_msg",
            CommandParams = new CommandParams
            {
                {"text", ""}
            }
        };
    }
}