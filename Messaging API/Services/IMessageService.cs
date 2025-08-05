using MessagingApi.Models;
using System.Collections.Generic;


namespace MessagingApi.Services
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAll();
        Message? GetById(Guid id);
        Message Create(string content);
    }
}
