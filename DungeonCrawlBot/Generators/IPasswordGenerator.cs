using System.Collections.Generic;

namespace DungeonCrawlBot.Modules
{
    public interface IPasswordGenerator
    {
        IEnumerable<string> Next();
    }
}