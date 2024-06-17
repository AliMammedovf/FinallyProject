using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IProductService
{
    Task AddAsyncProduct(ProductCreateDTO productCreateDTO);

    void DeleteProduct(int id);

    void UpdateProduct(ProductUpdateDTO productUpdateDTO);

    ProductGetDTO GetProduct(Func<Product, bool>? func=null);

    IEnumerable<ProductGetDTO> GetAllProducts(Func<Product, bool>? func=null);

}
