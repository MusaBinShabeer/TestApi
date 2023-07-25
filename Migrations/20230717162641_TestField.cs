using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class TestField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("c6bcb59a-53ed-4ded-bf5e-41f133f7523e"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("3be9c2f0-0924-4ab3-9103-50108604c4c4"));

            migrationBuilder.AddColumn<string>(
                name: "testField",
                table: "tbl_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("e6e4723d-8489-46bc-838e-ef1bd5efff9d"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "testField", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("b67b517c-c6c4-4e58-9397-b1f675e7851e"), new Guid("e6e4723d-8489-46bc-838e-ef1bd5efff9d"), true, "Enexol@123", "", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("b67b517c-c6c4-4e58-9397-b1f675e7851e"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("e6e4723d-8489-46bc-838e-ef1bd5efff9d"));

            migrationBuilder.DropColumn(
                name: "testField",
                table: "tbl_users");

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("3be9c2f0-0924-4ab3-9103-50108604c4c4"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("c6bcb59a-53ed-4ded-bf5e-41f133f7523e"), new Guid("3be9c2f0-0924-4ab3-9103-50108604c4c4"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }
    }
}
