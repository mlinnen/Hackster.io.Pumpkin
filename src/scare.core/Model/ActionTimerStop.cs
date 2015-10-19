using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class ActionTimerStop:Action
    {
        public ActionTimerStop()
        {
            ActionType = ActionType.TimerStop;
        }
    }
}
