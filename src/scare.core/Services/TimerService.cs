using Prism.Events;
using Scare.Core;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace scare.core.Services
{
    public class TimerService
    {
        private Timer _timer = null;
        private long __sequence = 0;
        private IEventAggregator _events;

        public TimerService(IEventAggregator events)
        {
            _events = events;
        }

        public void Stop()
        {
            if (_timer != null)
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
                _timer = null;
            }
        }

        public void Start()
        {
            _timer = new Timer(this.TimerCallback, null, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(500));
        }

        private void TimerCallback(object state)
        {
            if (__sequence < long.MaxValue)
            {
                __sequence++;
            }
            else
            {
                __sequence = 0;
            }

            _events.GetEvent<Events.TimerEvent>().Publish(new TimerEventArgs(__sequence));
        }

    }
}
