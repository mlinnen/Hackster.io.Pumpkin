using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scare.pumpkin.ui.ViewModels
{
    public class LeftPupilViewModel:PupilViewModel
    {
        public LeftPupilViewModel(IEventAggregator events):base(events)
        {
            _right = false;
            this.Y = 40;
            this.X = -50;
        }

    }
}
