using Prism.Events;
using scare.pumpkin.ui.core.ViewModels;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scare.pumpkin.ui.ViewModels
{
    public class EyeBrowViewModel: FaceComponentViewModel
    {
        protected bool _right = false;

        public EyeBrowViewModel(IEventAggregator aggregator):base(aggregator)
        {

        }

        protected override void OnActionFacialCodingCommand(ActionFacialCodingEventArgs args)
        {
            // Guard against null objects
            if (args == null || args.Coding == null)
                return;
            // Look for specific actions that the pupil will react to
            var actions = args.Coding.ActionUnits.Where(o =>
                o.FacialActionCodingType == FacialActionCodingType.EntireFaceNotVisible ||
                o.FacialActionCodingType == FacialActionCodingType.EyesClosed ||
                o.FacialActionCodingType == FacialActionCodingType.Blink ||
                o.FacialActionCodingType == FacialActionCodingType.BrowLowerer ||
                o.FacialActionCodingType == FacialActionCodingType.BrowsAndForeheadNotVisible ||
                o.FacialActionCodingType == FacialActionCodingType.EyebrowGatherer ||
                o.FacialActionCodingType == FacialActionCodingType.InnerBrowRaiser ||
                o.FacialActionCodingType == FacialActionCodingType.InnerEyebrowLowerer ||
                o.FacialActionCodingType == FacialActionCodingType.OuterBrowRaiser ||
                o.FacialActionCodingType == FacialActionCodingType.Wink ||
                o.FacialActionCodingType == FacialActionCodingType.NeutralFace);
            bool visible = true;
            int eyeLeftRight = 0, eyeUpDown = 0;
            foreach (var action in actions)
            {
                switch (action.FacialActionCodingType)
                {
                    case FacialActionCodingType.NeutralFace:
                        SetToDefaults();
                        this.Visible = true;
                        break;
                    case FacialActionCodingType.InnerBrowRaiser:
                        if (_right)
                            this.Angle = _defaultAngle - 15;
                        else
                            this.Angle = _defaultAngle + 15;
                        break;
                    case FacialActionCodingType.EntireFaceNotVisible:
                        visible = false;
                        break;
                }
            }
            this.Visible = visible;
        }
    }
}
