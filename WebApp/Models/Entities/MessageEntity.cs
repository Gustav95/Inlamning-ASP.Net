namespace WebApp.Models.Entities;

public class MessageEntity
{
    public int Id { get; set; }
    public string Message { get; set; } = null!;

    public int ContactsId { get; set; }
    public ContactEntity Contacts { get; set; } = null!;

    public static implicit operator MessageModel (MessageEntity entity)
    {
        return new MessageModel
        {
            Id = entity.Id,
            Message = entity.Message,
        };
    }
}


