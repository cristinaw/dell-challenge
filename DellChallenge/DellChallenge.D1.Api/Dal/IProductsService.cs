﻿using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Get(string id);
        ProductDto Add(NewProductDto newProduct);
        ProductDto Update(ProductDto updatedProduct);
        ProductDto Delete(string id);
    }
}
