using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ContactViewModel
{
    public string Name { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company")]
    public string? CompanyName { get; set; }
    public bool SaveInformation { get; set; }

    public string Message { get; set; } = null!;

    public static implicit operator ContactEntity (ContactViewModel contactViewModel)
    {
        return new ContactEntity
        {
            Name = contactViewModel.Name,
            Email = contactViewModel.Email,
            PhoneNumber = contactViewModel.PhoneNumber,
            CompanyName = contactViewModel.CompanyName,
            SaveInformation = contactViewModel.SaveInformation,
        };
    }

    public static implicit operator MessageEntity (ContactViewModel contactViewModel)
    {
        return new MessageEntity
        {
            Message = contactViewModel.Message
        };
    }
}
