using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "PdpaConsents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Con_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TitleTH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleZH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionTH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionZH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdpaConsents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdpaPrivacyPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PP_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TitleTH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleZH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionTH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionZH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdpaPrivacyPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pnp_m_general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typegroup = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    typename = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    typevalue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    typeevent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    deleted_flag = table.Column<long>(type: "bigint", nullable: true)
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
                name: "PdpaConsents");

            migrationBuilder.DropTable(
                name: "PdpaPrivacyPolicies");

            migrationBuilder.DropTable(
                name: "pnp_m_general");
        }
    }
}
