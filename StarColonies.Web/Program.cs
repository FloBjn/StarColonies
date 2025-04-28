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
    if (builder.Environment.IsDevelopment())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnexionString"));
    }
    else if(builder.Environment.IsProduction())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProdConnexionString"));
    }
    
});

builder.Services
    .AddDefaultIdentity<StarColoniesUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<StarColoniesContext>();

builder.Services.AddTransient<ReverseProxyLinksMiddleware>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // durée d'inactivité avant expiration
    options.Cookie.HttpOnly = true; // sécurité
    options.Cookie.IsEssential = true; // pour fonctionner même si consentement aux cookies est requis
});

//Interfaces
builder.Services.AddScoped<IBonusObjectRepository, BonusObjectRepository>();
builder.Services.AddScoped<IColonRepository, ColonRepository>();
builder.Services.AddScoped<IMissionHistoryRepository, MissionHistoryRepository>();
builder.Services.AddScoped<IMissionRepository, MissionRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEnemyRepository, EnemyRepository>();

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

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();