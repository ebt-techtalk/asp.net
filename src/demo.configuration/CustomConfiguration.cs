namespace demo.configuration 
{
    class CustomConfiguration
    {
        public ServiceClientConfiguration ServiceClient { get; set; }

        public ServiceBusConfiguration ServiceBus { get; set; }

        public class ServiceBusConfiguration
        {
            public string Endpoint { get; set; }
            public string SharedAccessKeyName { get; set; }
            public string SharedAccessKeyValue { get; set; }
        }

        public class ServiceClientConfiguration
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
        }
    }
}