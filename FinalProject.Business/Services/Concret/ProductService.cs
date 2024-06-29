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
    private readonly IProductImageRepository _productImageRepository;
    public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env, ICategoryRepository categoryRepository, IFlavourRepository flavourRepository, ISizeRepository sizeRepository, IProductSizeRepository productSizeRepository, IProductImageRepository productImageRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _env = env;
        _categoryRepository = categoryRepository;
        _flavourRepository = flavourRepository;
        _sizeRepository = sizeRepository;
        _productSizeRepository = productSizeRepository;
        _productImageRepository = productImageRepository;
    }

    public async Task AddAsyncProduct(ProductCreateDTO productCreateDTO)
    {


        var exsistCategory= _categoryRepository.Get(x=>x.Id== productCreateDTO.CategoryId);

        if (exsistCategory == null) throw new CategoryNotFoundException("Category not found!");

        var exsistFlavour= _flavourRepository.Get(x=>x.Id == productCreateDTO.FlavourId);

        if(exsistFlavour == null) throw new FlavourNotFoundException("Flavour not found!");

        

        Product product = _mapper.Map<Product>(productCreateDTO);

        if (productCreateDTO.SizeIds != null)
        {
            foreach(var sizeId in productCreateDTO.SizeIds)
            {
                if(!_sizeRepository.GetAll().Any(x=>x.Id == sizeId))
                {
                    throw new SizeNotFoundException("Size not found!");
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

       if(productCreateDTO.PosterImage != null)
        {
            ProductImage poster = new ProductImage()
            {
                Product = product,
                ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\products", productCreateDTO.PosterImage),
                IsPoster = true
            };

          await _productImageRepository.AddAsync(poster);
           
            
        }
        else
        {
            throw new FileNotNullException("File cannot null!");
        }

        if(productCreateDTO.ImageFiles != null)
        {
            foreach(var ImageFile in productCreateDTO.ImageFiles)
            {


                ProductImage productImage = new ProductImage
                {
                    Product = product,
                    ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\products", ImageFile),
                    IsPoster = null
                };

               await  _productImageRepository.AddAsync(productImage);
            }
        }
        else
        {
            throw new FileNotNullException("File cannot null!");
        }

        await _productRepository.AddAsync(product);
        product.CreatedDate = DateTime.UtcNow.AddHours(4);
        await _productRepository.CommitAsync();

    }

    public void DeleteProduct(int id)
    {
       var exsistProduct = _productRepository.Get(x=>x.Id== id);
        if (exsistProduct == null) throw new CategoryNotFoundException("Id cannot be empty!");

        foreach (var item in exsistProduct.ProductImages)
        {
            if (item.ImageUrl != null) 
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\products", item.ImageUrl);
            }
        }

        _productRepository.Delete(exsistProduct);
        //exsistProduct.DeletedDate = DateTime.UtcNow.AddHours(4);
        _productRepository.Commit();
    }

    public List<ProductGetDTO> GetAllProducts(Func<Product, bool>? func = null)
    {
        var products = _productRepository.GetAll(func, "Category", "Flavour","ProductSizes.Size","ProductImages");

        List<ProductGetDTO> productsDTO= _mapper.Map<List<ProductGetDTO>>(products);

        return productsDTO;
    }

    public ProductGetDTO GetProduct(Func<Product, bool>? func = null)
    {
        var product= _productRepository.Get(func, "Category", "Flavour", "ProductSizes.Size", "ProductImages");

        ProductGetDTO productDTO= _mapper.Map<ProductGetDTO>(product);

        return productDTO;
    }

    public void UpdateProduct(ProductUpdateDTO productUpdateDTO)
    {
        var oldProduct= _productRepository.Get(x=>x.Id==productUpdateDTO.Id);

        if (oldProduct == null) throw new ProductNotFoundException("Product not found!");

        var exsistCategory = _categoryRepository.Get(x => x.Id == productUpdateDTO.CategoryId);

        if (exsistCategory == null) throw new CategoryNotFoundException("Category not found!");

        var exsistFlavour = _flavourRepository.Get(x => x.Id == productUpdateDTO.FlavourId);

        if (exsistFlavour == null) throw new FlavourNotFoundException("Flavour not found!");

       

       

        if(productUpdateDTO.SizeIds != null)
        {

            oldProduct.ProductSizes.RemoveAll(bt => !productUpdateDTO.SizeIds.Contains(bt.SizeId));

            foreach (var sizeId in productUpdateDTO.SizeIds.Where(x => !oldProduct.ProductSizes.Any(bt => bt.SizeId == x)))
            {
                ProductSize productSize = new ProductSize()
                {
                    SizeId = sizeId,
                };
                oldProduct.ProductSizes.Add(productSize);
            }
        }

        if (productUpdateDTO.PosterImage != null)
        {
            Helper.DeleteFile(_env.WebRootPath, @"uploads\products", oldProduct.ProductImages.FirstOrDefault(x => x.IsPoster == true).ImageUrl);
            oldProduct.ProductImages.Remove(oldProduct.ProductImages.FirstOrDefault(x => x.IsPoster == true));
            ProductImage poster = new ProductImage()
            {
                Product = oldProduct,
                ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\products", productUpdateDTO.PosterImage),
                IsPoster = true
                
            };
            //Helper.DeleteFile(_env.WebRootPath, @"uploads/products", oldProduct.ImageUrl);
            
            
            oldProduct.ProductImages.Add(poster);
        }

        oldProduct.ProductImages.RemoveAll(bi => !productUpdateDTO.ProductImageIds.Contains(bi.Id) && bi.IsPoster==null);


        if (productUpdateDTO.ImageFiles != null)
        {
            foreach (var ImageFile in productUpdateDTO.ImageFiles)
            {


                ProductImage productImage = new ProductImage
                {
                    Product = oldProduct,
                    ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\products", ImageFile),
                    IsPoster = null
                };

                 oldProduct.ProductImages.Add(productImage);
            }
        }

        
       


        oldProduct.Title = productUpdateDTO.Title;
        oldProduct.Description = productUpdateDTO.Description;
        oldProduct.Price = productUpdateDTO.Price;
        oldProduct.AdditionalInfo = productUpdateDTO.AdditionalInfo;
        oldProduct.CategoryId = productUpdateDTO.CategoryId;
        oldProduct.FlavourId = productUpdateDTO.FlavourId;
        oldProduct.IsAvialable = productUpdateDTO.IsAvialable;
        

        _productRepository.Commit();
    }
}
