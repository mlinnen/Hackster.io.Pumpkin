using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class RightBrowViewModel:EyeBrowViewModel
    {
        public RightBrowViewModel(IEventAggregator events):base(events)
        {
            this._defaultScaleY = 0.5;
            this._defaultScaleX = 0.5;
            this._defaultY = -40;
            this._defaultX = 60;
            this._defaultAngle = -10;
            this.SetToDefaults();

            this._right = true;

            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/BrowRight.png", UriKind.RelativeOrAbsolute));

        }
    }
}
