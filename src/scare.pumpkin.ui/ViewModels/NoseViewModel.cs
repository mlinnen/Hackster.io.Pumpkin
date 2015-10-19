using Prism.Events;
using scare.pumpkin.ui.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class NoseViewModel : FaceComponentViewModel
    {
        public NoseViewModel(IEventAggregator aggregator) : base(aggregator)
        {
            this.ScaleY = 0.5;
            this.Y = 60;
            Image = new BitmapImage(new Uri(@"ms-appx:///Assets/Nose.png", UriKind.RelativeOrAbsolute));
        }
    }
}
