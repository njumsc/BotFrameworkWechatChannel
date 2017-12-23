using System;
using System.Collections.Generic;

namespace BotWeChatChannel.Forwarder.Bot
{
    
    
    public class ConversationMap
    {
        public static ConversationMap Map { get; } = new ConversationMap();

        public void Update(string username, string conversationId)
        {
            
        }

        public string GetConversationId(string username)
        {
            return null;
        }
        
        
    }

    public static class ConversationMapFactory
    {
        public static ConversationMap Map { get; } = new ConversationMap();
    }
}