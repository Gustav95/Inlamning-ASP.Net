
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    
    
    private readonly ContactUserService _contactUserService;

    public ContactsController(ContactUserService contactUserService)
    {
        _contactUserService = contactUserService;
    }

    public IActionResult Index()
    {
        ViewData["Titel"] = "Contact Us";
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _contactUserService.CreateAsync(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Något gick fel");           
        }
        return View(model);
    }


}
