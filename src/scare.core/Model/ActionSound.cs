using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class ActionSound:Action
    {
        public ActionSound()
        {
            ActionType = ActionType.Sound;
        }
        public string FileName { get; set; }
        public int Channel { get; set; }

    }
}
