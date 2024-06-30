using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Business.DTOs.AboutSliderDTOs
{
	public class AboutSliderGetDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;

		public string? Description { get; set; }

		public string Text { get; set; } = null!;

		public string? ImageUrl { get; set; }

        public string? IconUrl { get; set; }

        public string? RedirectUrl { get; set; }

		public IFormFile ImageFile { get; set; }

		public IFormFile IconImage { get; set; }
	}
}
