using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class RangeSensorEventArg
    {
        public RangeSensorEventArg(double newValue, double oldValue)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }
        public double NewValue { get; }
        public double OldValue { get; }
    }
}
