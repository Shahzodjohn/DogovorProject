using Entity;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConnectionProvider
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Citizenship> citizenships { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<FormToFill> formsToFill { get; set; }
        public DbSet<PrincipalInfo> principalInfos { get; set; }
        public DbSet<PrincipalName> principalNames { get; set; }
        public DbSet<PrincipalPlace> principalPlaces { get; set; }
        public DbSet<PrincipalPosition> principalPositions { get; set; }
        public DbSet<PrincipalReason> principalReasons { get; set; }
        public DbSet<Purpose> purposes {get;set;}
        public DbSet<ReceiverInfo> receiverInfos {get;set;}
        public DbSet<ReceiversPassportType> receiversPassportTypes{get;set;}
        public DbSet<ResetPassword> resetPasswords {get;set;}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>().HasData(new Role { Id = 1, RoleName = "Admin" }, new Role { Id = 2, RoleName = "User" });
            builder.Entity<Department>().HasData(new Department { Id = 1, DepartmentName = "Отдел по работе с партнерами" }, new Department { Id = 2, DepartmentName = "Отдел кадров" });
            builder.Entity<City>().HasData(new City { Id = 1, CityName = "г.Душанбе" });
            builder.Entity<PrincipalPlace>().HasData(new PrincipalPlace { Id = 1, PrincipalPlaceName = "Ҷамъияти саҳомии кушодаи «Алиф Бонк»" });
            builder.Entity<PrincipalPosition>().HasData(new PrincipalPosition { Id = 1, PositionName = "Раис" });
            builder.Entity<PrincipalName>().HasData(new PrincipalName { Id = 1, PrincipalFullName = "Курбонов Абдулло У." });
            builder.Entity<PrincipalReason>().HasData(new PrincipalReason { Id = 1, ReasonType = "Оиннома" });
            builder.Entity<Citizenship>().HasData(new Citizenship { Id = 1, CitizenOf = "шаҳрванди Ҷумҳурии Тоҷикистон" });
            builder.Entity<ReceiversPassportType>().HasData(new ReceiversPassportType { Id = 1, Type = "шиносномаи" });
            builder.Entity<Purpose>().HasData(new Purpose { Id = 1, PurposeText = "Салом, Оферта, ДБО, Банковский счет, Депозит" },
                                              new Purpose { Id = 2, PurposeText = "СМИ, залог, поручительство" },
                                              new Purpose { Id = 3, PurposeText = "Озод намудани амволи гарав" });
            
        }

        //builder.Entity<PrincipalReason>()

    }
}
