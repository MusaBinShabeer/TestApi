using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class newtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("1259b6fb-fde3-430e-b2f7-22da18b08bde"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("73d04d9b-b178-43d5-836d-22d37e819d5d"));

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("23bd2825-b29e-47d0-90a2-60873e064480"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("c12c22cc-b4e2-4a2a-be80-d1475ef317aa"), new Guid("23bd2825-b29e-47d0-90a2-60873e064480"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("c12c22cc-b4e2-4a2a-be80-d1475ef317aa"));

            migrationBuilder.DeleteData(
                table: "tbl_user_types",
                keyColumn: "type_id",
                keyValue: new Guid("23bd2825-b29e-47d0-90a2-60873e064480"));

            migrationBuilder.InsertData(
                table: "tbl_user_types",
                columns: new[] { "type_id", "is_active", "type_name" },
                values: new object[] { new Guid("73d04d9b-b178-43d5-836d-22d37e819d5d"), true, "Administrator" });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "fk_user_type", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("1259b6fb-fde3-430e-b2f7-22da18b08bde"), new Guid("73d04d9b-b178-43d5-836d-22d37e819d5d"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }
    }
}
