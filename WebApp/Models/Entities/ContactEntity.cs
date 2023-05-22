using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class ContactEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public bool SaveInformation { get; set; }

    public ICollection<MessageEntity> Message = new HashSet<MessageEntity>();

    public static implicit operator ContactModel (ContactEntity entity)
    {
        return new ContactModel
        {
            Name = entity.Name,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            CompanyName = entity.CompanyName,
            SaveInformation = entity.SaveInformation,
        };
    }
}
