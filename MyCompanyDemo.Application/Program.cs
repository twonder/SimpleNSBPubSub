using System;
using MyCompanyDemo.Messages.Events;
using NServiceBus;
using NServiceBus.Persistence;

namespace MyCompanyDemo.Application
{
    static class Program
    {
        private static string customerId;
        static void Main()
        {
            // configure the bus
            var busConfiguration = new BusConfiguration();
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<RavenDBPersistence>();
            busConfiguration.Conventions().DefiningCommandsAs(e => e.Namespace != null & e.Namespace.EndsWith("Commands"));
            busConfiguration.Conventions().DefiningEventsAs(e => e.Namespace != null & e.Namespace.EndsWith("Events"));

            // start the bus
            var startableBus = Bus.Create(busConfiguration);
            using (var bus = startableBus.Start())
            {
                Start(bus);
            }
        }

        static void Start(IBus bus)
        {
            PrintInstructions();
            var line = "";
            while (line != null)
            {
                line = Console.ReadLine();

                try
                {
                    var pieces = line.Split(':');
                    var actionEntered = pieces[0];

                    switch (actionEntered)
                    {
                        case "Login":
                            customerId = pieces[1];

                            Console.WriteLine("===> Logged in");

                            break;
                        case "CreateOrder":
                            // assuming some sort of order validation is successful
                            var orderId = Guid.NewGuid().ToString();
                            bus.Publish<OrderCompleted>(o =>
                            {
                                o.DateOccurred = DateTime.Now;
                                o.OrderId = orderId;
                                o.CustomerId = customerId;
                                o.ProductId = pieces[1];
                                o.Amount = Convert.ToDouble(pieces[2]);
                            });

                            Console.WriteLine("===> Order Completed");

                            break;
                        default:
                            Console.WriteLine("===> Unrecognized Action");
                            continue;
                    }
                }
                catch (Exception e)
                {
                    continue;
                }

                Console.WriteLine("==========================================================================");
                PrintInstructions();
            }
        }

        static void PrintInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Here are the list of actions you can run:");
            Console.WriteLine("Login:customerId");
            Console.WriteLine("CreateOrder:productId:amount (assumes prior login)");
        }
    }
}

