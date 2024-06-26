using AutoMapper;
using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.FlavourDTOs;
using FinalProject.Business.Exceptions;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.RepositoryConcret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class FlavourService : IFlavourService
{
    private readonly IFlavourRepository _favourRepository;
    private readonly IMapper _mapper;

    public FlavourService(IMapper mapper, IFlavourRepository favourRepository)
    {
        _mapper = mapper;
        _favourRepository = favourRepository;
    }

    public async Task AddAsyncFlavour(FlavourCreateDTO flavourCreateDTO)
    {
        if(flavourCreateDTO == null)
            throw new FlavourNotFoundException("Flavour not found!");

        Flavour flavour= _mapper.Map<Flavour>(flavourCreateDTO);

        if( !_favourRepository.GetAll().Any(x=>x.Name== flavourCreateDTO.Name))
        {
           await  _favourRepository.AddAsync(flavour);
           await  _favourRepository.CommitAsync();
        }
        else
        {
            throw new DuplicateEntityException("Flavour name is available!");
        }

    }

    public void DeleteFlavour(int id)
    {
        var exsist = _favourRepository.Get(x => x.Id == id);

        if (exsist == null)
            throw new FlavourNotFoundException("Id cannot be empty!");

        _favourRepository.Delete(exsist);
        _favourRepository.Commit();
    }

    public List<FlavourGetDTO> GetAllFlavours(Func<Flavour, bool>? func = null)
    {
        var flavour = _favourRepository.GetAll(func);

        List<FlavourGetDTO> flavourGetDTO = _mapper.Map<List<FlavourGetDTO>>(flavour);

        return flavourGetDTO;
    }

    public FlavourGetDTO GetFlavour(Func<Flavour, bool>? func = null)
    {
        var flavour = _favourRepository.Get(func);

        FlavourGetDTO flavourGetDTO = _mapper.Map<FlavourGetDTO>(flavour);

        return flavourGetDTO;
    }

    public void UpdateFlavour(FlavourUpdateDTO flavourUpdateDTO)
    {
        var oldFlavour = _favourRepository.Get(x => x.Id == flavourUpdateDTO.Id);

        if (oldFlavour == null)
            throw new FlavourNotFoundException("Flavour not found!");



        if (!_favourRepository.GetAll().Any(x => x.Id != flavourUpdateDTO.Id && x.Name == flavourUpdateDTO.Name))
        {
            oldFlavour.Name = flavourUpdateDTO.Name;
        }
        else
        {
            throw new DuplicateEntityException("Flavour name is available!");
        }

        _favourRepository.Commit();
    }
}
