﻿using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Abstarct
{
	public interface ITableService
	{
		Task AddAsyncTable(TableCreateDTO tableCreateDTO);
		void DeleteTable(int id);
		void UpdateTable(TableUpdateDTO tableUpdateDTO);
		TableGetDTO GetTable(Func<Table, bool>? func = null);
		IEnumerable<TableGetDTO> GetAllReservations(Func<Table, bool>? func = null);
	}
}