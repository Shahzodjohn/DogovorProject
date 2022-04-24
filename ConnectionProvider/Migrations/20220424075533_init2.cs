using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionProvider.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receiverInfos_citizenships_CitizenshipId",
                table: "receiverInfos");

            migrationBuilder.DropIndex(
                name: "IX_receiverInfos_CitizenshipId",
                table: "receiverInfos");

            migrationBuilder.DropColumn(
                name: "CitizenshipId",
                table: "receiverInfos");

            migrationBuilder.CreateIndex(
                name: "IX_receiverInfos_СitizenshipId",
                table: "receiverInfos",
                column: "СitizenshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_receiverInfos_citizenships_СitizenshipId",
                table: "receiverInfos",
                column: "СitizenshipId",
                principalTable: "citizenships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receiverInfos_citizenships_СitizenshipId",
                table: "receiverInfos");

            migrationBuilder.DropIndex(
                name: "IX_receiverInfos_СitizenshipId",
                table: "receiverInfos");

            migrationBuilder.AddColumn<int>(
                name: "CitizenshipId",
                table: "receiverInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_receiverInfos_CitizenshipId",
                table: "receiverInfos",
                column: "CitizenshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_receiverInfos_citizenships_CitizenshipId",
                table: "receiverInfos",
                column: "CitizenshipId",
                principalTable: "citizenships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
