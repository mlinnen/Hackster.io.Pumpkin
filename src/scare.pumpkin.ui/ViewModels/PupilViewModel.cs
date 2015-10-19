using Prism.Events;
using scare.pumpkin.ui.core.ViewModels;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class PupilViewModel : FaceComponentViewModel
    {
        protected bool _right = false;

        public PupilViewModel(IEventAggregator aggregator):base(aggregator)
        {
            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/Pupil.png", UriKind.RelativeOrAbsolute));
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
                o.FacialActionCodingType == FacialActionCodingType.EyesDown ||
                o.FacialActionCodingType == FacialActionCodingType.EyesNotVisible ||
                o.FacialActionCodingType == FacialActionCodingType.EyesTurnLeft ||
                o.FacialActionCodingType == FacialActionCodingType.EyesTurnRight ||
                o.FacialActionCodingType == FacialActionCodingType.EyesUp ||
                o.FacialActionCodingType == FacialActionCodingType.CrossEye ||
                o.FacialActionCodingType == FacialActionCodingType.Walleye ||
                o.FacialActionCodingType == FacialActionCodingType.NeutralFace);
            bool visible = true;
            int eyeLeftRight=0,eyeUpDown=0;

            foreach (var action in actions)
            {
                switch (action.FacialActionCodingType)
                {
                    case FacialActionCodingType.NeutralFace:
                        SetToDefaults();
                        break;
                    case FacialActionCodingType.EntireFaceNotVisible:
                        visible = false;
                        break;
                    case FacialActionCodingType.EyesTurnLeft:
                        eyeLeftRight = 1;
                        break;
                    case FacialActionCodingType.EyesTurnRight:
                        eyeLeftRight = -1;
                        break;
                    case FacialActionCodingType.EyesUp:
                        eyeUpDown = 1;
                        break;
                    case FacialActionCodingType.EyesDown:
                        eyeUpDown = -1;
                        break;
                    case FacialActionCodingType.CrossEye:
                        eyeUpDown = 1;
                        if (_right)
                            eyeLeftRight = 1;
                        else
                            eyeLeftRight = -1;
                        break;
                    case FacialActionCodingType.Walleye:
                        eyeUpDown = 1;
                        if (_right)
                            eyeLeftRight = -1;
                        else
                            eyeLeftRight = 1;
                        break;
                }
            }
            if (eyeUpDown==0 && eyeLeftRight ==0)
            {
                X = this._defaultX;
                Y = this._defaultY;
            }
            else if (eyeUpDown > 0 && eyeLeftRight == 0)
            {
                X = this._defaultX;
                Y = this._defaultY + 30;
            }
            else if (eyeUpDown < 0 && eyeLeftRight == 0)
            {
                X = this._defaultX;
                Y = this._defaultY - 30;
            }
            else if (eyeUpDown== 0 && eyeLeftRight > 0)
            {
                X = this._defaultX + 30;
                Y = this._defaultY;
            }
            else if (eyeUpDown == 0 && eyeLeftRight < 0)
            {
                X = this._defaultX -30;
                Y = this._defaultY;
            }
            else if (eyeUpDown > 0 && eyeLeftRight > 0)
            {
                X = this._defaultX + 40;
                Y = this._defaultY + 30;
            }
            else if (eyeUpDown > 0 && eyeLeftRight < 0)
            {
                X = this._defaultX -40;
                Y = this._defaultY + 30;
            }
            else if (eyeUpDown < 0 && eyeLeftRight > 0)
            {
                X = this._defaultX + 20;
                Y = this._defaultY  - 30;
            }
            else if (eyeUpDown < 0 && eyeLeftRight < 0)
            {
                X = this._defaultX -20;
                Y = this._defaultY - 30;
            }
            this.Visible = visible;
        }

    }
}
