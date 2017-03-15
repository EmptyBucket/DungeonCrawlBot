using DungeonCrawlApi.Generators;
using Ninject.Modules;

namespace DungeonCrawlApi.Modules
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