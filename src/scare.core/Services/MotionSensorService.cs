using Prism.Events;
using Scare.Core;
using Scare.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Scare.Core.Services
{
    public class MotionSensorService
    {
        private readonly IEventAggregator _events;
        private GpioController _gpio;
        private GpioPin _gpioPin;
        private int _motionId;

        public MotionSensorService(IEventAggregator events)
        {
            _events = events;
        }

        public void Setup(int pin,int motionId)
        {
            _motionId = motionId;
            if (!ConnectGPIO())
                return; // GPIO not available on this system
            _gpioPin = _gpio.OpenPin(pin);
            _gpioPin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            _gpioPin.ValueChanged += GpioPin_ValueChanged;
        }

        private bool ConnectGPIO()
        {
            try
            {
                _gpio = GpioController.GetDefault();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void GpioPin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            if (args.Edge== GpioPinEdge.FallingEdge)
            {
                _events.GetEvent<Events.MotionEvent>().Publish(new MotionTriggeredArgs(_motionId));
            }
        }
    }
}
