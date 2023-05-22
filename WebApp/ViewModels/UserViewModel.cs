using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class UserViewModel
{
    public string? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }  
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; } 
    public string? UserRoles { get; set; }


    public static implicit operator UserProfileEntity(UserViewModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName!,
            LastName = model.LastName!
        };
    }

    public static implicit operator IdentityUser (UserViewModel model)
    {
        return new IdentityUser
        {
            PhoneNumber = model.PhoneNumber,
            Email = model.Email
        };
    }
}
