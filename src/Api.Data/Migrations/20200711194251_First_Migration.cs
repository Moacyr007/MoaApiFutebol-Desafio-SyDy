using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    CampeaoId = table.Column<Guid>(nullable: true),
                    ViceId = table.Column<Guid>(nullable: true),
                    TerceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_CampeaoId",
                        column: x => x.CampeaoId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_TerceiroId",
                        column: x => x.TerceiroId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_ViceId",
                        column: x => x.ViceId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Time1Id = table.Column<Guid>(nullable: true),
                    Gols1 = table.Column<int>(nullable: false),
                    Time2Id = table.Column<Guid>(nullable: true),
                    Gols2 = table.Column<int>(nullable: false),
                    CampeonatoEntityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Campeonato_CampeonatoEntityId",
                        column: x => x.CampeonatoEntityId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partida_Time_Time1Id",
                        column: x => x.Time1Id,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partida_Time_Time2Id",
                        column: x => x.Time2Id,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontuacaoCampeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    TimeId = table.Column<Guid>(nullable: true),
                    CampeonatoId = table.Column<Guid>(nullable: true),
                    Pontuacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontuacaoCampeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontuacaoCampeonato_Campeonato_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontuacaoCampeonato_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_CampeaoId",
                table: "Campeonato",
                column: "CampeaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_TerceiroId",
                table: "Campeonato",
                column: "TerceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_ViceId",
                table: "Campeonato",
                column: "ViceId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_CampeonatoEntityId",
                table: "Partida",
                column: "CampeonatoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_Time1Id",
                table: "Partida",
                column: "Time1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_Time2Id",
                table: "Partida",
                column: "Time2Id");

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoCampeonato_CampeonatoId",
                table: "PontuacaoCampeonato",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoCampeonato_TimeId",
                table: "PontuacaoCampeonato",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_Nome",
                table: "Time",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "PontuacaoCampeonato");

            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
