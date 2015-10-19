using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class LeftEyeViewModel:EyeViewModel
    {
        private LeftPupilViewModel _pupil;
        private LeftBrowViewModel _eyebrow;

        public LeftEyeViewModel(IEventAggregator events, LeftPupilViewModel pupil, LeftBrowViewModel eyebrow) :base(events)
        {
            this._defaultScaleY = 0.75;
            this._defaultScaleX = 0.75;
            this._defaultY = 40;
            this._defaultX = -50;
            this.SetToDefaults();

            _pupil = pupil;
            _eyebrow = eyebrow;

            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/Eye.png", UriKind.RelativeOrAbsolute));
        }

        public LeftPupilViewModel Pupil
        {
            get { return _pupil; }
            set { SetProperty<LeftPupilViewModel>(ref _pupil, value, "Pupil"); }
        }

        public LeftBrowViewModel Eyebrow
        {
            get { return _eyebrow; }
            set { SetProperty<LeftBrowViewModel>(ref _eyebrow, value, "Eyebrow"); }
        }
    }
}
