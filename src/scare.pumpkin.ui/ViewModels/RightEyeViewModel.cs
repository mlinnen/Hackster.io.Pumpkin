using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class RightEyeViewModel:EyeViewModel
    {
        private RightPupilViewModel _pupil;
        private RightBrowViewModel _eyebrow;

        public RightEyeViewModel(IEventAggregator events, RightPupilViewModel pupil, RightBrowViewModel eyebrow) :base(events)
        {
            this.ScaleY = 0.75;
            this.ScaleX = 0.75;
            this.Y = 40;
            this.X = 50;

            _pupil = pupil;
            _eyebrow = eyebrow;

            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/Eye.png", UriKind.RelativeOrAbsolute));
        }

        public RightPupilViewModel Pupil
        {
            get { return _pupil; }
            set { SetProperty<RightPupilViewModel>(ref _pupil, value, "Pupil"); }
        }

        public RightBrowViewModel Eyebrow
        {
            get { return _eyebrow; }
            set { SetProperty<RightBrowViewModel>(ref _eyebrow, value, "Eyebrow"); }
        }
    }
}
