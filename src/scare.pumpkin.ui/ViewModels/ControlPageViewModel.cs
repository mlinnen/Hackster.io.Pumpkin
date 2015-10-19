using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace scare.pumpkin.ui.ViewModels
{
    public class ControlPageViewModel: ViewModelBase
    {
        private readonly INavigationService _navService;

        public ControlPageViewModel(
            INavigationService navService)
        {
            _navService = navService;
            NavigateCommand = new DelegateCommand(() => navService.Navigate("Head", null));
            NavigateEyeControlCommand = new DelegateCommand(() => navService.Navigate("EyeControl", null));
        }

        public DelegateCommand NavigateCommand { get; set; }

        public DelegateCommand NavigateEyeControlCommand { get; set; }

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

    }
}
