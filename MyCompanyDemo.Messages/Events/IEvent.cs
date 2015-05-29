using System;

namespace MyCompanyDemo.Messages.Events
{
    public interface IEvent
    {
        DateTime DateOccurred { get; set; }
    }
}
