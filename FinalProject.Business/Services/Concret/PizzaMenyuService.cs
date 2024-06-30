using AutoMapper;
using FinalProject.Business.DTOs.PizzaMenyuDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Extensions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.RepositoryConcret;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class PizzaMenyuService : IPizzaMenyuService
{
    private readonly IPizzaMenyuRepository _repository;
    private readonly IWebHostEnvironment _env;
    private readonly IMapper _mapper;

    public PizzaMenyuService(IPizzaMenyuRepository repository, IWebHostEnvironment env, IMapper mapper)
    {
        _repository = repository;
        _env = env;
        _mapper = mapper;
    }

    public async Task AddPizzaMenyuAsync(PizzaMenyuCreateDTO pizzaMenyuCreateDTO)
    {
        if (pizzaMenyuCreateDTO.ImageFile == null) throw new EntityNotFoundException("File connot be empty!");

        PizzaMenyu menyu = _mapper.Map<PizzaMenyu>(pizzaMenyuCreateDTO);

        menyu.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\pizzas", pizzaMenyuCreateDTO.ImageFile);

        await _repository.AddAsync(menyu);
        await _repository.CommitAsync();
    }

    public void DeletePizzaMenyu(int id)
    {
        var existMenyu = _repository.Get(x => x.Id == id);

        if (existMenyu == null)
            throw new EntityNotFoundException("Menyu not found!");

        Helper.DeleteFile(_env.WebRootPath, @"uploads\pizzas", existMenyu.ImageUrl);

        _repository.Delete(existMenyu);
        _repository.Commit();
    }

    public List<PizzaMenyuGetDTO> GetAllPizzaMenyus(Func<PizzaMenyu, bool>? func = null)
    {
        var pizzas = _repository.GetAll(func);

        List<PizzaMenyuGetDTO> pizzaMenyuGetDTOs = _mapper.Map<List<PizzaMenyuGetDTO>>(pizzas);
        return pizzaMenyuGetDTOs;
    }

    public PizzaMenyuGetDTO GetPizzaMenyu(Func<PizzaMenyu, bool>? func = null)
    {
        var pizza = _repository.Get(func);
        PizzaMenyuGetDTO pizzaMenyuGetDTO = _mapper.Map<PizzaMenyuGetDTO>(pizza);
        return pizzaMenyuGetDTO;
    }

    public void UpdatePizzaMenyu(PizzaMenyuUpdateDTO pizzaMenyuUpdateDTO)
    {
        var existMenyu = _repository.Get(x => x.Id == pizzaMenyuUpdateDTO.Id);

        if (existMenyu == null)
            throw new EntityNotFoundException("Menyu not found!");

        if (pizzaMenyuUpdateDTO.ImageFile != null)
        {
            if (pizzaMenyuUpdateDTO.ImageFile.ContentType != "image/png" && pizzaMenyuUpdateDTO.ImageFile.ContentType != "image/jpeg")
                throw new ImageContentTypeException("File format is not avialable!");

            Helper.DeleteFile(_env.WebRootPath, @"uploads\pizzas", existMenyu.ImageUrl);

            existMenyu.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\pizzas", pizzaMenyuUpdateDTO.ImageFile);

        }


        existMenyu.Title = pizzaMenyuUpdateDTO.Title;
        existMenyu.Description = pizzaMenyuUpdateDTO.Description;
        existMenyu.Price = pizzaMenyuUpdateDTO.Price;

        _repository.Commit();
    }
}

