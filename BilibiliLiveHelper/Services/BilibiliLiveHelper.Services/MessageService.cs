using BilibiliLiveHelper.Services.Interfaces;

namespace BilibiliLiveHelper.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
