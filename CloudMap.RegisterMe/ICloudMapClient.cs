using System.Threading.Tasks;

namespace CloudMap.RegisterMe
{
    public interface ICloudMapClient
    {
        Task<string> RegisterEc2Async(string serviceId, string instanceId, int port = 80);
        Task<string> RegisterEc2Async(string serviceId, int port = 80);
    }
}