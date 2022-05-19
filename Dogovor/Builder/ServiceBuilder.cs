namespace Dogovor.Builder
{
    public static class ServiceBuilder
    {
        public static void FormServices(this IServiceCollection Services)
        {
            Services.AddScoped<IFormService, FormService>();
            Services.AddScoped<IFormRepository, FormRepository>();
        }
        public static void CityServices(this IServiceCollection Services)
        {
            Services.AddScoped<ICityRepository, CityRepository>();
            Services.AddScoped<ICityService, CityService>();
        }
        public static void CodeResetServices(this IServiceCollection Services)
        {
            Services.AddScoped<ICodeResetRepository, CodeResetRepository>();
            //services.AddScoped<ICodeResetService, CodeResetService>();
        }
        public static void UserServices(this IServiceCollection Services)
        {
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<IUserService, UserService>();
        }
        public static void DepartmentServices(this IServiceCollection Services)
        {
            Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped<IDepartmentService, UserService>();
        }
        public static void RoleServices(this IServiceCollection Services)
        {
            Services.AddScoped<IRoleRepository, RoleRepository>();
        }
        public static void MailSettingServices(this IServiceCollection Services, WebApplicationBuilder builder)
        {
            Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
        }
        public static void MailService(this IServiceCollection Services)
        {
            Services.AddScoped<IMailServices, MailServices>();
        }
        public static void PrincipalPositionServices(this IServiceCollection Services)
        {
            Services.AddScoped<IPrincipalPositionService, PrincipalPositionService>();
            Services.AddScoped<IPrincipalPositionRepository, PrincipalPositionRepository>();
        }
        public static void PrincipalReasonServices(this IServiceCollection Services)
        {
            Services.AddScoped<IPrincipalReasonService, PrincipalReasonService>();
            Services.AddScoped<IPrincipalReasonRepository, PrincipalReasonRepository>();
        }
        public static void PrincipalPlaceServices(this IServiceCollection Services)
        {
            Services.AddScoped<IPrincipalPlaceService, PrincipalPlaceService>();
            Services.AddScoped<IPrincipalPlaceRepository, PrincipalPlaceRepository>();
        }
        public static void PrincipalNameServices(this IServiceCollection Services)
        {
            Services.AddScoped<IPrincipalNameRepository, PrincipalNameRepository>();
            Services.AddScoped<IPrincipalNameService, PrincipalNameService>();
        }
        public static void ReceiversPassportTypeServices(this IServiceCollection Services)
        {
            Services.AddScoped<IReceiversPassportTypeService, ReceiversPassportTypeService>();
            Services.AddScoped<IReceiversPassportTypeRepository, ReceiversPassportTypeRepository>();
        }
        public static void Postgress(this IServiceCollection Services, string connectionString)
        {
            Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(connectionString, b => b.MigrationsAssembly("ConnectionProvider")).UseLazyLoadingProxies());
        }
        public static void MsSql(this IServiceCollection Services, string connectionString)
        {
            Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("ConnectionProvider")).UseLazyLoadingProxies());
        }
        public static void PurposeServices(this IServiceCollection Services)
        {
            Services.AddScoped<IPurposeRepository, PurposeRepository>();
            Services.AddScoped<IPurposeService, PurposeService>();
        }
        public static void AddAuthentication(this IServiceCollection Services, WebApplicationBuilder builder)
        {
            Services.AddAuthentication(opt =>
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
        }
    }
}
