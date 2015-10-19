using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class ActionFacialCoding:Action
    {
        public ActionFacialCoding()
        {
            ActionUnits = new List<ActionUnit>();
            ActionType = ActionType.FacialCoding;
        }
        public List<ActionUnit> ActionUnits { get; set; }

    }
}
