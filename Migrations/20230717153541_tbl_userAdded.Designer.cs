﻿// <auto-generated />
using System;
using UserManagementApi.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UserManagementApi.Migrations
{
    [DbContext(typeof(DBManagementContext))]
    [Migration("20230717153541_tbl_userAdded")]
    partial class tbl_userAdded
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

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("token")
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

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_phone_no")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("user_id");

                    b.ToTable("tbl_users");

                    b.HasData(
                        new
                        {
                            user_id = new Guid("34d5f139-f0b4-4965-aa5f-c571b69f71d3"),
                            is_active = true,
                            password = "Enexol@123",
                            token = "",
                            user_email_address = "admin@metering.com",
                            user_first_name = "Administrator",
                            user_last_name = "Metering",
                            user_name = "Admin",
                            user_phone_no = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
