﻿using System;

namespace PoliNetworkBot_CSharp.Code.Objects
{
    [Serializable]
    public class BotInfo : BotInfoAbstract
    {
#pragma warning disable IDE0060 // Rimuovere il parametro inutilizzato

        internal new bool SetIsBot(bool v)
#pragma warning restore IDE0060 // Rimuovere il parametro inutilizzato
        {
            return false;
        }

        internal new bool IsBot()
        {
            return true;
        }
    }
}