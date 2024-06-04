using Cwiczenia10.Contexts;
using Cwiczenia10.Exceptions;
using Cwiczenia10.Models;
using Cwiczenia10.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia10.Services;


public interface IProductService
{
    Task<AddProductRequestModel> AddProductAsync(AddProductRequestModel model);
}
public class ProductService(DataBaseContext context) : IProductService
{
    public async Task<AddProductRequestModel> AddProductAsync(AddProductRequestModel model)
    {
        var product =  new Products
        {
            Name = model.ProductName,
            Weight =  model.ProductWeight,
            Width = model.ProductWidth,
            Height = model.ProductHeight,
            Depth = model.ProductDepth,
        };

       
        var categories = await context.Categories
            .Where(c => model.ProductCategories.Contains(c.CategoryId))
            .ToListAsync();
        var notFoundCategories = model.ProductCategories.Except(categories.Select(c => c.CategoryId)).ToList();

        if (notFoundCategories.Any())
        {
            throw new NotFoundException($"There is no such category with id: {string.Join(", ", notFoundCategories)}");
        }

        foreach (var catId in categories)
        {
            var productCategory = new ProductsCategories
            {
               Products = product,
               Categories = catId
            };
            await context.ProductsCategories.AddAsync(productCategory);

        }
        
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();

        return model;
    }
}