﻿using System.Collections.Generic;

namespace DungeonCrawlBot.Modules
{
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