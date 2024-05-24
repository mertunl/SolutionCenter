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
	public class CategoryConfiguration: IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(
				new Category()
				{
					CategoryID = 1,
					Name = "C#"
				},
				new Category()
				{
                    CategoryID = 2,
                    Name = "Java"
				},
				new Category()
				{
                    CategoryID = 3,
                    Name = ".NET Core"
				},
				new Category()
				{
                    CategoryID = 4,
                    Name ="Spring Framework"
				},
				new Category()
				{
                    CategoryID = 5,
                    Name = "Angular"
				},
				new Category()
				{
                    CategoryID = 6,
                    Name = "React" 
				}
				);
		}
	}
}
