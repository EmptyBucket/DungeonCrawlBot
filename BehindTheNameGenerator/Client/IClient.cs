using System;
using System.Threading.Tasks;

namespace BehindTheNameGenerator
{
    public interface IClient
    {
        Task<string> GetResultAsync(Uri url);
    }
}