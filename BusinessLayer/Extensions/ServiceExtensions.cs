using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Validator;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServiceServices(this IServiceCollection services)
		{
			services.AddScoped<IApplicationService, ApplicationService>();
			services.AddScoped<IOfferService, OfferService>();
			services.AddScoped<IPostService, PostService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IStatService, StatService>();
			services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ApplicationValidator>());
			services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PostValidator>());
			
			return services;
		}
	}
}
