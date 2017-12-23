using System.Collections.Generic;
using Microsoft.Bot.Connector.DirectLine;
using Senparc.Weixin.MP.Entities;

namespace BotWeChatChannel.Forwarder.Bot
{
    public class ResponseMessageHandlerMock : ResponseMessageHandler
    {
        public override IResponseMessageBase Interpret(ResourceResponse response)
        {
            return null;
        }

        public ResponseMessageHandlerMock(DirectLineClient client) : base(client)
        {
        }
    }
    
    public class ResponseMessageHandler
    {
        protected DirectLineClient client;

        public ResponseMessageHandler(DirectLineClient client)
        {
            this.client = client;
        }
        
        
        public virtual IResponseMessageBase Interpret(string activityId, string conversationId)
        {
            ActivitySet activitySet = client.Conversations.GetActivities(conversationId);

        }

        private IResponseMessageBase TextMessage(IEnumerable<Activity> activities)
        {
            return 
        }
        
    }

    public static class ResponseMessageHandlerFactory
    {
        public static ResponseMessageHandler GetHandler(DirectLineClient client)
        {
            return new ResponseMessageHandlerMock(client);
        }
    }
}