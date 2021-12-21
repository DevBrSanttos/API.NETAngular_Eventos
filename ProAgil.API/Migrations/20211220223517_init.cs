﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    eventoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    imagemURL = table.Column<string>(nullable: true),
                    local = table.Column<string>(nullable: true),
                    dataEvento = table.Column<string>(nullable: true),
                    tema = table.Column<string>(nullable: true),
                    qtdPessoas = table.Column<int>(nullable: false),
                    lote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.eventoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
