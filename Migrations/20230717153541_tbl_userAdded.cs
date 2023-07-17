using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeteringManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class tbl_userAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "tbl_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "is_active", "password", "token", "user_email_address", "user_first_name", "user_last_name", "user_name", "user_phone_no" },
                values: new object[] { new Guid("34d5f139-f0b4-4965-aa5f-c571b69f71d3"), true, "Enexol@123", "", "admin@metering.com", "Administrator", "Metering", "Admin", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbl_users",
                keyColumn: "user_id",
                keyValue: new Guid("34d5f139-f0b4-4965-aa5f-c571b69f71d3"));

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "tbl_users");
        }
    }
}
