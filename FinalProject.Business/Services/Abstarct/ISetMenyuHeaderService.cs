using FinalProject.Business.DTOs.SetMenyuHeaderDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface ISetMenyuHeaderService
{

	Task AddSetMenyuHeaderAsync(SetMenyuHeaderCreateDTO setHeaderCreateDTO);

	void DeleteSetMenyuHeader(int id);

	void UpdateSetMenyuHeader(SetMenyuHeaderUpdateDTO headerUpdateDTO);

	SetMenyuHeaderGetDTO GetHeaderMenyu(Func<SetMenyuHeader, bool>? func = null);

	List<SetMenyuHeaderGetDTO> GetAllSetMenyuHeaders(Func<SetMenyuHeader, bool>? func = null);
}
