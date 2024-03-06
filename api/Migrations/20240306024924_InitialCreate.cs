using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pnp_m_general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    typegroup = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    typename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    typevalue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    typeevent = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    deleted_flag = table.Column<decimal>(type: "numeric(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pnp_m_general");
        }
    }
}
