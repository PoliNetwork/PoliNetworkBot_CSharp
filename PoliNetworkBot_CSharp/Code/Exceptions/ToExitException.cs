﻿using System;
using System.Runtime.Serialization;

namespace PoliNetworkBot_CSharp.Code.Bots.Moderation
{
    [Serializable]
    internal class ToExitException : Exception
    {
        public ToExitException()
        {
        }

        public ToExitException(string message) : base(message)
        {
        }

        public ToExitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ToExitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}