using FinalProject.Business.DTOs.SizeDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface ISizeService
{
     Task AddAsyncSize(SizeCreateDTO sizeCreateDTO);

     void DeleteSize(int id);

     void UpdateSize(SizeUpdateDTO sizeUpdateDTO);

    SizeGetDTO  GetSize(Func<Size, bool>? func=null);

    List<SizeGetDTO> GetAllSizes(Func<Size, bool>? func=null);
}
