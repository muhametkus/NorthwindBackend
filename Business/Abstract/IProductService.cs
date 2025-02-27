﻿using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IProductService
{
    IDataResult<Product> GetById(int productId);
    IDataResult<List<Product>> GetList();
    IDataResult<List<Product>> GetlistByCategory(int categoryId);
    IResult Add(Product product);
    IResult Update(Product product);
    IResult Delete(Product product);
}