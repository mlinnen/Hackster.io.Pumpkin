using System;
using System.Threading.Tasks;
using Prism.Unity.Windows;
using Windows.ApplicationModel.Activation;
using Microsoft.Practices.Unity;
using scare.pumpkin.ui.ViewModels;
using scrare.core.ui.ViewModels;
using Scare.Core.Services;
using scare.pumpkin.ui.Services;
using Scare.Core.Driver;

namespace scare.pumpkin.ui
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Head", null);
            return Task.FromResult<object>(null);

        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(MouthViewModel), typeof(MouthViewModel), true);
            RegisterTypeIfMissing(typeof(RightPupilViewModel), typeof(RightPupilViewModel), true);
            RegisterTypeIfMissing(typeof(RightEyeViewModel), typeof(RightEyeViewModel), true);
            RegisterTypeIfMissing(typeof(RightPupilViewModel), typeof(RightPupilViewModel), true);
            RegisterTypeIfMissing(typeof(RightBrowViewModel), typeof(RightBrowViewModel), true);
            RegisterTypeIfMissing(typeof(LeftEyeViewModel), typeof(LeftEyeViewModel), true);
            RegisterTypeIfMissing(typeof(LeftPupilViewModel), typeof(LeftPupilViewModel), true);
            RegisterTypeIfMissing(typeof(LeftBrowViewModel), typeof(LeftBrowViewModel), true);
            RegisterTypeIfMissing(typeof(NoseViewModel), typeof(NoseViewModel), true);
            RegisterTypeIfMissing(typeof(HeadPageViewModel), typeof(HeadPageViewModel), true);
            RegisterTypeIfMissing(typeof(EyeControlPageViewModel), typeof(EyeControlPageViewModel), true);

            Mcp3008 driver = new Mcp3008(0);
            MaxSonarRangeDriver sonarDriver = new MaxSonarRangeDriver(driver,0);
            Container.RegisterInstance<Mcp3008>(driver);
            Container.RegisterInstance<MaxSonarRangeDriver>(sonarDriver);
            RegisterTypeIfMissing(typeof(SoundService), typeof(SoundService), true);
            RegisterTypeIfMissing(typeof(TimerService), typeof(TimerService), true);
            RegisterTypeIfMissing(typeof(MaxSonarPresenceService), typeof(MaxSonarPresenceService), true);
            RegisterTypeIfMissing(typeof(MaxSonarRangeDriver), typeof(MaxSonarRangeDriver), true);

            RegisterTypeIfMissing(typeof(MotionActivatedSimpleAnimation), typeof(MotionActivatedSimpleAnimation), true);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            SetupHardware();
        }

        private void SetupHardware()
        {
            var service = Container.Resolve<MaxSonarPresenceService>();
            service.Start(60,1);
        }


    }
}
