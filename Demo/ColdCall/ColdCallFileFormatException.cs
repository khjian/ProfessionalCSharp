﻿using System;
using System.Runtime.Serialization;

namespace Demo
{
    [Serializable]
    internal class ColdCallFileFormatException : Exception
    {
        public ColdCallFileFormatException(string message) : base(message)
        {
        }

        public ColdCallFileFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}