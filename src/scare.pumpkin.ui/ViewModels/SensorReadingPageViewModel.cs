using Prism.Events;
using Prism.Windows.Mvvm;
using Scare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scare.Core.Model;

namespace scare.pumpkin.ui.ViewModels
{
    public class SensorReadingPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _events;
        private SubscriptionToken _sensorEventToken = null;
        private double _currentReading;

        public SensorReadingPageViewModel(IEventAggregator events)
        {
            _events = events;
            _sensorEventToken = _events.GetEvent<Events.RangeSensorEvent>().Subscribe((args) =>
            {
                this.OnSensorChanged(args);
            }, ThreadOption.UIThread);
        }

        public double CurrentReading
        {
            get { return _currentReading; }
            set { SetProperty<double>(ref _currentReading, value, "CurrentReading"); }
        }
        private void OnSensorChanged(RangeSensorEventArg args)
        {
            CurrentReading = args.NewValue;
        }
    }
}
