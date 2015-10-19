using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class ActionCollection
    {
        public ActionCollection()
        {
            Actions = new List<Action>();
        }
        public List<Action> Actions { get; set; }
    }
}
