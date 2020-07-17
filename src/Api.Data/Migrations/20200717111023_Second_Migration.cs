using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Second_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Time",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "PontuacaoCampeonato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Partida",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Campeonato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Excluido", "Nome", "UpdateAt" },
                values: new object[] { new Guid("05365df3-547c-4b26-a7b0-b014455d5279"), null, false, "Palmeiras", null });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Excluido", "Nome", "UpdateAt" },
                values: new object[] { new Guid("ae8b0f02-3ec9-49e8-be6c-6f8f6a1450ef"), null, false, "Luverdense", null });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "Excluido", "Nome", "UpdateAt" },
                values: new object[] { new Guid("ce33453c-efee-4041-b6db-043dec8979ca"), null, false, "Flamengo", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("05365df3-547c-4b26-a7b0-b014455d5279"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("ae8b0f02-3ec9-49e8-be6c-6f8f6a1450ef"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("ce33453c-efee-4041-b6db-043dec8979ca"));

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Time");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "PontuacaoCampeonato");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Campeonato");

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
    }
}
