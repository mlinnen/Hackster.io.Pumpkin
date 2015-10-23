using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Driver
{
    public interface IDoubleSensorDriver
    {
        Task<double> Read();
    }
}
