using System.IO;
using BotWeChatChannel.Forwarder.Exceptions;
using BotWeChatChannel.Forwarder.Models;
using Microsoft.Bot.Connector.DirectLine;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;

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
        private DirectLineClient _client = new DirectLineClient(BotConfig.Secret);
        private ConversationMap _conversationMap = ConversationMapFactory.Map;
        private ResponseMessageHandler _handler;
        
        public BotMessageHandler(Stream stream) : base(stream)
        {
            _handler = ResponseMessageHandlerFactory.GetHandler(_client);
        }

        private string GetConversationIdOrStartAConversation(string username)
        {
            var conversationId = _conversationMap.GetConversationId(username);
            if (conversationId != null)
            {
                return conversationId;
            }
            conversationId = _client.Conversations.StartConversation().ConversationId;
            _conversationMap.Update(username, conversationId);
            return conversationId;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            
            throw new NotSupportedRequestTypeException();
        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var conversationId = GetConversationIdOrStartAConversation(requestMessage.FromUserName);
            var activity = new Activity()
            {
                From = new ChannelAccount(requestMessage.FromUserName),
                Text = requestMessage.Content,
                Type = ActivityTypes.Message
            };
            var response = _client.Conversations.PostActivity(conversationId, activity);
            return _handler.Interpret(response.Id, conversationId);
        }
      
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            return base.OnImageRequest(requestMessage);
        }



    }

    public static class BotMessageHandlerFactory
    {
        static BotMessageHandler Handler(Stream input) => new BotMessageHandlerMock(input);
    }

}