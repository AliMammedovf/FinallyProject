using AutoMapper;
using FinalProject.Business.DTOs.FlavourDTOs;
using FinalProject.Business.DTOs.SizeDTOs;
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

public class SizeService : ISizeService
{
    private readonly ISizeRepository _sizeRepository;
    private readonly IMapper _mapper;

    public SizeService(ISizeRepository sizeRepository, IMapper mapper)
    {
        _sizeRepository = sizeRepository;
        _mapper = mapper;
    }

    public async Task AddAsyncSize(SizeCreateDTO sizeCreateDTO)
    {
        if (sizeCreateDTO == null)
            throw new EntityNotFoundException("Size not found!");
        Size size = _mapper.Map<Size>(sizeCreateDTO);

        if (_sizeRepository.GetAll().Any(x => x.Name == sizeCreateDTO.Name))
        {
            await _sizeRepository.AddAsync(size);
            await _sizeRepository.CommitAsync();
        }
        else
        {
            throw new DuplicateEntityException("Size name is available!");
        }
    }

    public void DeleteSize(int id)
    {
        var exsist = _sizeRepository.Get(x => x.Id == id);

        if (exsist == null)
            throw new EntityNotFoundException("Id cannot be empty!");

        _sizeRepository.Delete(exsist);
        _sizeRepository.Commit();
    }

    public IEnumerable<SizeGetDTO> GetAllSizes(Func<Size, bool>? func = null)
    {
        var size = _sizeRepository.GetAll(func);

        IEnumerable<SizeGetDTO> sizeGetDTO = _mapper.Map<IEnumerable<SizeGetDTO>>(size);

        return sizeGetDTO;
    }

    public SizeGetDTO GetSize(Func<Size, bool>? func = null)
    {
        var size = _sizeRepository.Get(func);

        SizeGetDTO sizeGetDTO = _mapper.Map<SizeGetDTO>(size);

        return sizeGetDTO;
    }

    public void UpdateSize(SizeUpdateDTO sizeUpdateDTO)
    {
        var oldSize = _sizeRepository.Get(x => x.Id == sizeUpdateDTO.Id);

        if (oldSize == null)
            throw new EntityNotFoundException("Size not found!");



        if (!_sizeRepository.GetAll().Any(x => x.Id != sizeUpdateDTO.Id && x.Name == sizeUpdateDTO.Name))
        {
            oldSize.Name = sizeUpdateDTO.Name;
        }
        else
        {
            throw new DuplicateEntityException("Size name is available!");
        }

        _sizeRepository.Commit();
    }
}
