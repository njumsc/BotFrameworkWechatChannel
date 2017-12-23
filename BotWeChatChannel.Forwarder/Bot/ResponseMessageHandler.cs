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
        protected DirectLineClient _client;

        public ResponseMessageHandler(DirectLineClient client)
        {
            this._client = client;
        }
        
        
        public virtual IResponseMessageBase Interpret(ResourceResponse response)
        {
            return null;
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