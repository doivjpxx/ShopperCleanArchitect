using AutoMapper;
using Shop.ApplicationCore.DTOs;
using Shop.ApplicationCore.Entities;
using Shop.ApplicationCore.Exceptions;
using Shop.ApplicationCore.Interfaces;
using Shop.ApplicationCore.Utils;
using Shop.Infrastructure.Persistence.Context;

namespace Shop.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopContext _shopContext;
    private readonly IMapper _mapper;

    public ProductRepository(ShopContext shopContext, IMapper mapper)
    {
        _shopContext = shopContext;
        _mapper = mapper;
    }
    
    public List<ProductResponse> GetProducts()
    {
        return _shopContext.Products.Select(p => _mapper.Map<ProductResponse>(p)).ToList();
    }

    public ProductResponse GetProductById(int productId)
    {
        var product = _shopContext.Products.Find(productId);
        if (product != null)
        {
            return _mapper.Map<ProductResponse>(product);
        }

        throw new NotFoundException();
    }

    public void DeleteProductById(int productId)
    {
        var product = _shopContext.Products.Find(productId);
        if (product != null)
        {
            _shopContext.Products.Remove(product);
            _shopContext.SaveChanges();
        }
        else
        {
            throw new NotFoundException();
        }
    }

    public ProductResponse CreateProduct(CreateProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        product.Stock = 0;
        product.CreatedAt = product.UpdatedAt = DateUtil.GetCurrentDate();

        _shopContext.Products.Add(product);
        _shopContext.SaveChanges();

        return _mapper.Map<ProductResponse>(product);
    }

    public ProductResponse UpdateProduct(int productId, UpdateProductRequest request)
    {
        var product = _shopContext.Products.Find(productId);
        if (product != null)
        {
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.UpdatedAt = DateUtil.GetCurrentDate();

            _shopContext.Products.Update(product);
            _shopContext.SaveChanges();

            return _mapper.Map<ProductResponse>(product);
        }

        throw new NotFoundException();
    }
}
