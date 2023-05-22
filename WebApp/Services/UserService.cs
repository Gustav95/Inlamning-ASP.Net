using WebApp.Contexts;
using WebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApp.ViewModels;

namespace WebApp.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager)
    {
        _identityContext = identityContext;
        _userManager = userManager;
    }

    public async Task<UserProfileEntity> GetUserProfileAsync(string userId)
    {
        var userProfileEntity = await _identityContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == userId);

        return userProfileEntity!;
    }


    public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
    {
       
        var userRoles = new List<UserViewModel>();
        var User = await _userManager.Users.ToListAsync();

        foreach ( var user in User)
        {
            List<string> roles = (List<string>) await _userManager.GetRolesAsync(user);
            var userProfile = await GetUserProfileAsync(user.Id);
            var profileWithRole = new UserViewModel
            {
                UserId = userProfile.UserId,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserRoles = roles[0]
            };
            userRoles.Add(profileWithRole);
        }
        return userRoles; 
    }
    
    

}

