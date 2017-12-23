using System;

namespace BotWeChatChannel.Forwarder.Models
{
    
    public class WeChatConfig {
        public static string AppId {get; private set;}
        public static string AppSecret {get; private set;}
        
        public static string Token {get;private set;}

        private WeChatConfig() {

        }
    
        internal static void InitConfig(string appId, string appSecret, string token) {
            AppId = appId;
            AppSecret = appSecret;
            Token = token;
        }
    }
}