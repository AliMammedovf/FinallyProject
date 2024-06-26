using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Core.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public  interface ICategoryService
{
     Task AddAsyncCategory(CategoryCreateDTO categoryCreateDTO);

     void DeleteCategory(int id); 

     void UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);

    CategoryGetDTO GetCategory(Func<Category, bool>? func=null);

    List<CategoryGetDTO> GetAllCategories(Func<Category, bool>? func = null);
}
