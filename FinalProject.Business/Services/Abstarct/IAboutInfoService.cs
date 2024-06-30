using FinalProject.Business.DTOs.AboutInfoDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IAboutInfoService
{
	Task AddAboutInfoAsync(AboutInfoCreateDTO aboutInfoCreateDTO);

	void DeleteAboutInfo(int id);

	void UpdateAboutInfo(AboutInfoUpdateDTO aboutInfoUpdateDTO);

	AboutInfoGetDTO GetAboutInfo(Func<AboutInfo, bool>? func = null);

	List<AboutInfoGetDTO> GetAllAboutInfos(Func<AboutInfo, bool>? func = null);
}
