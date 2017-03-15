namespace DungeonCrawlBot
{
    //flyweight pattern
    public static class DungeonCrawlServerLabels
    {
        public static WebServerLabel Project357 { get; } =
            new WebServerLabel("wss://crawl.project357.org/socket", "Project357");
        public static WebServerLabel Akrasiac { get; } =
            new WebServerLabel("ws://crawl.akrasiac.org:8080/socket", "Akrasiac");
        public static WebServerLabel Berotato { get; } =
            new WebServerLabel("ws://crawl.berotato.org:8080/socket", "Berotato");
        public static WebServerLabel Xtahua { get; } =
            new WebServerLabel("ws://crawl.xtahua.com:8080/socket", "Xtahua");
        public static WebServerLabel Underhound { get; } =
            new WebServerLabel("ws://underhound.eu/socket", "Underhound");
        public static WebServerLabel Webzook { get; } =
            new WebServerLabel("ws://webzook.net/socket", "Webzook");
        public static WebServerLabel LazyLife { get; } =
            new WebServerLabel("ws://lazy-life.ddo.jp/socket", "LazyLife");
        public static WebServerLabel Jorgun { get; } =
            new WebServerLabel("ws://crawl.jorgrun.rocks/socket", "Jorgun");
    }
}