using Microsoft.EntityFrameworkCore;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
using StarColonies.Infrastructures.Repositories;
using StarColonies.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<StarColoniesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnexionString"));
});

builder.Services
    .AddDefaultIdentity<StarColoniesUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<StarColoniesContext>();

builder.Services.AddTransient<ReverseProxyLinksMiddleware>();

//Interfaces
builder.Services.AddScoped<IMissionRepository, MissionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions());
app.UseReverseProxyLinks();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();