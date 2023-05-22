using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductRegistrationViewModel
{
    [Required(ErrorMessage ="Ange produktnamn")]
    [Display(Name = "Produktname *")]
    public string Name { get; set; } = null!;
    
    [Display(Name = "Produktbeskrivning")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Ange pris")]
    [Display(Name = "Produktpris *")]
    [DataType(DataType.Currency)]
    public decimal  Price { get; set; }

    public string? ImgURL { get; set; }



    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        return new ProductEntity
        {
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            Price = productRegistrationViewModel.Price,
            ImgURL = productRegistrationViewModel.ImgURL

        };
    }

}
