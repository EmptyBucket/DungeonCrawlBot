using BehindTheNameGenerator.Client;
using BehindTheNameGenerator.NameGenerator;
using BehindTheNameGenerator.ParametersFactory;
using BehindTheNameGenerator.Parser;
using BehindTheNameGenerator.UrlBuilder;
using Ninject.Modules;

namespace DungeonCrawlBot.Modules
{
    public class BehindTheNameGeneratorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IParametersFactory>()
                .To<BehindTheNameParametersFactory>()
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Mythology), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.GreekMyth), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.RomanMyth), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.CelticMyth), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.NorseMyth), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Hinduism), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Ancient), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.ClassicalGreek), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.ClassicalRoman), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.AncientCeltic), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Germanic), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.AngloSaxon), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Norse), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Biblical), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.History), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Literature), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Theology), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Fairy), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Goth), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Hillbilly), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Hippy), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Kreatyve), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Rapper), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Transformer), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Witch), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Wrestler), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Fantasy), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Gluttakh), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Monstrall), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Romanto), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Simitiq), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Tsang), true)
                .WithPropertyValue(nameof(BehindTheNameParametersFactory.Xalaxxi), true);
            Bind<IUrlBuilder>()
                .To<BehindTheNameUrlBuilder>();
            Bind<IParser>()
                .To<BehindTheNameParser>();
            Bind<INameGenerator>()
                .To<BehindTheNameGenerator.NameGenerator.BehindTheNameGenerator>();
            Bind<IClientFactory>()
                .To<ProxyHttpClientFactory>();
        }
    }
}