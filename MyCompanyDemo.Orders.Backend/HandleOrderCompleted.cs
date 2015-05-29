using System;
using MyCompanyDemo.Messages.Events;
using NServiceBus;

namespace MyCompanyDemo.Orders.Backend
{
    public class HandleOrderCompleted : IHandleMessages<OrderCompleted>
    {
        public void Handle(OrderCompleted order)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Order Submitted: {0}.", order.DateOccurred);
            Console.WriteLine("Order Saved: {0}.", DateTime.Now);

            Console.WriteLine("SAVING ORDER {" + order.ProductId + ", " + order.CustomerId + ", $" + order.Amount + "}");
            Console.WriteLine("==========================================================================");
            Console.WriteLine(string.Empty);
        }
    }
}
