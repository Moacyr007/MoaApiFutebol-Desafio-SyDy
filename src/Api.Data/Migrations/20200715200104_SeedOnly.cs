using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt" },
                values: new object[] { new Guid("c6195935-fc56-47e8-8d55-47538b89b733"), null, "Palmeiras", null });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt" },
                values: new object[] { new Guid("45ca59d1-d67e-49ae-b0de-40ce8cd35421"), null, "Luverdense", null });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Nome", "UpdateAt" },
                values: new object[] { new Guid("74e03c54-10ff-482d-85e3-86e3802f41b5"), null, "Flamengo", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("45ca59d1-d67e-49ae-b0de-40ce8cd35421"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("74e03c54-10ff-482d-85e3-86e3802f41b5"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("c6195935-fc56-47e8-8d55-47538b89b733"));
        }
    }
}
