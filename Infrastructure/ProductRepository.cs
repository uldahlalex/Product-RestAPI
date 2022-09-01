using Entities;

namespace Infrastructure;

public class ProductRepository
{
    private ProductDbContext _productContext;

    public ProductRepository(ProductDbContext context)
    {
        _productContext = context;
    }

    public List<Product> GetAllProducts()
    {
        return _productContext.ProductTable.ToList();
    }

    public Product InsertProduct(Product product)
    {
        _productContext.ProductTable.Add(product);
        _productContext.SaveChanges();
        return product;
    }

    public void CreateDB()
    {
        _productContext.Database.EnsureDeleted();
        _productContext.Database.EnsureCreated();
    }

}