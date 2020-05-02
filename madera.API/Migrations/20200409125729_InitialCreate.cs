using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace madera.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "varchar(75)", nullable: false),
                    Prenom = table.Column<string>(type: "varchar(60)", nullable: false),
                    Email = table.Column<string>(type: "varchar(180)", nullable: false),
                    Password = table.Column<string>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_utilisateur_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_Email",
                table: "utilisateur",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_role_id",
                table: "utilisateur",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "utilisateur");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
