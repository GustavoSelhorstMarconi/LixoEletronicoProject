using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LixoEletronico.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeederCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                INSERT INTO Companies(Name, RepresentantId, AddressId)
                VALUES ('Empresa ruim', 1, 1),
                ('Empresa pior', 2, 2),
                ('Empresa pior ainda', 3, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DELETE FROM Companies");
        }
    }
}
