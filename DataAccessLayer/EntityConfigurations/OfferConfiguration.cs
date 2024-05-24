using EntityLayer.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityConfigurations
{
	public class OfferConfiguration : IEntityTypeConfiguration<Offer>
	{
		public void Configure(EntityTypeBuilder<Offer> builder)
		{
			builder.HasOne(o => o.AppUser)
		   .WithMany(u => u.Offers)
		   .HasForeignKey(o => o.AppUserId)
		   .OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(o => o.Post)
				.WithMany(p => p.Offers)
				.HasForeignKey(o => o.PostID)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
