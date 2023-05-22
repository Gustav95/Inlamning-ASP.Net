using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApp.Contexts;
using WebApp.Helpers.Repositories;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly ProductTagRepository _productTagRepository;
    private readonly ProductRepository _productRepo;
    public ProductService(DataContext context, ProductTagRepository productTagRepository, ProductRepository productRepo)
    {
        _context = context;
        _productTagRepository = productTagRepository;
        _productRepo = productRepo;
    }




    public async Task<bool> CreateAsync(ProductEntity entity)
    {
        var _entity = await _productRepo.GetAsync(x => x.Id == entity.Id);
        if (_entity == null) 
        {
            _entity = await _productRepo.AddAsync(entity);
            if (_entity != null)

            return true;
        }
        return false;
    }


    public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
    {
        var ifexist = await _context.Products.FirstOrDefaultAsync(x  => x.Name == entity.Name);
        foreach(var tag in tags)
        {
            
            await _productTagRepository.AddAsync(new ProductTagEntity
            {
                ProductId = ifexist!.Id,
                TagId = int.Parse(tag)
            });
        }
    }


    public async Task<bool> CreateAsyn(ProductRegistrationViewModel productRegistrationViewModel)
    {
        try
        {
            ProductEntity productEntity = productRegistrationViewModel;
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _context.Products.ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }
        return products;
        
    }

    public async Task<ProductModel> GetSpecificProduct(int id)
    {
        ProductModel products= new ProductModel();
        products= await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        return products;
    }


    public async Task<List<ProductEntity>> GetNewProductsAsync(string New)
    {
        var products= await _context.Products
            .Where(x => x.ProductTags.Any(t => t.Tag.TagName == New))
            .ToListAsync();

        return products;
    }

    public async Task<List<ProductEntity>> GetPopulareProductsAsync(string Popular)
    {
        var products = await _context.Products
            .Where(x => x.ProductTags.Any(t => t.Tag.TagName == Popular))
            .ToListAsync();

        return products;
    }

    public async Task<List<ProductEntity>> GetFeaturedProductsAsync(string Featured)
    {
        var products = await _context.Products
            .Where(x => x.ProductTags.Any(t => t.Tag.TagName == Featured))
            .ToListAsync();

        return products;
    }


    public async Task<List<ProductEntity>> GetShowcaseAsync(string Showcase)
    {
        var products = await _context.Products
            .Where(x => x.ProductTags.Any(t => t.Tag.TagName == Showcase))
            .ToListAsync();

        return products;
    }



}
