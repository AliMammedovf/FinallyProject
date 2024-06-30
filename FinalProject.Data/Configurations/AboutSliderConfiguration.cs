using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class AboutSliderConfiguration : IEntityTypeConfiguration<AboutSlider>
{
	public void Configure(EntityTypeBuilder<AboutSlider> builder)
	{
		builder.Property(x => x.Title).IsRequired().HasMaxLength(30);
		builder.Property( x => x.Description).HasMaxLength(50);
		builder.Property(x=>x.Text).IsRequired().HasMaxLength(200);
		builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
	}
}
