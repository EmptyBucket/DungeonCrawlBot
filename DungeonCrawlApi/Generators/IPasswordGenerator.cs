using System.Collections.Generic;

namespace DungeonCrawlApi.Generators
{
    public interface IPasswordGenerator
    {
        IEnumerable<string> Next();
    }
}