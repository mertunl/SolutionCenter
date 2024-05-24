using DataAccessLayer.Abstract;
using DataAccessLayer.DatabaseContext;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Extensions
{
	public static class RepositoryExtensions
	{
		public static IServiceCollection AddRepositoryServices(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));
			services.AddScoped<IPostDAL,EfPostDAL>();
			services.AddScoped<ICategoryDAL,EfCategoryDAL>();
			services.AddScoped<IOfferDAL,EfOfferDAL>();
			services.AddScoped<IApplicationDAL,EfApplicationDAL>();
			services.AddScoped<IUserDAL,EfUserDAL>();
			services.AddScoped<IStatDAL,EfStatDAL>();
			
			return services;
		}
	}
}
