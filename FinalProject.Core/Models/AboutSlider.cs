using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models;

public class AboutSlider:BaseEntity
{
	public string Title	{ get; set; }

	public string? Description { get; set; }

	public string Text { get; set; }

	public string? ImageUrl { get; set; }

	public string? IconUrl { get; set; }

	public string? RedirectUrl { get; set; }




}
