using System;
using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Get(string id)
        {
            return _context.Products.Select(p => MapToDto(p)).Where(p=>p.Id == id).FirstOrDefault();
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Update(ProductDto updatedProduct)
        {
            _context.Products.Update(MapToData(updatedProduct));
            _context.SaveChanges();
            return updatedProduct;
        }

        public ProductDto Delete(string id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                try
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return MapToDto(product);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return null;
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private Product MapToData(ProductDto updatedProduct)
        {
            return new Product
            {
                Id = updatedProduct.Id,
                Category = updatedProduct.Category,
                Name = updatedProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
