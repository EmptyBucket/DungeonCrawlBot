namespace DungeonCrawlBot
{
    //flyweight pattern
    public class WebServerLabel
    {
        public string Url { get; }
        public string Name { get; }

        public WebServerLabel(string url, string name)
        {
            Url = url;
            Name = name;
        }
    }
}