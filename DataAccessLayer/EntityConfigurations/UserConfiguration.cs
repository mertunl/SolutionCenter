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
	public class UserConfiguration:IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			//builder.HasData(
			//	new AppUser()
			//	{
					
			//		Name = "Mert",
			//		Surname="Ünal",
			//		Email="mert@hotmail.com",
					

			//	},
			//	new AppUser()
			//	{
					
			//		Name = "test",
			//		Surname = "test2",
			//		Email = "test@hotmail.com",
			//	}
			//	);
		}
	}
}
