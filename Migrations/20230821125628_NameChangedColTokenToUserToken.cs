using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class NameChangedColTokenToUserToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("c12c22cc-b4e2-4a2a-be80-d1475ef317aa"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("23bd2825-b29e-47d0-90a2-60873e064480"));

            migrationBuilder.RenameColumn(
                name: "token",
                table: "tbl_users",
                newName: "user_token");

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("59ae4bad-09b7-4876-af24-3a60feb299e0"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no", "user_token" },
                values: new object[] { new Guid("27b7919c-040f-451b-b940-9fc2331eb348"), new Guid("59ae4bad-09b7-4876-af24-3a60feb299e0"), true, "Enexol@123", "admin@metering.com", "Administrator", "Metering", "Admin", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "user_token",
                table: "tbl_users",
                newName: "token");

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("23bd2825-b29e-47d0-90a2-60873e064480"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("c12c22cc-b4e2-4a2a-be80-d1475ef317aa"), new Guid("23bd2825-b29e-47d0-90a2-60873e064480"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }
    }
}
