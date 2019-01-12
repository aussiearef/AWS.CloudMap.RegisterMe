using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using Amazon.Util;
using CloudMap.RegisterMe.Exceptions;

namespace CloudMap.RegisterMe
{
    public class CloudMapClient : ICloudMapClient
    {

        public async Task<string> RegisterEc2Async(string serviceId, int port = 80)
        {
            return await RegisterEc2Async(serviceId, EC2InstanceMetadata.InstanceId, port);
        }

        
        public async Task<string> RegisterEc2Async(string serviceId, string instanceId, int port = 80)
        {
            const string ipv4Key = "AWS_INSTANCE_IPV4";
            const string portKey = "AWS_INSTANCE_PORT";

            if (string.IsNullOrEmpty(EC2InstanceMetadata.InstanceId)) throw new InvalidEnvironmentException();

            var ipV4 = EC2InstanceMetadata.PrivateIpAddress;

            var serviceClient = new AmazonServiceDiscoveryClient
            (
                new InstanceProfileAWSCredentials(),
                EC2InstanceMetadata.Region
            );

            var registerResponse = await serviceClient.RegisterInstanceAsync(new RegisterInstanceRequest
            {
                InstanceId = instanceId,
                ServiceId = serviceId,
                Attributes = new Dictionary<string, string> {{ipv4Key, ipV4}, {portKey, port.ToString()}}
            });

            return registerResponse.OperationId;
        }
    }
}