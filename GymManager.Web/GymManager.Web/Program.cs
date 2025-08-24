using GymManager.ApplicationServices.Attendances;
using GymManager.ApplicationServices.Cities;
using GymManager.ApplicationServices.EquipmentTypes;
using GymManager.ApplicationServices.Members;
using GymManager.ApplicationServices.MembershipRenewal;
using GymManager.ApplicationServices.MembershipsTypes;
using GymManager.ApplicationServices.Navigation;
using GymManager.Core.Attendances;
using GymManager.Core.Cities;
using GymManager.Core.EquipmentTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipsTypes;
using GymManager.DataAccess;
using GymManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Wkhtmltopdf.NetCore;

var builder = WebApplication.CreateBuilder(args);


//Service that redirects the view with the controller
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IMenuAppService, MenuAppService>();
builder.Services.AddTransient<IMembershipTypeAppService, MembershipTypeAppService>();
builder.Services.AddTransient<IEquipmentAppServices, EquipmentAppServices>();
builder.Services.AddTransient<ICitiesAppServices, CitiesAppServices>();
builder.Services.AddTransient<IMembersAppServices, MembersAppServices>();
builder.Services.AddTransient<IAttendancesAppServices, AttendancesAppServices>();
builder.Services.AddTransient<IMembershipRenewalAppServices, MembershipRenewalAppServices>();




builder.Services.AddTransient<IRepository<int, Member>, MembersRepository>();
builder.Services.AddTransient<IRepository<int, MembershipType>, MembershipTypeRepository>();
builder.Services.AddTransient<IRepository<int, EquipmentType>, EquipmentRepository>();
builder.Services.AddTransient<IRepository<int, City>, CityRepository>();
builder.Services.AddTransient<IRepository<int, Attendance>, AttendancesRepository>();





builder.Services.AddWkhtmltopdf();


string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<GymManagerContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<GymManagerContext>()
    .AddUserStore<UserStore<IdentityUser, IdentityRole, GymManagerContext>>();


builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");


//Serilog 
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


var app = builder.Build();

// function that allow us to use static files
app.UseStaticFiles();

//app.MapGet("/File1", () => DateTime.Now.ToString());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute( "default",  "{controller=home}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Attendance}/{action=MemberIn}/{id?}");

app.Run();
