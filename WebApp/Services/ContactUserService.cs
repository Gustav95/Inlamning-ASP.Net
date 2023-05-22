using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ContactUserService
{
    private readonly DataContext _context;

    public ContactUserService(DataContext context)
    {
        _context = context;
    }


    public async Task<ContactEntity> EmailExistAsync(string email)
    {
        var entity = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == email);

        return entity;
    }


    public async Task<bool> CreateAsync(ContactViewModel contactViewModel)
    {
        try
        {
            ContactEntity existingContact = await EmailExistAsync(contactViewModel.Email);
            if (existingContact != null)
            {
                MessageEntity messageEntity = contactViewModel;
                messageEntity.ContactsId = existingContact.Id;
                _context.Message.Add(messageEntity);
               
                await _context.SaveChangesAsync();
            }
            else 
            { 

            ContactEntity contactEntity = contactViewModel;
            _context.Contacts.Add(contactEntity);
            await _context.SaveChangesAsync();
            
            MessageEntity messageEntity = contactViewModel;
            messageEntity.ContactsId = contactEntity.Id;
            _context.Message.Add(messageEntity);
            await _context.SaveChangesAsync();
            }


            return true;


        }
        catch
        {
            return false;
        }
    }
}
