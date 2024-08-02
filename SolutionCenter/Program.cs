using Newtonsoft.Json.Serialization;
using BusinessLayer.Extensions;
using DataAccessLayer.Extensions;
using DataAccessLayer.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolutionCenter.Extensions;



var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ContextConnection") ?? throw new InvalidOperationException("Connection string 'ContextConnection' not found.");

//builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Context>();

builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();
builder.Services.AddServiceServices();
builder.Services.AddRepositoryServices(builder.Configuration);
builder.Services.AddSolutionCenterServices();
//builder.Services.AddControllers().AddNewtonsoftJson();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseCors("AllowAll");


app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    await SolutionCenterServiceExtensions.SeedRolesAndAdminAsync(scope.ServiceProvider);
}

app.UseCors("AllowAll");

    app.Run();
