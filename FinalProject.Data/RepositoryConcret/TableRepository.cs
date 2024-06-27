using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.RepositoryConcret;

public class TableRepository : GenericRepository<Table>, ITableRepository
{
	public TableRepository(AppDbContext appDbContext) : base(appDbContext)
	{
	}
}
