using Prism.Events;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core
{
    public class Events 
    {
        public class TimerEvent : PubSubEvent<TimerEventArgs> { }
        public class ActionFacialCodingEvent : PubSubEvent<ActionFacialCodingEventArgs> { }
        public class SoundEvent : PubSubEvent<SoundEventArgs> { }
    }
}
