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
            migrationBuilder.Sql($@"INSERT INTO People (Name, Email, IsRepresentant)
                VALUES ('Teste 1', 'testando1@email.com', 0),
                ('Teste 2', 'testando2@email.com', 0),
                ('Teste 3', 'testando3@email.com', 1),
                ('Teste 4', 'testando4@email.com', 1),
                ('Teste 5', 'testando5@email.com', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DELETE FROM People");
        }
    }
}
