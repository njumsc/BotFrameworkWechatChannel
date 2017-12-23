using System;
using System.IO;
using BotWeChatChannel.Forwarder.Exceptions;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Entities;

namespace BotWeChatChannel.Forwarder.Bot
{
    public class BotMessageHandlerMock : BotMessageHandler
    {
        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var response = CreateResponseMessage<ResponseMessageText>();
            response.Content = requestMessage.MsgId.ToString();
            return response;
        }

        public BotMessageHandlerMock(Stream stream) : base(stream) 
        {

        }
        
        
    }

    public class BotMessageHandler : MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>>
    {
        public BotMessageHandler(Stream stream) : base(stream) 
        {
        }


        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            requestMessage.
            throw new NotSupportedRequestTypeException();
        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            return base.OnTextRequest(requestMessage);
        }

        public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            return base.OnLocationRequest(requestMessage);
        }

        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            return base.OnImageRequest(requestMessage);
        }

        public override IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            return base.OnVoiceRequest(requestMessage);
        }

        public override IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        {
            return base.OnVideoRequest(requestMessage);
        }

        public override IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
        {
            return base.OnLinkRequest(requestMessage);
        }

        public override IResponseMessageBase OnShortVideoRequest(RequestMessageShortVideo requestMessage)
        {
            return base.OnShortVideoRequest(requestMessage);
        }
    }

    public static class BotMessageHandlerFactory
    {
        static BotMessageHandler Handler(Stream input) => new BotMessageHandlerMock(input);
    }

}