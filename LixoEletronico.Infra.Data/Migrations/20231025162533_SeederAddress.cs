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
            migrationBuilder.Sql($@"
                INSERT INTO Adresses (Number, Street, District, City, State, Country)
                VALUES (1, 'Rua', 'Bairro', 'Londrina', 'Paraná', 'Brasil'),
                (2, 'Rua para testar', 'Bairro para testar', 'Londrina para testar', 'Paraná para testar', 'Brasil para testar'),
                (3, 'Rua para testar de novo', 'Bairro para testar de novo', 'Londrina para testar de novo', 'Paraná para testar de novo', 'Brasil para testar de novo')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DELETE FROM Address;");
        }
    }
}
