using System;
using System.Threading.Tasks;

namespace BehindTheNameGenerator.Client
{
    public interface IClient
    {
        Task<string> GetResultAsync(Uri url);
    }
}