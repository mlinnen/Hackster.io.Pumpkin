using Prism.Events;
using Scare.Core.Driver;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.I2c;

namespace Scare.Core.Services
{
    public class MaxSonarPresenceService
    {
        private readonly IEventAggregator _events;
        private readonly MaxSonarRangeDriver _rangeDriver;
        private int _animationId;
        private double _threshold = double.MaxValue;
        private Timer _timer = null;
        private int _pollMilliseconds = 250;

        public MaxSonarPresenceService(IEventAggregator events,MaxSonarRangeDriver rangeDriver)
        {
            _events = events;
            _rangeDriver = rangeDriver;

        }

        public void Start(double threshold, int annimationId)
        {
            _threshold = threshold;
            _animationId = annimationId;
            if (_timer == null)
            {
                _timer = new Timer(tick, null, TimeSpan.FromMilliseconds(_pollMilliseconds), TimeSpan.FromMilliseconds(_pollMilliseconds));
            }
            else
            {
                _timer.Change(TimeSpan.FromMilliseconds(_pollMilliseconds), TimeSpan.FromMilliseconds(_pollMilliseconds));
            }
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private async void tick(object state)
        {
            Stop();
            double inches = await _rangeDriver.Read();
            if (inches < _threshold)
            {
                _events.GetEvent<Events.PressenceEvent>().Publish(new PressenceTriggeredArgs(_animationId));
            }
            Start(_threshold, _animationId);
        }
    }
}
