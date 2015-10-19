using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scare.pumpkin.ui.ViewModels
{
    public class RightPupilViewModel:PupilViewModel
    {
        public RightPupilViewModel(IEventAggregator events):base(events)
        {
            _right = true;
            this._defaultY = 40;
            this._defaultX = 50;
            this.SetToDefaults();
        }
    }
}
