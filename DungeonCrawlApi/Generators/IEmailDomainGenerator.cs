using System.Collections.Generic;

namespace DungeonCrawlApi.Generators
{
    public interface IEmailDomainGenerator
    {
        IEnumerable<string> Next();
    }
}