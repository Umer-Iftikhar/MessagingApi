using MessagingApi.Models;
using System.Collections.Concurrent;


namespace MessagingApi.Services
{
    public class MessageService : IMessageService
    {
        private readonly ConcurrentDictionary<Guid, Message> _messages = new();
        public IEnumerable<Message> GetAll() => _messages.Values.OrderByDescending(m => m.Timestamp);
        public Message? GetById(Guid id) => _messages.TryGetValue(id, out var msg) ? msg : null;
        public Message Create(string content)
        {
            var message = new Message { Content = content };
            _messages[message.Id] = message;
            return message;
        }
    }
}
