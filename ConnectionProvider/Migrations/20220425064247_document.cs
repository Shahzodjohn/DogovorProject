using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionProvider.Migrations
{
    public partial class document : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "citizenships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenOf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citizenships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "principalNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrincipalFullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_principalNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "principalPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrincipalPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_principalPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "principalPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_principalPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "principalReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_principalReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "purposes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "receiversPassportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receiversPassportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityId = table.Column<int>(type: "int", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_documents_cities_cityId",
                        column: x => x.cityId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "principalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrincipalPlaceId = table.Column<int>(type: "int", nullable: false),
                    PrincipalPositionId = table.Column<int>(type: "int", nullable: false),
                    PrincipalNameId = table.Column<int>(type: "int", nullable: false),
                    PrincipalReasonId = table.Column<int>(type: "int", nullable: false),
                    ReceiversAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_principalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_principalInfos_principalNames_PrincipalNameId",
                        column: x => x.PrincipalNameId,
                        principalTable: "principalNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_principalInfos_principalPlaces_PrincipalPlaceId",
                        column: x => x.PrincipalPlaceId,
                        principalTable: "principalPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_principalInfos_principalPositions_PrincipalPositionId",
                        column: x => x.PrincipalPositionId,
                        principalTable: "principalPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_principalInfos_principalReasons_PrincipalReasonId",
                        column: x => x.PrincipalReasonId,
                        principalTable: "principalReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receiverInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiversFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiversPassportTypeId = table.Column<int>(type: "int", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportPlaceOfIssue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportDateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    СitizenshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receiverInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receiverInfos_citizenships_СitizenshipId",
                        column: x => x.СitizenshipId,
                        principalTable: "citizenships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receiverInfos_receiversPassportTypes_ReceiversPassportTypeId",
                        column: x => x.ReceiversPassportTypeId,
                        principalTable: "receiversPassportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "formsToFill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    documentId = table.Column<int>(type: "int", nullable: true),
                    principalInfoId = table.Column<int>(type: "int", nullable: true),
                    receiversInfoId = table.Column<int>(type: "int", nullable: true),
                    purposeId = table.Column<int>(type: "int", nullable: true),
                    validFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    validUntill = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formsToFill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_formsToFill_documents_documentId",
                        column: x => x.documentId,
                        principalTable: "documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_formsToFill_principalInfos_principalInfoId",
                        column: x => x.principalInfoId,
                        principalTable: "principalInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_formsToFill_purposes_purposeId",
                        column: x => x.purposeId,
                        principalTable: "purposes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_formsToFill_receiverInfos_receiversInfoId",
                        column: x => x.receiversInfoId,
                        principalTable: "receiverInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "CityName" },
                values: new object[] { 1, "г.Душанбе" });

            migrationBuilder.InsertData(
                table: "citizenships",
                columns: new[] { "Id", "CitizenOf" },
                values: new object[] { 1, "шаҳрванди Ҷумҳурии Тоҷикистон" });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Отдел по работе с партнерами" },
                    { 2, "Отдел кадров" }
                });

            migrationBuilder.InsertData(
                table: "principalNames",
                columns: new[] { "Id", "PrincipalFullName" },
                values: new object[] { 1, "Курбонов Абдулло У." });

            migrationBuilder.InsertData(
                table: "principalPlaces",
                columns: new[] { "Id", "PrincipalPlaceName" },
                values: new object[] { 1, "Ҷамъияти саҳомии кушодаи «Алиф Бонк»" });

            migrationBuilder.InsertData(
                table: "principalPositions",
                columns: new[] { "Id", "PositionName" },
                values: new object[] { 1, "Раис" });

            migrationBuilder.InsertData(
                table: "principalReasons",
                columns: new[] { "Id", "ReasonType" },
                values: new object[] { 1, "Оиннома" });

            migrationBuilder.InsertData(
                table: "purposes",
                columns: new[] { "Id", "PurposeText" },
                values: new object[,]
                {
                    { 1, "Салом, Оферта, ДБО, Банковский счет, Депозит" },
                    { 2, "СМИ, залог, поручительство" },
                    { 3, "Озод намудани амволи гарав" }
                });

            migrationBuilder.InsertData(
                table: "receiversPassportTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Шиносномаи Чумхурии Точикистон" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_documents_cityId",
                table: "documents",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_formsToFill_documentId",
                table: "formsToFill",
                column: "documentId");

            migrationBuilder.CreateIndex(
                name: "IX_formsToFill_principalInfoId",
                table: "formsToFill",
                column: "principalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_formsToFill_purposeId",
                table: "formsToFill",
                column: "purposeId");

            migrationBuilder.CreateIndex(
                name: "IX_formsToFill_receiversInfoId",
                table: "formsToFill",
                column: "receiversInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_principalInfos_PrincipalNameId",
                table: "principalInfos",
                column: "PrincipalNameId");

            migrationBuilder.CreateIndex(
                name: "IX_principalInfos_PrincipalPlaceId",
                table: "principalInfos",
                column: "PrincipalPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_principalInfos_PrincipalPositionId",
                table: "principalInfos",
                column: "PrincipalPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_principalInfos_PrincipalReasonId",
                table: "principalInfos",
                column: "PrincipalReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_receiverInfos_СitizenshipId",
                table: "receiverInfos",
                column: "СitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_receiverInfos_ReceiversPassportTypeId",
                table: "receiverInfos",
                column: "ReceiversPassportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_users_DepartmentId",
                table: "users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "formsToFill");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "principalInfos");

            migrationBuilder.DropTable(
                name: "purposes");

            migrationBuilder.DropTable(
                name: "receiverInfos");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "principalNames");

            migrationBuilder.DropTable(
                name: "principalPlaces");

            migrationBuilder.DropTable(
                name: "principalPositions");

            migrationBuilder.DropTable(
                name: "principalReasons");

            migrationBuilder.DropTable(
                name: "citizenships");

            migrationBuilder.DropTable(
                name: "receiversPassportTypes");
        }
    }
}
