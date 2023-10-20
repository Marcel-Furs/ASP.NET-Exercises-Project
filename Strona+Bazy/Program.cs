using Microsoft.EntityFrameworkCore;
using Strona_Bazy.Data;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Strona_Bazy.Mapper;
using Strona_Bazy.Repositories;
using Strona_Bazy.Repositories.CharakterRepository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<ICharakterRepository, CharakterRepository>();
builder.Services.AddAutoMapper(typeof(MapperProfile));


builder.Services.AddDefaultIdentity<IdentityUser>(opt =>
{
    opt.SignIn.RequireConfirmedAccount = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 5;
    opt.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.SlidingExpiration = true;
    options.LoginPath = "/Login/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
