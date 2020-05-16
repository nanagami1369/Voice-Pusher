﻿using CommonLibrary.Modules.StatusModule;

namespace CoreUILibrary.Moc
{
	class TestStatusSender : IStatusSender
	{
		public Status SendedMessage { get; private set; }

		public void Send(StatusLevel level, string message)
		{
			SendedMessage = new Status(level, message);
		}
	}
}