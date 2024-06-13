using AutoMapper;
using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.FlavourDTOs;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.DTOs.SizeDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryCreateDTO, Category>().ReverseMap();
        CreateMap<Category, CategoryGetDTO>().ReverseMap();

        CreateMap<ProductCreateDTO, Product>().ReverseMap();
        CreateMap<Product, ProductGetDTO>().ReverseMap();

        CreateMap<FlavourCreateDTO, Flavour>().ReverseMap();
        CreateMap<Flavour, FlavourGetDTO>().ReverseMap();

        CreateMap<SizeCreateDTO, Size>().ReverseMap();
        CreateMap<Size, SizeGetDTO>().ReverseMap();
    }
}
