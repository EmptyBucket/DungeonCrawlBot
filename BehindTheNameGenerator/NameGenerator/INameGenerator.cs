using System.Threading.Tasks;

namespace BehindTheNameGenerator.NameGenerator
{
    public interface INameGenerator
    {
        Task<string> GenerateAsync();
    }
}