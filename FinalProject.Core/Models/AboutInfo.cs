using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models;

public class AboutInfo:BaseEntity
{
	public string Title { get; set; }

	public string Description { get; set; }

	public string ImageUrl { get; set; }

	public string FonUrl { get; set; }
}
