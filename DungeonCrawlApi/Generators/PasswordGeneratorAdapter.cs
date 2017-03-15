using System.Collections.Generic;

namespace DungeonCrawlApi.Generators
{
    //adapter pattern
    public class PasswordGeneratorAdapter : IPasswordGenerator
    {
        private readonly PasswordGenerator _generator;

        public PasswordGeneratorAdapter(PasswordGenerator generator)
        {
            _generator = generator;
        }

        public IEnumerable<string> Next()
        {
            yield return _generator.Next();
        }
    }
}