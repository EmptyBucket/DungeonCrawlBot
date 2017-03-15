namespace BehindTheNameGenerator.Client
{
    //abstract factory pattern
    public interface IClientFactory
    {
        IClient Factory();
    }
}