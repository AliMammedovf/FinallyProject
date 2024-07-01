using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Data.Configurations;

public class ReservationConfugration : IEntityTypeConfiguration<Reservation>
{
	public void Configure(EntityTypeBuilder<Reservation> builder)
	{

		builder.Property(x => x.StartDate).IsRequired();
		builder.Property(x => x.EndDate).IsRequired();
		builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
	}
}
