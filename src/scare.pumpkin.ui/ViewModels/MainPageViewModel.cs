using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scare.pumpkin.ui.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        private bool _isNavigationDisabled;

        public MainPageViewModel(
            INavigationService navService)
        {
            NavigateCommand = new DelegateCommand(() => navService.Navigate("Head", null));
            NavigateControlCommand = new DelegateCommand(() => navService.Navigate("Control", null));
        }

        public DelegateCommand NavigateCommand { get; set; }

        public DelegateCommand NavigateControlCommand { get; set; }

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
