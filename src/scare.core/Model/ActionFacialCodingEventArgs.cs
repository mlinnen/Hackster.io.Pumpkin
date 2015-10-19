using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class ActionFacialCodingEventArgs
    {
        public ActionFacialCodingEventArgs(ActionFacialCoding coding)
        {
            Coding = coding;
        }
        public ActionFacialCoding Coding { get; set; }
    }
}
