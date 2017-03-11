using System.Collections.Generic;
using System.Linq;

namespace DungeonCrawlBot.DungeonCrawlBotBrowserEmulator
{
    public class CommandParams : Dictionary<string, string>
    {
        public override string ToString() =>
            string.Join(",", this.Select(pair => $"{pair.Key}: '{pair.Value}'"));
    }
}