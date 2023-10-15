using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LixoEletronico.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeederPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO People (Name, Email, IsRepresentant)\r\nVALUES\r\n('Teste 1', 'teste@teste1.com', 0),\r\n('Rogerinho', 'teste@teste2.com', 1),\r\n('Brasileiro', 'teste@teste3.com', 0),\r\n('Otangurango', 'teste@teste4.com', 0),\r\n('Douglas', 'teste@teste5.com', 1)\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM People");
        }
    }
}
