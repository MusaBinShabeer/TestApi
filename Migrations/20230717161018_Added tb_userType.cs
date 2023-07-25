using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class Addedtb_userType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("34d5f139-f0b4-4965-aa5f-c571b69f71d3"));

            migrationBuilder.AddColumn<Guid>(
                name: "fk_user_type",
                table: "tbl_users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tbl_user_types",
                columns: table => new
                {
                    type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_name = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_types", x => x.type_id);
                });

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("e3ea3f56-a219-41a2-a974-df0318441804"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("62ac4de7-39a0-4aca-8188-dd8f4f208cfb"), new Guid("e3ea3f56-a219-41a2-a974-df0318441804"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_fk_user_type",
                table: "tbl_users",
                column: "fk_user_type");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_users_tbl_user_types_fk_user_type",
                table: "tbl_users",
                column: "fk_user_type",
                principalTable: "tbl_user_types",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_users_tbl_user_types_fk_user_type",
                table: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_user_types");

            migrationBuilder.DropIndex(
                name: "IX_tbl_users_fk_user_type",
                table: "tbl_users");

            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("62ac4de7-39a0-4aca-8188-dd8f4f208cfb"));

            migrationBuilder.DropColumn(
                name: "fk_user_type",
                table: "tbl_users");

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("34d5f139-f0b4-4965-aa5f-c571b69f71d3"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }
    }
}
