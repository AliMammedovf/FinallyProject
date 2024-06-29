using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class SliderConfugration : IEntityTypeConfiguration<Slider>
{
	public void Configure(EntityTypeBuilder<Slider> builder)
	{
		builder.Property(x=>x.Title).IsRequired().HasMaxLength(30);
		builder.Property(x=>x.RedirectUrl).IsRequired();
		builder.Property(x=>x.Description).IsRequired().HasMaxLength(70);
	}
}
