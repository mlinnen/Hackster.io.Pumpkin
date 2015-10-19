using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class TimerEventArgs
    {
        public TimerEventArgs(long sequence)
        {
            Sequence = sequence;
        }
        public long Sequence { get; }
        public bool IsMyInterval(TimeSpan interval) => this.Sequence % (int)(interval.TotalMilliseconds / 500d) == 0;

    }
}
