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
            migrationBuilder.Sql("INSERT INTO Companies (Name, RepresentantId, AddressId)\r\nVALUES\r\n('Lixo mania', 1, 1),\r\n('Agili', 2, 2),\r\n('Til', 3, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Companies");
        }
    }
}
