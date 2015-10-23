using Prism.Commands;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using scare.pumpkin.ui.Services;
using Scare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Scare.Core.Model;

namespace scare.pumpkin.ui.ViewModels
{
    public class HeadPageViewModel: ViewModelBase
    {
        private readonly INavigationService _navService;
        private MouthViewModel _mouth;
        private RightEyeViewModel _rightEye;
        private LeftEyeViewModel _leftEye;
        private NoseViewModel _nose;
        private readonly MotionActivatedSimpleAnimation _animationService;
        private readonly IEventAggregator _events;
        private bool _visible;
        private ImageSource _image;
        private SubscriptionToken _actionFacialCodingEventToken = null;
        private SubscriptionToken _sensorChangedEventToken = null;
        private double _currentReading;
        private bool _showSensorReading=false;

        public HeadPageViewModel(
            IEventAggregator events,
            MouthViewModel mouth,
            RightEyeViewModel rightEye,
            LeftEyeViewModel leftEye,
            NoseViewModel nose, 
            INavigationService navService,
            MotionActivatedSimpleAnimation animation)
        {
            _events = events;
            _actionFacialCodingEventToken = _events.GetEvent<Events.ActionFacialCodingEvent>().Subscribe((args) =>
            {
                this.OnActionFacialCodingCommand(args);
            }, ThreadOption.UIThread);

            _sensorChangedEventToken = _events.GetEvent<Events.RangeSensorEvent>().Subscribe((args) =>
            {
                this.OnRangeSensorChanged(args);
            }, ThreadOption.UIThread);


            _navService = navService;
            GoBackCommand = new DelegateCommand(_navService.GoBack);
            NavigateControlCommand = new DelegateCommand(() => navService.Navigate("Control", null));
            HideCommand = new DelegateCommand(this.Hide);

            _mouth = mouth;
            _rightEye = rightEye;
            _leftEye = leftEye;
            _nose = nose;
            _animationService = animation;
            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/pumpkinbackground.png", UriKind.RelativeOrAbsolute));

        }

        private void Hide()
        {
            ShowSensorReading = !ShowSensorReading;
        }

        private bool CanHide(object arg)
        {
            return true;
        }

        public bool ShowSensorReading
        {
            get { return _showSensorReading; }
            set { SetProperty<bool>(ref _showSensorReading, value, "ShowSensorReading"); }
        }

        public bool Visible
        {
            get { return _visible; }
            set { SetProperty<bool>(ref _visible, value, "Visible"); }
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            //_animationService.StartAnimation(0);
        }

        public DelegateCommand GoBackCommand { get; set; }

        public DelegateCommand HideCommand { get; set; }

        public DelegateCommand NavigateControlCommand { get; set; }

        public MouthViewModel Mouth
        {
            get { return _mouth; }
            set { SetProperty<MouthViewModel>(ref _mouth, value, "Mouth"); }

        }

        public RightEyeViewModel RightEye
        {
            get { return _rightEye; }
            set { SetProperty<RightEyeViewModel>(ref _rightEye, value, "RightEye"); }

        }

        public LeftEyeViewModel LeftEye
        {
            get { return _leftEye; }
            set { SetProperty<LeftEyeViewModel>(ref _leftEye, value, "LeftEye"); }

        }

        public NoseViewModel Nose
        {
            get { return _nose; }
            set { SetProperty<NoseViewModel>(ref _nose, value, "Nose"); }

        }

        public ImageSource Image
        {
            get { return _image; }
            set { SetProperty<ImageSource>(ref _image, value, "Image"); }
        }

        public double CurrentReading
        {
            get { return _currentReading; }
            set { SetProperty<double>(ref _currentReading, value, "CurrentReading"); }

        }

        private bool _isNavigationDisabled;

        public bool IsNavigationDisabled
        {
            get { return _isNavigationDisabled; }
            set { SetProperty(ref _isNavigationDisabled, value); }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            e.Cancel = _isNavigationDisabled;

            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

        private void OnActionFacialCodingCommand(ActionFacialCodingEventArgs args)
        {
            // Guard against null objects
            if (args == null || args.Coding == null)
                return;
            // Look for specific actions that the head will react to
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

        private void OnRangeSensorChanged(RangeSensorEventArg args)
        {
            CurrentReading = args.NewValue;
        }


    }
}
