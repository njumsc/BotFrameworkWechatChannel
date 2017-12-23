using Microsoft.Bot.Connector.DirectLine;
using Senparc.Weixin.MP.Entities;

namespace BotWeChatChannel.Forwarder.Bot
{
    public class ResponseMessageHandlerMock : ResponseMessageHandler
    {
        
    }
    
    public class ResponseMessageHandler
    {
        public IResponseMessageBase Interpret(ResourceResponse response)
        {
            return null;
        }        
    }

    public static class ResponseMessageHandlerFactory
    {
        public static ResponseMessageHandler Handler { get; } = new ResponseMessageHandlerMock();
    }
}