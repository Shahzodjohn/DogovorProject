//builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase("TestDb").UseLazyLoadingProxies());
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
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
builder.Services.AddCors();
builder.Services.AddSingleton<ApplicationFormController>();
builder.Services.FormServices();
builder.Services.CityServices();
builder.Services.CodeResetServices();
builder.Services.UserServices();
builder.Services.DepartmentServices();
builder.Services.RoleServices();
builder.Services.PrincipalReasonServices();
builder.Services.MailSettingServices(builder);
builder.Services.MailService();
builder.Services.PrincipalPositionServices();
builder.Services.PrincipalPlaceServices();
builder.Services.PrincipalNameServices();
builder.Services.ReceiversPassportTypeServices();
builder.Services.PurposeServices();
builder.Services.AddAuthentication(builder);
//builder.Services.Postgress(connectionString);
builder.Services.MsSql(connectionString);
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

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
