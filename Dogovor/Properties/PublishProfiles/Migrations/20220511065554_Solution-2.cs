using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionProvider.Migrations
{
    public partial class Solution2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "citizenships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "principalNames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "principalPlaces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "principalPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "principalReasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "purposes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "purposes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "purposes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "receiversPassportTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { 1, "шиносномаи" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });
        }
    }
}
