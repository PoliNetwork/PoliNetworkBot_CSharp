﻿#region

using PoliNetworkBot_CSharp.Code.Enums;
using System;
using System.Collections.Generic;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

#endregion

namespace PoliNetworkBot_CSharp.Code.Objects.InfoBot
{
    [Serializable]
    public class BotInfo : BotInfoAbstract
    {
        internal new bool SetIsBot(BotTypeApi v)
        {
            return false;
        }

        internal new BotTypeApi? IsBot()
        {
            return BotTypeApi.REAL_BOT;
        }

        internal UpdateType[] GetAllowedUpdates()
        {
            switch (KeyValuePairs[ConstConfigBot.OnMessages])
            {
                case "a":
                    {
                        var x = new List<UpdateType>() { UpdateType.CallbackQuery, UpdateType.Message, UpdateType.InlineQuery, UpdateType.ChosenInlineResult };
                        return x.ToArray();
                    }
            }

            return null;
        }

        internal bool Callback()
        {
            switch (KeyValuePairs[ConstConfigBot.OnMessages])
            {
                case "a":
                    {
                        return true;
                    }
            }

            return false;
        }

        internal EventHandler<CallbackQueryEventArgs> GetCallbackEvent()
        {
            switch (KeyValuePairs[ConstConfigBot.OnMessages])
            {
                case "a":
                    {
                        return Bots.Anon.MainAnon.CallbackMethod;
                    }
            }

            return null;
        }
    }
}