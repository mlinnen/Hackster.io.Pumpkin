﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scare.Core.Model
{
    public class MotionTriggeredArgs
    {
        public MotionTriggeredArgs(int id)
        {
            Id = id;
        }
        public int Id { get; }

    }
}
