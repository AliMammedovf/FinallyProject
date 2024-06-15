using AutoMapper;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Extensions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFlavourRepository _flavourRepository;
    private readonly ISizeRepository _sizeRepository;
    private readonly IProductSizeRepository _productSizeRepository;
    public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env, ICategoryRepository categoryRepository, IFlavourRepository flavourRepository, ISizeRepository sizeRepository, IProductSizeRepository productSizeRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _env = env;
        _categoryRepository = categoryRepository;
        _flavourRepository = flavourRepository;
        _sizeRepository = sizeRepository;
        _productSizeRepository = productSizeRepository;
    }

    public async Task AddAsyncProduct(ProductCreateDTO productCreateDTO)
    {
        if (productCreateDTO.ImageFile == null)
            throw new Exceptions.FileNotFoundException("File not found!");

        var exsistCategory= _categoryRepository.Get(x=>x.Id== productCreateDTO.CategoryId);

        if (exsistCategory == null) throw new EntityNotFoundException("Category not found!");

        var exsistFlavour= _flavourRepository.Get(x=>x.Id == productCreateDTO.FlavourId);

        if(exsistFlavour == null) throw new EntityNotFoundException("Flavour not found!");

        Product product = _mapper.Map<Product>(productCreateDTO);

        if (productCreateDTO.SizeIds != null)
        {
            foreach(var sizeId in productCreateDTO.SizeIds)
            {
                if(_sizeRepository.GetAll().Any(x=>x.Id == sizeId))
                {
                    throw new EntityNotFoundException("Size not found!");
                }
            }

            foreach (var sizeId in productCreateDTO.SizeIds)
            {
                ProductSize productSize = new ProductSize()
                {
                    SizeId = sizeId,
                    Product= product,
                    CreatedDate = DateTime.UtcNow.AddHours(4),
                    DeletedDate = DateTime.UtcNow.AddHours(4)

                };

                await _productSizeRepository.AddAsync(productSize);
                
        }
        }

       

        

        product.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/products", productCreateDTO.ImageFile);

        await _productRepository.AddAsync(product);
        product.CreatedDate = DateTime.UtcNow.AddHours(4);
        await _productRepository.CommitAsync();

    }

    public void DeleteProduct(int id)
    {
       var exsistProduct = _productRepository.Get(x=>x.Id== id);
        if (exsistProduct == null) throw new EntityNotFoundException("Id cannot be empty!");

        Helper.DeleteFile(_env.WebRootPath, @"uploads/products", exsistProduct.ImageUrl);

        _productRepository.Delete(exsistProduct);
        exsistProduct.DeletedDate = DateTime.UtcNow.AddHours(4);
        _productRepository.Commit();
    }

    public IEnumerable<ProductGetDTO> GetAllProducts(Func<Product, bool>? func = null)
    {
        var products = _productRepository.GetAll(func, "Category", "Flavour","Sizes");

        IEnumerable<ProductGetDTO> productsDTO= _mapper.Map<IEnumerable<ProductGetDTO>>(products);

        return productsDTO;
    }

    public ProductGetDTO GetProduct(Func<Product, bool>? func = null)
    {
        var product= _productRepository.Get(func, "Category", "Flavour","Sizes");

        ProductGetDTO productDTO= _mapper.Map<ProductGetDTO>(product);

        return productDTO;
    }

    public void UpdaterProduct(ProductUpdateDTO productUpdateDTO)
    {
        var oldProduct= _productRepository.Get(x=> x.Id== productUpdateDTO.Id);

        if (oldProduct == null) throw new EntityNotFoundException("Product not found!");

        if(productUpdateDTO.ImageFile != null)
        {
            oldProduct.ImageUrl= Helper.SaveFile(_env.WebRootPath, @"uploads/products", productUpdateDTO.ImageFile);

            Helper.DeleteFile(_env.WebRootPath, @"uploads/products", oldProduct.ImageUrl);
        }

        oldProduct.Title = productUpdateDTO.Title;
        oldProduct.Description = productUpdateDTO.Description;
        oldProduct.Price = productUpdateDTO.Price;
        oldProduct.AdditionalInfo = productUpdateDTO.AdditionalInfo;
        oldProduct.CategoryId = productUpdateDTO.CategoryId;
        oldProduct.FlavourId = productUpdateDTO.FlavourId;
        //oldProduct.

        _productRepository.Commit();
    }
}
