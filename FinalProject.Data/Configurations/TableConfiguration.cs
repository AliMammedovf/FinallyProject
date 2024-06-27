using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
	public void Configure(EntityTypeBuilder<Table> builder)
	{
		builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
		builder.Property(x => x.Price).IsRequired();
		builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
		builder.Property(x => x.Seats).IsRequired();
	}
}
