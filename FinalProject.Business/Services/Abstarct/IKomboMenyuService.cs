using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct;

public interface IKomboMenyuService
{
	Task AddAsyncKomboMenyu(KomboMenyu menyu);

	void DeleteKomboMenyu(int id);

	void UpdateKomboMenyu(KomboMenyu menyu);

	KomboMenyu GetMenyu(Func<KomboMenyu, bool>? func = null);

	List<KomboMenyu> GetAllMenyus(Func<KomboMenyu, bool>? func = null);
}
