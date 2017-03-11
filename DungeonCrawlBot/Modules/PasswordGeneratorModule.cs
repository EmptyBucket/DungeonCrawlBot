using Ninject.Modules;

namespace DungeonCrawlBot.Modules
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