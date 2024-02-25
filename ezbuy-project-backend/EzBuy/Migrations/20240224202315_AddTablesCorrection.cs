using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzBuy.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Group_GroupId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Rule_RuleId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_User_UserId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_GroupId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_RuleId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Tenant_UserId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "RuleId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "root_schema",
                table: "Tenant");

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantId",
                schema: "root_schema",
                table: "User",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_TenantId",
                schema: "root_schema",
                table: "Rule",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_TenantId",
                schema: "root_schema",
                table: "Group",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Tenant_TenantId",
                schema: "root_schema",
                table: "Group",
                column: "TenantId",
                principalSchema: "root_schema",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rule_Tenant_TenantId",
                schema: "root_schema",
                table: "Rule",
                column: "TenantId",
                principalSchema: "root_schema",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Tenant_TenantId",
                schema: "root_schema",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Rule_Tenant_TenantId",
                schema: "root_schema",
                table: "Rule");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Tenant_TenantId",
                schema: "root_schema",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TenantId",
                schema: "root_schema",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Rule_TenantId",
                schema: "root_schema",
                table: "Rule");

            migrationBuilder.DropIndex(
                name: "IX_Group_TenantId",
                schema: "root_schema",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                schema: "root_schema",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RuleId",
                schema: "root_schema",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "root_schema",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Group_GroupId",
                schema: "root_schema",
                table: "Tenant",
                column: "GroupId",
                principalSchema: "root_schema",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Rule_RuleId",
                schema: "root_schema",
                table: "Tenant",
                column: "RuleId",
                principalSchema: "root_schema",
                principalTable: "Rule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_User_UserId",
                schema: "root_schema",
                table: "Tenant",
                column: "UserId",
                principalSchema: "root_schema",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
