using System.Threading.Tasks;

namespace BehindTheNameGenerator
{
    public interface INameGenerator
    {
        Task<string> GenerateAsync();
    }
}