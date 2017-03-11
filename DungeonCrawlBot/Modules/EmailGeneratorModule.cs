using Ninject.Modules;

namespace DungeonCrawlBot.Modules
{
    public class EmailGeneratorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmailDomainGenerator>()
                .To<RandomEmailDomainGenerator>();
        }
    }
}