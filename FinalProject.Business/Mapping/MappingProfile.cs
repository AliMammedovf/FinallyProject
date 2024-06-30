using AutoMapper;
using FinalProject.Business.DTOs.AboutInfoDTOs;
using FinalProject.Business.DTOs.AboutSliderDTOs;
using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.EmployeeDTOs;
using FinalProject.Business.DTOs.FlavourDTOs;
using FinalProject.Business.DTOs.PizzaMenyuDTOs;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.DTOs.SetMenyuHeaderDTOs;
using FinalProject.Business.DTOs.SizeDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.DTOs.TableDTOs;
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
        CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
        

        CreateMap<ProductCreateDTO, Product>().ReverseMap();
        CreateMap<Product, ProductGetDTO>().ReverseMap();
        CreateMap<Product, ProductUpdateDTO>().ReverseMap();

        CreateMap<FlavourCreateDTO, Flavour>().ReverseMap();
        CreateMap<Flavour, FlavourGetDTO>().ReverseMap();
        CreateMap<Flavour, FlavourGetDTO>().ReverseMap();

        CreateMap<SizeCreateDTO, Size>().ReverseMap();
        CreateMap<Size, SizeGetDTO>().ReverseMap();
        CreateMap<Size, SizeUpdateDTO>().ReverseMap();

        CreateMap<TableCreateDTO, Table>().ReverseMap();
		CreateMap<Table, TableGetDTO>().ReverseMap();
        CreateMap<Table, TableUpdateDTO>().ReverseMap();

		CreateMap<ReservationCreateDTO, Reservation>().ReverseMap();
		CreateMap<Reservation, ReservationGetDTO>().ReverseMap();

        CreateMap<SliderCreateDTO, Slider>().ReverseMap();
        CreateMap<Slider, SliderGetDTO>().ReverseMap();
        CreateMap<Slider,SliderUpdateDTO>().ReverseMap();


		CreateMap<AboutSliderCreateDTO, AboutSlider>().ReverseMap();
		CreateMap<AboutSlider, AboutSliderGetDTO>().ReverseMap();
		CreateMap<AboutSlider, AboutSliderUpdateDTO>().ReverseMap();

        CreateMap<PizzaMenyuCreateDTO, PizzaMenyu>().ReverseMap();
        CreateMap<PizzaMenyu, PizzaMenyuGetDTO>().ReverseMap();
        CreateMap<PizzaMenyu, PizzaMenyuUpdateDTO>().ReverseMap();


        CreateMap<EmployeeCreateDTO,Employee>().ReverseMap();
        CreateMap<Employee, EmployeeGetDTO>().ReverseMap();
        CreateMap<Employee,EmployeeUpdateDTO>().ReverseMap();

		CreateMap<SetMenyuHeaderCreateDTO, SetMenyuHeader>().ReverseMap();
		CreateMap<SetMenyuHeader, SetMenyuHeaderGetDTO>().ReverseMap();
		CreateMap<SetMenyuHeader, SetMenyuHeaderUpdateDTO>().ReverseMap();

		CreateMap<AboutInfoCreateDTO, AboutInfo>().ReverseMap();
		CreateMap<AboutInfo, AboutInfoGetDTO>().ReverseMap();
		CreateMap<AboutInfo, AboutInfoUpdateDTO>().ReverseMap();
	}
}
