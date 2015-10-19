using Prism.Events;
using Prism.Mvvm;
using Scare.Core;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace scare.pumpkin.ui.core.ViewModels
{
    public class FaceComponentViewModel: BindableBase
    {
        private SubscriptionToken _actionFacialCodingEventToken = null;
        protected readonly IEventAggregator _events;
        private int _angle=0;
        protected int _defaultAngle=0;
        private double _scaleX = 1, _scaleY = 1, _angleX = 0, _angleY = 0, _x=0, _y=0;
        protected double _defaultScaleX = 1, _defaultScaleY = 1, _defaultAngleX = 0, _defaultAngleY = 0, _defaultX = 0, _defaultY = 0;
        private bool _visible;
        private ImageSource _image;

        public FaceComponentViewModel(IEventAggregator aggregator)
        {
            _events = aggregator;

            _actionFacialCodingEventToken = _events.GetEvent<Events.ActionFacialCodingEvent>().Subscribe((args) =>
            {
                this.OnActionFacialCodingCommand(args);
            }, ThreadOption.UIThread);

        }

        public ImageSource Image
        {
            get { return _image; }
            set { SetProperty<ImageSource>(ref _image, value, "Image"); }
        }

        public int Angle
        {
            get { return _angle; }
            set { SetProperty<int>(ref _angle, value, "Angle"); }
        }

        public double ScaleX
        {
            get { return _scaleX; }
            set { SetProperty<double>(ref _scaleX, value, "ScaleX"); }
        }

        public double ScaleY
        {
            get { return _scaleY; }
            set { SetProperty<double>(ref _scaleY, value, "ScaleY"); }
        }

        public bool Visible
        {
            get { return _visible; }
            set { SetProperty<bool>(ref _visible, value, "Visible"); }
        }

        public double AngleX
        {
            get { return _angleX; }
            set { SetProperty<double>(ref _angleX, value, "AngleX"); }
        }

        public double AngleY
        {
            get { return _angleY; }
            set { SetProperty<double>(ref _angleY, value, "AngleY"); }
        }

        public double X
        {
            get { return _x; }
            set { SetProperty<double>(ref _x, value, "X"); }
        }

        public double Y
        {
            get { return _y; }
            set { SetProperty<double>(ref _y, value, "Y");}
        }

        protected virtual void OnActionFacialCodingCommand(ActionFacialCodingEventArgs args)
        {

        }

        protected void SetToDefaults()
        {
            this.X = _defaultX;
            this.Y = _defaultY;
            this.ScaleX = _defaultScaleX;
            this.ScaleY = _defaultScaleY;
            this.AngleX = _defaultAngleX;
            this.AngleY = _defaultAngleY;
            this.Angle = _defaultAngle;
        }
    }
}
