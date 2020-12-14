﻿using Newtonsoft.Json.Linq;
using PoliNetworkBot_CSharp.Code.Objects;
using System;
using System.Threading.Tasks;

namespace PoliNetworkBot_CSharp.Code.Bots.Anon
{
    [Serializable]
    internal class WebPost
    {
        public JObject r4;

        public long postid;
        public string text;
        public long? photoid;
        public char approved;
        public char seen;
        public string password;

        public WebPost(JObject r4)
        {
            this.r4 = r4;
            ;
            IJEnumerable<JToken> x = this.r4["PostID"].Values()[0];
            ;

            foreach(var r5 in r4.Children())
            {
                ;
                if (r5 is JProperty r6)
                {
                    ;

                    if (r6.Value is JValue r7)
                    {

                        switch (r6.Name)
                        {
                            case "PostID":
                                {
                                    postid = Convert.ToInt64(r7.Value);
                                    break;
                                }

                            case "Text":
                                {
                                    text = r7.Value.ToString();
                                    break;
                                }

                            case "PhotoID":
                                {
                                    long? p = null;
                                    try
                                    {
                                        p = Convert.ToInt64(r7.Value);
                                    }
                                    catch
                                    {
                                        ;
                                    }

                                    photoid = p;

                                    if (photoid <=0)
                                    {
                                        photoid = null;
                                    }

                                    break;
                                }

                            case "Approved":
                                {
                                    approved = r7.Value.ToString()[0];
                                    break;
                                }

                            case "Password":
                                {
                                    password = r7.Value.ToString();
                                    break;
                                }

                            case "Seen":
                                {
                                    seen = r7.Value.ToString()[0];
                                    break;
                                }

                            default:
                                {
                                    ;
                                    break;
                                }
                        }
                    }
                }
            }
        }

        internal async Task<bool> PlaceInQueue()
        {
            Objects.TelegramBotAbstract telegramBotAbstract = await GetAnonBotAsync();
            if (telegramBotAbstract == null)
                return false;
            MessaggeAnonToSendInQueue e = new MessaggeAnonToSendInQueue(this);
            return await Code.Bots.Anon.MainAnon.PlaceMessageInQueue(telegramBotAbstract, e, 0, null);
        }

        private async Task<TelegramBotAbstract> GetAnonBotAsync()
        {
            if (Code.Data.GlobalVariables.Bots == null)
            {
                try
                {
                    await MainProgram.Program.StartBotsAsync(false, false, true);
                }
                catch
                {
                    ;
                }
            }

            foreach (var key in Code.Data.GlobalVariables.Bots.Keys)
            {
                string m = Code.Data.GlobalVariables.Bots[key].GetMode();
                if (m == Code.Data.Constants.BotStartMethods.Anon)
                {
                    return Code.Data.GlobalVariables.Bots[key];
                }
            }

            return null;
        }

        internal async System.Threading.Tasks.Task setAsSeenAsync()
        {
            string url = "https://spottedpolimi.altervista.org/s/setseen.php?id=" + this.postid.ToString() + "&password=" + Anon.ConfigAnon.password + "&seen=Y";
            var x = await Utils.Web.DownloadHtmlAsync(url);
            seen = 'Y';
        }
    }
}