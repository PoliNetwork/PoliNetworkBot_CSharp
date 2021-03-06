﻿#region

using PoliNetworkBot_CSharp.Code.Objects;
using System;
using System.Threading.Tasks;

#endregion

namespace PoliNetworkBot_CSharp.Code.Utils
{
    internal static class Info
    {
        internal static async Task<Code.Objects.UserIdFound> GetTargetUserIdAsync(string target, TelegramBotAbstract telegramBotAbstract)
        {
            if (string.IsNullOrEmpty(target))
                return null;

            if (target.StartsWith("-"))
                try
                {
                    var i = Convert.ToInt32(target);
                    return new UserIdFound(i, "FailedParsingInt(1)");
                }
                catch
                {
                    return new UserIdFound(null, "FailedParsingInt(2)");
                }

            if (target[0] < '0' || target[0] > '9')
            {
                var i2 = await GetIdFromUsernameAsync(target, telegramBotAbstract);
                return i2;
            }

            try
            {
                var i3 = Convert.ToInt32(target);
                return new UserIdFound(i3, "FailedParsingInt(3)");
            }
            catch
            {
                return null;
            }
        }

        private static async Task<Code.Objects.UserIdFound> GetIdFromUsernameAsync(string target, TelegramBotAbstract telegramBotAbstract)
        {
            return await telegramBotAbstract.GetIdFromUsernameAsync(target);
        }
    }
}