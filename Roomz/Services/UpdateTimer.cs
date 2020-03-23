using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Roomz.Services
{
        public class TimerTest : IDisposable
        {
            private readonly Timer _timer;
            private readonly object _locker = new object();

            public TimerTest()
            {
                _timer = new Timer(new TimerCallback(TickTimer), null, 1000, 1000);
            }

            private void TickTimer(object state)
            {
                // keep GC from collecting and stopping timer;
                GC.KeepAlive(_timer);

                // do not let another tick happen if we are still doing things - https://stackoverflow.com/a/13267259/2041
                if (Monitor.TryEnter(_locker))
                {
                    try
                    {
                        // do long running work here
                        DoWork();
                    }
                    finally
                    {
                        Monitor.Exit(_locker);
                    }
                }
            }

            private void DoWork()
            {
                Console.WriteLine("Starting DoWork()");
                Thread.Sleep(2000);
                Console.WriteLine("Ending DoWork()");
            }

            public void Dispose()
            {
                _timer?.Dispose();
            }
        }
}
