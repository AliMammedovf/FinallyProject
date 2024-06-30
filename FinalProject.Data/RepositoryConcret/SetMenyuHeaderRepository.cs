using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.DAL;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.RepositoryConcret;

public class SetMenyuHeaderRepository : GenericRepository<SetMenyuHeader>, ISetMenyuHeaderRepository
{
	public SetMenyuHeaderRepository(AppDbContext appDbContext) : base(appDbContext)
	{
	}
}
