namespace CloudMap.RegisterMe.Extensions
{
    public class CloudMapRegistrationOptions
    {
        public int Port { get; set; } = 80;
        public string ServiceId { get; set; }
        public string InstanceId { get; set; }
    }
}