﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserManagementApi.Models.DBModels;

#nullable disable

namespace UserManagementApi.Migrations
{
    [DbContext(typeof(DBManagementContext))]
    [Migration("20230821131044_NameChangedColUserNameToUser_UserNameOfUser")]
    partial class NameChangedColUserNameToUser_UserNameOfUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserManagementApi.Models.DBModels.DBTables.tbl_user", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("fk_user_type")
                        .HasColumnType("uuid");

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_email_address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_first_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_last_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_phone_no")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("user_id");

                    b.HasIndex("fk_user_type");

                    b.ToTable("tbl_users");

                    b.HasData(
                        new
                        {
                            user_id = new Guid("ce89f374-3fa6-4f23-8586-03f59fac5411"),
                            fk_user_type = new Guid("4d8efb44-b7ee-450d-b3a5-92a5abf1f1fc"),
                            is_active = true,
                            password = "Enexol@123",
                            user_email_address = "admin@metering.com",
                            user_first_name = "Administrator",
                            user_last_name = "Metering",
                            user_phone_no = "",
                            user_token = "",
                            user_username = "Admin"
                        });
                });

            modelBuilder.Entity("UserManagementApi.Models.DBModels.DBTables.tbl_user_type", b =>
                {
                    b.Property<Guid>("type_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<string>("type_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("type_id");

                    b.ToTable("tbl_user_types");

                    b.HasData(
                        new
                        {
                            type_id = new Guid("4d8efb44-b7ee-450d-b3a5-92a5abf1f1fc"),
                            is_active = true,
                            type_name = "Administrator"
                        });
                });

            modelBuilder.Entity("UserManagementApi.Models.DBModels.DBTables.tbl_user", b =>
                {
                    b.HasOne("UserManagementApi.Models.DBModels.DBTables.tbl_user_type", "user_type")
                        .WithMany("users")
                        .HasForeignKey("fk_user_type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user_type");
                });

            modelBuilder.Entity("UserManagementApi.Models.DBModels.DBTables.tbl_user_type", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
