using Prism.Events;
using scare.pumpkin.ui.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Scare.Core.Model;

namespace scare.pumpkin.ui.ViewModels
{
    public class NoseViewModel : FaceComponentViewModel
    {
        public NoseViewModel(IEventAggregator aggregator) : base(aggregator)
        {
            this._defaultScaleY = 0.5;
            this._defaultY = 60;
            SetToDefaults();
            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/Nose.png", UriKind.RelativeOrAbsolute));
        }

        protected override void OnActionFacialCodingCommand(ActionFacialCodingEventArgs args)
        {
            // Guard against null objects
            if (args == null || args.Coding == null)
                return;
            // Look for specific actions that the pupil will react to
            var actions = args.Coding.ActionUnits.Where(o =>
                o.FacialActionCodingType == FacialActionCodingType.EntireFaceNotVisible ||
                o.FacialActionCodingType == FacialActionCodingType.EyebrowGatherer ||
                o.FacialActionCodingType == FacialActionCodingType.InnerBrowRaiser ||
                o.FacialActionCodingType == FacialActionCodingType.InnerEyebrowLowerer ||
                o.FacialActionCodingType == FacialActionCodingType.Wink ||
                o.FacialActionCodingType == FacialActionCodingType.NeutralFace);
            bool visible = true;
            foreach (var action in actions)
            {
                switch (action.FacialActionCodingType)
                {
                    case FacialActionCodingType.NeutralFace:
                        SetToDefaults();
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
