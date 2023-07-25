using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingBckDttest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("62ac4de7-39a0-4aca-8188-dd8f4f208cfb"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("e3ea3f56-a219-41a2-a974-df0318441804"));

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("3be9c2f0-0924-4ab3-9103-50108604c4c4"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("c6bcb59a-53ed-4ded-bf5e-41f133f7523e"), new Guid("3be9c2f0-0924-4ab3-9103-50108604c4c4"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("c6bcb59a-53ed-4ded-bf5e-41f133f7523e"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("3be9c2f0-0924-4ab3-9103-50108604c4c4"));

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("e3ea3f56-a219-41a2-a974-df0318441804"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("62ac4de7-39a0-4aca-8188-dd8f4f208cfb"), new Guid("e3ea3f56-a219-41a2-a974-df0318441804"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }
    }
}
