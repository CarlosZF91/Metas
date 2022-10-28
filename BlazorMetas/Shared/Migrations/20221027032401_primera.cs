using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMetas.Shared.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblMetas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblActividad",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importante = table.Column<bool>(type: "bit", nullable: false),
                    Concluida = table.Column<bool>(type: "bit", nullable: false),
                    MetaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblActividad_tblMetas_MetaId",
                        column: x => x.MetaId,
                        principalTable: "tblMetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblActividad_MetaId",
                table: "tblActividad",
                column: "MetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblActividad");

            migrationBuilder.DropTable(
                name: "tblMetas");
        }
    }
}
