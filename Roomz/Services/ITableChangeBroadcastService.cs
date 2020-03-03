using Roomz.Data;
using System;
using System.Collections.Generic;

namespace Roomz.Services
{
    public delegate void ScheduleChangeDelegate(object sender, ScheduleChangeEventArgs args);

    public class ScheduleChangeEventArgs : EventArgs
    {
        public Schedule NewValue { get; }
        public Schedule OldValue { get; }

        public ScheduleChangeEventArgs(Schedule newValue, Schedule oldValue)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }
    }

    public interface ITableChangeBroadcastService : IDisposable
    {
        event ScheduleChangeDelegate OnScheduleChanged;
        IList<Schedule> GetCurrentValues();
    }
}