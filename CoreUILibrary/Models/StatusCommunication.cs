using System;
using CommonLibrary.Modules.StatusModule;
using CommonUILibrary;
using Prism.Events;

namespace CoreUILibrary.Models
{
    public class StatusCommunication : IStatusSender
    {
        private readonly IEventAggregator _eventAggregator;
        public void Send(StatusLevel level, string message)
        {
            var status = new Status(level, message);
            _eventAggregator.GetEvent<StatusEvent>().Publish(status);
        }

        public void Receive(Action<Status> outPutStatus)
        {
            _eventAggregator.GetEvent<StatusEvent>().Subscribe(outPutStatus, ThreadOption.PublisherThread, true);
        }

        public StatusCommunication(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}
