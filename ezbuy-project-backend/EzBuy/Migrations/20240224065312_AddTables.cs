using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EzBuy.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "root_schema");

            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "root_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    RuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rule",
                schema: "root_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Responsibility = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rule_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "root_schema",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "root_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    RuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Rule_RuleId",
                        column: x => x.RuleId,
                        principalSchema: "root_schema",
                        principalTable: "Rule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "root_schema",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tenant",
                schema: "root_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Database = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Server = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Domain = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Port = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    RuleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "root_schema",
                        principalTable: "Group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenant_Rule_RuleId",
                        column: x => x.RuleId,
                        principalSchema: "root_schema",
                        principalTable: "Rule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tenant_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "root_schema",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Group_RuleId",
                schema: "root_schema",
                table: "Group",
                column: "RuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserId",
                schema: "root_schema",
                table: "Group",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rule_UserId",
                schema: "root_schema",
                table: "Rule",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_GroupId",
                schema: "root_schema",
                table: "Tenant",
                column: "GroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_RuleId",
                schema: "root_schema",
                table: "Tenant",
                column: "RuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_UserId",
                schema: "root_schema",
                table: "Tenant",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenant",
                schema: "root_schema");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "root_schema");

            migrationBuilder.DropTable(
                name: "Rule",
                schema: "root_schema");

            migrationBuilder.DropTable(
                name: "User",
                schema: "root_schema");
        }
    }
}
