// <auto-generated />
using System;
using ConnectionProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConnectionProvider.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220425064247_document")]
    partial class document
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entity.Entities.Citizenship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CitizenOf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("citizenships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CitizenOf = "шаҳрванди Ҷумҳурии Тоҷикистон"
                        });
                });

            modelBuilder.Entity("Entity.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "г.Душанбе"
                        });
                });

            modelBuilder.Entity("Entity.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentName = "Отдел по работе с партнерами"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentName = "Отдел кадров"
                        });
                });

            modelBuilder.Entity("Entity.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cityId");

                    b.ToTable("documents");
                });

            modelBuilder.Entity("Entity.Entities.FormToFill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("documentId")
                        .HasColumnType("int");

                    b.Property<int?>("principalInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("purposeId")
                        .HasColumnType("int");

                    b.Property<int?>("receiversInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("validFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("validUntill")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("documentId");

                    b.HasIndex("principalInfoId");

                    b.HasIndex("purposeId");

                    b.HasIndex("receiversInfoId");

                    b.ToTable("formsToFill");
                });

            modelBuilder.Entity("Entity.Entities.PrincipalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PrincipalNameId")
                        .HasColumnType("int");

                    b.Property<int>("PrincipalPlaceId")
                        .HasColumnType("int");

                    b.Property<int>("PrincipalPositionId")
                        .HasColumnType("int");

                    b.Property<int>("PrincipalReasonId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiversAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrincipalNameId");

                    b.HasIndex("PrincipalPlaceId");

                    b.HasIndex("PrincipalPositionId");

                    b.HasIndex("PrincipalReasonId");

                    b.ToTable("principalInfos");
                });

            modelBuilder.Entity("Entity.Entities.PrincipalName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PrincipalFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("principalNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PrincipalFullName = "Курбонов Абдулло У."
                        });
                });

            modelBuilder.Entity("Entity.Entities.PrincipalPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PrincipalPlaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("principalPlaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PrincipalPlaceName = "Ҷамъияти саҳомии кушодаи «Алиф Бонк»"
                        });
                });

            modelBuilder.Entity("Entity.Entities.PrincipalPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("principalPositions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PositionName = "Раис"
                        });
                });

            modelBuilder.Entity("Entity.Entities.PrincipalReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ReasonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("principalReasons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ReasonType = "Оиннома"
                        });
                });

            modelBuilder.Entity("Entity.Entities.Purpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PurposeText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("purposes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PurposeText = "Салом, Оферта, ДБО, Банковский счет, Депозит"
                        },
                        new
                        {
                            Id = 2,
                            PurposeText = "СМИ, залог, поручительство"
                        },
                        new
                        {
                            Id = 3,
                            PurposeText = "Озод намудани амволи гарав"
                        });
                });

            modelBuilder.Entity("Entity.Entities.ReceiverInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("PassportDateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportPlaceOfIssue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiversFullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiversPassportTypeId")
                        .HasColumnType("int");

                    b.Property<int>("СitizenshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiversPassportTypeId");

                    b.HasIndex("СitizenshipId");

                    b.ToTable("receiverInfos");
                });

            modelBuilder.Entity("Entity.Entities.ReceiversPassportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("receiversPassportTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Шиносномаи Чумхурии Точикистон"
                        });
                });

            modelBuilder.Entity("Entity.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Entity.Entities.Document", b =>
                {
                    b.HasOne("Entity.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Entity.Entities.FormToFill", b =>
                {
                    b.HasOne("Entity.Entities.Document", "Document")
                        .WithMany()
                        .HasForeignKey("documentId");

                    b.HasOne("Entity.Entities.PrincipalInfo", "PrincipalInfo")
                        .WithMany()
                        .HasForeignKey("principalInfoId");

                    b.HasOne("Entity.Entities.Purpose", "Purpose")
                        .WithMany()
                        .HasForeignKey("purposeId");

                    b.HasOne("Entity.Entities.ReceiverInfo", "ReceiversInfo")
                        .WithMany()
                        .HasForeignKey("receiversInfoId");

                    b.Navigation("Document");

                    b.Navigation("PrincipalInfo");

                    b.Navigation("Purpose");

                    b.Navigation("ReceiversInfo");
                });

            modelBuilder.Entity("Entity.Entities.PrincipalInfo", b =>
                {
                    b.HasOne("Entity.Entities.PrincipalName", "PrincipalName")
                        .WithMany()
                        .HasForeignKey("PrincipalNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Entities.PrincipalPlace", "PrincipalPlace")
                        .WithMany()
                        .HasForeignKey("PrincipalPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Entities.PrincipalPosition", "PrincipalPosition")
                        .WithMany()
                        .HasForeignKey("PrincipalPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Entities.PrincipalReason", "PrincipalReason")
                        .WithMany()
                        .HasForeignKey("PrincipalReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrincipalName");

                    b.Navigation("PrincipalPlace");

                    b.Navigation("PrincipalPosition");

                    b.Navigation("PrincipalReason");
                });

            modelBuilder.Entity("Entity.Entities.ReceiverInfo", b =>
                {
                    b.HasOne("Entity.Entities.ReceiversPassportType", "ReceiversPassportType")
                        .WithMany()
                        .HasForeignKey("ReceiversPassportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Entities.Citizenship", "Citizenship")
                        .WithMany()
                        .HasForeignKey("СitizenshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citizenship");

                    b.Navigation("ReceiversPassportType");
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.HasOne("Entity.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
