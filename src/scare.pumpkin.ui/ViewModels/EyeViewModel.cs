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
    public class EyeViewModel : FaceComponentViewModel
    {

        public EyeViewModel(IEventAggregator aggregator):base(aggregator)
        {

        }

        protected override void OnActionFacialCodingCommand(ActionFacialCodingEventArgs args)
        {
            // Gaurd against null objects
            if (args == null || args.Coding == null)
                return;

            // Look for specific actions that the eye will react to
            var actions = args.Coding.ActionUnits.Where(o =>
                o.FacialActionCodingType == FacialActionCodingType.EntireFaceNotVisible ||
                o.FacialActionCodingType == FacialActionCodingType.NeutralFace);
            bool visible = true;
            foreach (var action in actions)
            {
                switch (action.FacialActionCodingType)
                {
                    case FacialActionCodingType.NeutralFace:
                        this.Visible = true;
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
