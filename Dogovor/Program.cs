using ConnectionProvider;
using Interface.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.Services;
using System.Text;
using Repository.Interfaces.DepartmentRepository;
using Repository.Interfaces;
using Repository;
using Service.Services.FormToFillService;
using Entity.MailSettings;
using Service.Services.MailService;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;
using Dogovor.Controllers.ApplicationController;
using Service;
using Service.Services.City;
using Repository.CityRepository;
using Service.PrincipalPosition;
using Repository.PrincipalPosition;
using Service.PrincipalPlaceService;
using Repository.PrincipalPlaceRepository;
using Repository.PrincipalName;
using Service.PrincipalName;
using Repository.ReceiversPassportTypeRepository;
using Service.PrincipalReasonService;
using Repository.PrincipalReason;
using Service.Purpose;
using Repository.Purpose;

var builder = WebApplication.CreateBuilder(args);


builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    //ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Staging,
    WebRootPath = "customwwwroot"
});


ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase("TestDb").UseLazyLoadingProxies());
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("ConnectionProvider")).UseLazyLoadingProxies());
//builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString, b => b.MigrationsAssembly("ConnectionProvider")).UseLazyLoadingProxies());
builder.Services.AddCors();
builder.Services.AddSingleton<ApplicationFormController>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IPrincipalPositionService, PrincipalPositionService>();
builder.Services.AddScoped<IPrincipalPositionRepository, PrincipalPositionRepository>();
builder.Services.AddScoped<IPrincipalPlaceService, PrincipalPlaceService>();
builder.Services.AddScoped<IPrincipalPlaceRepository, PrincipalPlaceRepository>();
builder.Services.AddScoped<IPrincipalNameRepository, PrincipalNameRepository>();
builder.Services.AddScoped<IPrincipalNameService, PrincipalNameService>();
builder.Services.AddScoped<IReceiversPassportTypeService, ReceiversPassportTypeService>();
builder.Services.AddScoped<IReceiversPassportTypeRepository, ReceiversPassportTypeRepository>();
builder.Services.AddScoped<IPrincipalReasonService, PrincipalReasonService>();
builder.Services.AddScoped<IPrincipalReasonRepository, PrincipalReasonRepository>();
builder.Services.AddScoped<IPurposeRepository,PurposeRepository>();
builder.Services.AddScoped<ICodeResetRepository,CodeResetRepository>();
builder.Services.AddScoped<IPurposeService, PurposeService>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(cfg =>
    {
        cfg.SaveToken = true;
        cfg.RequireHttpsMetadata = false;

        cfg.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidateAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dataContext.Database.MigrateAsync();
}
app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
builder.Services.AddDirectoryBrowser();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();
app.UseDefaultFiles();
app.UseStaticFiles();

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
