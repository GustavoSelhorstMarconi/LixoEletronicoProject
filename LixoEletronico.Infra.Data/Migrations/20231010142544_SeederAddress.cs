using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LixoEletronico.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeederAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Adresses(Number, Street, District, City, State, Country)\r\nVALUES\r\n(588, 'Itajai', 'Warta', 'Londrina', 'Paraná', 'Brasil'),\r\n(1127, 'Rua', 'Bairro', 'Cidade', 'Estado', 'País'),\r\n(1, 'Rua do teste', 'Bairro do teste', 'Cidade do teste', 'Estado do teste', 'Pais do teste')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELTE FROM Adresses");
        }
    }
}
