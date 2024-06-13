using FinalProject.Business.DTOs.FlavourDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IFlavourService
{
     Task AddAsyncFlavour(FlavourCreateDTO flavourCreateDTO);

     void DeleteFlavour(int id);

     void UpdateFlavour(FlavourUpdateDTO flavourUpdateDTO);

    FlavourGetDTO GetFlavour(Func<Flavour, bool>? func = null);

    IEnumerable<FlavourGetDTO> GetAllFlavours(Func<Flavour, bool>? func = null);
}
