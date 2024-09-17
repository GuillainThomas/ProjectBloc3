using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using ProjetBloc3.Business.Applicatif;
using ProjetBloc3.Business.Applicatif.Security;
using ProjetBloc3.Business.Metier;
using ProjetBloc3.Business.Metier.Security;
using ProjetBloc3.Components;
using ProjetBloc3.Repository.BlocCube3;
using ProjetBloc3.Security.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add DbContext
builder.Services.AddDbContext<BlocCubeContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CookieService and auth service
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromHours(3);
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddCascadingAuthenticationState();

// Add MudBlazor
builder.Services.AddMudServices();

// Services métiers
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleModuleAccessService, UserRoleModuleAccessService>();
builder.Services.AddScoped<IUserService, UserService>();

// Services applicatifs
builder.Services.AddScoped<IArticleAppService, ArticleAppService>();
builder.Services.AddScoped<IAuthenticationServiceApp, AuthenticationServiceApp>();
builder.Services.AddScoped<IModuleServiceApp, ModuleServiceApp>();
builder.Services.AddScoped<IRoleServiceApp, RoleServiceApp>();
builder.Services.AddScoped<IUserServiceApp, UserServiceApp>();

// Configurer Serilog pour enregistrer les logs dans un fichier
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
