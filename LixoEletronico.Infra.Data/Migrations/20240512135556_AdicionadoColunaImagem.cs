﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LixoEletronico.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoColunaImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Companies",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");
        }
    }
}
