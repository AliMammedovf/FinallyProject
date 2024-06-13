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
    public Task AddAsyncCategory(CategoryCreateDTO categoryCreateDTO);

    public void DeleteCategory(int id); 

    public void UpdateCategory(CategoryUpdateDTO categoryUpdateDTO);

    CategoryGetDTO GetCategory(Func<Category, bool>? func=null);

    IEnumerable<CategoryGetDTO> GetAllCategories(Func<Category, bool>? func = null);
}
