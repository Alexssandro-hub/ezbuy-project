using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EzBuy.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Tenant_TenantId",
                schema: "root_schema",
                table: "User");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "root_schema");

            migrationBuilder.DropTable(
                name: "Rule",
                schema: "root_schema");

            migrationBuilder.DropTable(
                name: "Tenant",
                schema: "root_schema");

            migrationBuilder.DropIndex(
                name: "IX_User_TenantId",
                schema: "root_schema",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "root_schema",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RuleId",
                schema: "root_schema",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "root_schema",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "root_schema",
                table: "User",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "root_schema",
                table: "User",
                columns: new[] { "Id", "Email", "FullName", "IsActive", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "admin@ezbuy.com.br", "", true, "Admin", "System", "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "root_schema",
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "root_schema",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                schema: "root_schema",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleId",
                schema: "root_schema",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                schema: "root_schema",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tenant",
                schema: "root_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Database = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Domain = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Port = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Server = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rule",
                schema: "root_schema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Responsibility = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rule_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "root_schema",
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RuleId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Group_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "root_schema",
                        principalTable: "Tenant",
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

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantId",
                schema: "root_schema",
                table: "User",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_RuleId",
                schema: "root_schema",
                table: "Group",
                column: "RuleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_TenantId",
                schema: "root_schema",
                table: "Group",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserId",
                schema: "root_schema",
                table: "Group",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rule_TenantId",
                schema: "root_schema",
                table: "Rule",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_UserId",
                schema: "root_schema",
                table: "Rule",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Tenant_TenantId",
                schema: "root_schema",
                table: "User",
                column: "TenantId",
                principalSchema: "root_schema",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
