using System.Collections.Generic;

namespace DungeonCrawlBot
{
    public interface IEmailDomainGenerator
    {
        IEnumerable<string> Next();
    }
}