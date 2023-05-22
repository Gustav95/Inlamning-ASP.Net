using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string? Description { get; set; }


    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public string? ImgURL { get; set; }



    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();




    public static implicit operator ProductModel(ProductEntity entity)
    {
        return new ProductModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            ImgURL = entity.ImgURL

        };
    }

}
