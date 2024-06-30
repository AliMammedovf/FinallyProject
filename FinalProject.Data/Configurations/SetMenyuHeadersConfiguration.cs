using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class SetMenyuHeadersConfiguration : IEntityTypeConfiguration<SetMenyuHeader>
{
	public void Configure(EntityTypeBuilder<SetMenyuHeader> builder)
	{
		builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
		builder.Property(x=>x.Description).IsRequired().HasMaxLength(250);
	}
}
