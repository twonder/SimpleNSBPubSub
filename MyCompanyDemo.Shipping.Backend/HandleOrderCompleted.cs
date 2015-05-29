using System;
using System.Threading;
using MyCompanyDemo.Messages.Events;
using NServiceBus;

namespace MyCompanyDemo.Shipping.Backend
{
    public class HandleOrderCompleted : IHandleMessages<OrderCompleted>
    {
        public void Handle(OrderCompleted order)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("==========================================================================");
            Console.WriteLine("Order Submitted: {0}.", order.DateOccurred);
            Console.WriteLine("Order Fullfilled: {0}.", DateTime.Now);

            Console.WriteLine("SENDING ORDER " + order.ProductId + " => " + order.CustomerId);
            Console.WriteLine("==========================================================================");
            Console.WriteLine(string.Empty);
        }
    }
}
