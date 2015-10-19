using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.Foundation;
using Scare.Core.Model;
using scare.pumpkin.ui.core.ViewModels;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class MouthViewModel : FaceComponentViewModel
    {
        public MouthViewModel(IEventAggregator aggregator):base(aggregator)
        {
            this._defaultScaleX = 0.5;
            this._defaultScaleY = 0.5;
            SetToDefaults();

            this.Visible = false;
            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/Mouth.png", UriKind.RelativeOrAbsolute));
        }

        protected override void OnActionFacialCodingCommand(ActionFacialCodingEventArgs args)
        {
            // Gaurd against null objects
            if (args == null || args.Coding == null)
                return;
            
            // Look for specific actions that the mouth will react to
            var actions = args.Coding.ActionUnits.Where(o => 
                o.FacialActionCodingType == FacialActionCodingType.EntireFaceNotVisible || 
                o.FacialActionCodingType == FacialActionCodingType.JawDrop ||
                o.FacialActionCodingType == FacialActionCodingType.JawSideways ||
                o.FacialActionCodingType == FacialActionCodingType.LipCornerPuller ||
                o.FacialActionCodingType == FacialActionCodingType.UpperLipRaiser ||
                o.FacialActionCodingType == FacialActionCodingType.LipCornerDepressor ||
                o.FacialActionCodingType == FacialActionCodingType.LipFunneler ||
                o.FacialActionCodingType == FacialActionCodingType.NeutralFace);
            bool visible = true;
            foreach(var action in actions)
            {
                switch(action.FacialActionCodingType)
                {
                    case FacialActionCodingType.NeutralFace:
                        SetToDefaults();
                        this.Visible = true;
                        break;
                    case FacialActionCodingType.EntireFaceNotVisible:
                        visible = false;
                        break;
                    case FacialActionCodingType.JawDrop:
                        this.ScaleX = .35;
                        this.ScaleY = 1.5;
                        break;
                    case FacialActionCodingType.LipCornerPuller:
                        //this.CenterX = 50;
                        //this.CenterY = 50;
                        //this.AngleY = 20;

                        //this.CenterX2 = -50;
                        //this.CenterY2 = -50;
                        //this.AngleY2 = -20;
                        break;
                }
            }
            this.Visible = visible;
        }

    }
}
