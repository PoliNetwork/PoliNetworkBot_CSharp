﻿using System;

namespace PoliNetworkBot_CSharp.Code.Utils
{
    internal class ExceptionNumbered : Exception
    {
        private int v;

        const int default_v = 1;

        public ExceptionNumbered(Exception item1, int v = default_v) : base(item1.Message)
        {
            this.v = v;
        }

        public ExceptionNumbered(string message, int v = default_v) : base(message)
        {
            this.v = v;
        }

        internal void Increment()
        {
            v++;
        }

        internal Exception GetException()
        {
            return this;
        }

        internal bool AreTheySimilar(Exception item2)
        {
            if (this.Message == item2.Message)
                return true;

            return false;
        }

        internal int GetNumberOfTimes()
        {
            return v;
        }
    }
}