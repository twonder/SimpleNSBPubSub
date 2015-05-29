
using NServiceBus;

namespace MyCompanyDemo.Orders.Backend
{
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseSerialization<JsonSerializer>();
            configuration.UsePersistence<InMemoryPersistence>();

            // configure message definitions
            configuration.Conventions().DefiningCommandsAs(e => e.Namespace != null & e.Namespace.EndsWith("Commands"));
            configuration.Conventions().DefiningEventsAs(e => e.Namespace != null & e.Namespace.EndsWith("Events"));
        }
    }
}
