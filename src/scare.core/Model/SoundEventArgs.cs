using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class SoundEventArgs
    {
        public SoundEventArgs(int channel, string fileName)
        {
            Channel = channel;
            FileName = fileName;
        }
        public int Channel { get; }
        public string FileName { get; }

    }
}
