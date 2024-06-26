using FinalProject.Business.Services.Abstarct;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.Services.Concret;

public class CheckOutService : ICheckOutService
{
	private readonly IConfiguration _configuration;

	public CheckOutService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public List<CheckOut> GetAllCheckOutVM(Func<CheckOut, bool>? func = null)
	{
		return _configuration.Get<List<CheckOut>>();
	}
}
