
using NServiceBus;

namespace MyCompanyDemo.Shipping.Backend
{
    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
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
