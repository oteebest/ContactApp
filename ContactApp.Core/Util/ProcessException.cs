﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Util
{
    [Serializable()]
    public class ProcessException : Exception
    {
        public ProcessException(string message):
            base(message)
        {

        }
    }
}
