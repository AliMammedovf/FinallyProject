using FinalProject.Business.DTOs.PizzaMenyuDTOs;
using FinalProject.Business.DTOs.PizzaMenyuDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IPizzaMenyuService
{
    Task AddPizzaMenyuAsync(PizzaMenyuCreateDTO pizzaMenyuCreateDTO);

    void DeletePizzaMenyu(int id);

    void UpdatePizzaMenyu(PizzaMenyuUpdateDTO pizzaMenyuUpdateDTO);

    PizzaMenyuGetDTO GetPizzaMenyu(Func<PizzaMenyu, bool>? func = null);

    List<PizzaMenyuGetDTO> GetAllPizzaMenyus(Func<PizzaMenyu, bool>? func = null);
}
