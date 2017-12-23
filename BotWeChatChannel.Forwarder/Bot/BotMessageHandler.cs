using System;
using System.IO;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Entities;

namespace BotWeChatChannel.Forwarder.Bot
{
    public class BotMessageHandlerMock : BotMessageHandler
    {
        public BotMessageHandlerMock(Stream stream) : base(stream) {

        }
    }

    public class BotMessageHandler : MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>>
    {
        public BotMessageHandler(Stream stream) : base(stream) 
        {

        }


        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            throw new NotImplementedException();
        }
    }

    public static class BotMessageHandlerFactory
    {
        static BotMessageHandler Handler(Stream input) => new BotMessageHandlerMock(input);
    }

}