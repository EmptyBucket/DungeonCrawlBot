using DungeonCrawlApi.Generators;
using Ninject.Modules;

namespace DungeonCrawlApi.Modules
{
    public class PasswordGeneratorModule : NinjectModule
    {
        public override void Load()
        {
            var passwordGeneratorSettings = new PasswordGeneratorSettings(true, false, true, false, 8, 3, false);
            Bind<PasswordGenerator>()
                .ToSelf()
                .WithConstructorArgument(passwordGeneratorSettings);
            Bind<IPasswordGenerator>()
                .To<PasswordGeneratorAdapter>();
        }
    }
}