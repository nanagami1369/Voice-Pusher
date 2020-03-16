using CommonUILibrary;
using Prism.Events;
using System;

namespace CommonLibrary
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
