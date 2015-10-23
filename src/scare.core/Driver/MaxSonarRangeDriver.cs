using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Driver
{
    public class MaxSonarRangeDriver : IDoubleSensorDriver
    {
        private readonly Mcp3008 _spiDriver;
        int _port; // 0 thru 7
        const double VOLTS_PER_INCH = 0.009766;
        private double[] _sensorReadings = new double[10];
        private int _index = 0;
        private int _totalReadings = 0;
        private double _total;

        public MaxSonarRangeDriver(Mcp3008 spiDriver, int port)
        {
            if (port < 0 || port > 7)
                throw new ArgumentException("The port must be 0 - 7");
            _spiDriver = spiDriver;
            _port = port;

        }

        public async Task<double> Read()
        {
            double value = 0.0;
            if (!_spiDriver.Connected)
                await _spiDriver.Connect();

            value = _spiDriver.Read(_port);
            // Convert the raw value into a voltage
            double voltage = (value / 1024.0 * 5.0);
            // Convert the voltage into range
            double distance = voltage / VOLTS_PER_INCH;

            distance = Smooth(distance);
            return distance;
        }

        private double Smooth(double newValue)
        {
            double returnValue = 0;
            _total = _total - _sensorReadings[_index];
            _sensorReadings[_index] = newValue;
            _total = _total + _sensorReadings[_index];
            _index++;
            _totalReadings++;
            if (_index >= 10)
                _index = 0;
            if (_totalReadings >= 10)
                _totalReadings = 10;
            returnValue = _total / _totalReadings;
            return returnValue;
        }

    }
}
