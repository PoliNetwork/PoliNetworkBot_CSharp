﻿using System;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using TeleSharp.TL;

namespace PoliNetworkBot_CSharp.Code.Objects
{
    [Serializable]
    public class MessageToDelete
    {
        private readonly int messageId;
        private readonly long chatId;
        private readonly DateTime timeToDelete;
        private readonly long botId;
        private readonly ChatType? chatType;
        private readonly long? accessHash;

        public MessageToDelete(TLMessage r3, long chatId, System.DateTime timeToDelete, long botId, ChatType? chatType, long? accessHash)
        {
            this.messageId = r3.Id;
            this.chatId = chatId;
            this.timeToDelete = timeToDelete;
            this.botId = botId;
            this.chatType = chatType;
            this.accessHash = accessHash;
        }

        public MessageToDelete(Telegram.Bot.Types.Message r4, long chatId, DateTime timeToDelete, long botId, ChatType? chatType, long? accessHash)
        {
            this.messageId = r4.MessageId;
            this.chatId = chatId;
            this.timeToDelete = timeToDelete;
            this.botId = botId;
            this.chatType = chatType;
            this.accessHash = accessHash;
        }

        internal bool ToDelete()
        {
            if (DateTime.Now > timeToDelete)
                return true;
            return false;
        }

        internal async Task<bool> Delete()
        {
            TelegramBotAbstract bot = Code.Data.GlobalVariables.Bots[this.botId];
            if (bot == null)
                return false;

            try
            {
                return await bot.DeleteMessageAsync(chatId, messageId, chatType, accessHash);
            }
            catch (Exception e)
            {
                await Utils.NotifyUtil.NotifyOwners(e, bot);
            }

            return false;
        }
    }
}