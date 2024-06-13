using AutoMapper;
using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task AddAsyncCategory(CategoryCreateDTO categoryCreateDTO)
    {
        if (categoryCreateDTO == null)
            throw new EntityNotFoundException("Category not found!");

        Category category= _mapper.Map<Category>(categoryCreateDTO);

        if(!_categoryRepository.GetAll().Any(x=>x.Name== categoryCreateDTO.Name))
        {
           await  _categoryRepository.AddAsync(category);
           await  _categoryRepository.CommitAsync();
        }
        else
        {
            throw new DuplicateEntityException("Category name is available!");
        }
        

    }

    public void DeleteCategory(int id)
    {
        var exsist= _categoryRepository.Get(x=>x.Id==id);

        if (exsist == null)
            throw new EntityNotFoundException("Id cannot be empty!");

        _categoryRepository.Delete(exsist);
        _categoryRepository.Commit();
    }

    public IEnumerable<CategoryGetDTO> GetAllCategories(Func<Category, bool>? func = null)
    {
        var category= _categoryRepository.GetAll(func);

        IEnumerable<CategoryGetDTO> categoryGetDTO = _mapper.Map<IEnumerable<CategoryGetDTO>>(category);

        return categoryGetDTO;
    }

    public CategoryGetDTO GetCategory(Func<Category, bool>? func = null)
    {
        var category= _categoryRepository.Get(func);

        CategoryGetDTO categoryGetDTO= _mapper.Map<CategoryGetDTO>(category);

        return categoryGetDTO;
    }

    public void UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
    {
        var oldCategory= _categoryRepository.Get(x=> x.Id==categoryUpdateDTO.Id);

        if (oldCategory == null)
            throw new EntityNotFoundException("Category not found!");



        if(!_categoryRepository.GetAll().Any(x=> x.Id != categoryUpdateDTO.Id && x.Name==categoryUpdateDTO.Name ))
        {
            oldCategory.Name = categoryUpdateDTO.Name;
        }
        else
        {
            throw new DuplicateEntityException("Category name is available!");
        }

        _categoryRepository.Commit();
    }
}
