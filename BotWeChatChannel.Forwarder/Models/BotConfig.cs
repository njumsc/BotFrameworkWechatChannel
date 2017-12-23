using System;

namespace BotWeChatChannel.Forwarder.Models
{
    public class BotConfig {
        public static string Secret { get; private set; }

        internal static void InitConfig(string secret) {
            Secret = secret;
        }
    }
}