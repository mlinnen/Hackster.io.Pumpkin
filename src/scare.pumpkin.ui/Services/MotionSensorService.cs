using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scare.pumpkin.ui.Services
{
    public class MotionSensorService
    {
        private readonly IEventAggregator _events;
        public MotionSensorService(IEventAggregator events)
        {
            _events = events;
        }

        public void Setup()
        {

        }
    }
}
