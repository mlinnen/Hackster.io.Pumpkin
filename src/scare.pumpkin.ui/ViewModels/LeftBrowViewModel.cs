using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class LeftBrowViewModel:EyeBrowViewModel
    {
        public LeftBrowViewModel(IEventAggregator events):base(events)
        {
            this.ScaleX = 0.5;
            this.ScaleY = 0.5;
            this.Y = -40;
            this.X = -60;

            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/BrowLeft.png", UriKind.RelativeOrAbsolute));

        }
    }
}
