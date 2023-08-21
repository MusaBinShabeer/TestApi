using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class NameChangedColUserNameToUser_UserNameOfUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("27b7919c-040f-451b-b940-9fc2331eb348"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("59ae4bad-09b7-4876-af24-3a60feb299e0"));

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "tbl_users",
                newName: "user_username");

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("4d8efb44-b7ee-450d-b3a5-92a5abf1f1fc"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "user_email_address", "user_first_name", "user_last_name", "user_phone_no", "user_token", "user_username" },
                values: new object[] { new Guid("ce89f374-3fa6-4f23-8586-03f59fac5411"), new Guid("4d8efb44-b7ee-450d-b3a5-92a5abf1f1fc"), true, "Enexol@123", "admin@metering.com", "Administrator", "Metering", "", "", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("ce89f374-3fa6-4f23-8586-03f59fac5411"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("4d8efb44-b7ee-450d-b3a5-92a5abf1f1fc"));

            migrationBuilder.RenameColumn(
                name: "user_username",
                table: "tbl_users",
                newName: "user_name");

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("59ae4bad-09b7-4876-af24-3a60feb299e0"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no", "user_token" },
                values: new object[] { new Guid("27b7919c-040f-451b-b940-9fc2331eb348"), new Guid("59ae4bad-09b7-4876-af24-3a60feb299e0"), true, "Enexol@123", "admin@metering.com", "Administrator", "Metering", "Admin", "", "" });
        }
    }
}
