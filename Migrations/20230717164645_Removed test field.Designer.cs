﻿// <auto-generated />
using System;
using MeteringManagementApi.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MeteringManagementApi.Migrations
{
    [DbContext(typeof(DBManagementContext))]
    [Migration("20230717164645_Removed test field")]
    partial class Removedtestfield
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MeteringManagementApi.Models.DBModels.DBTables.tbl_user", b =>
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

                    b.HasIndex("fk_user_type");

                    b.ToTable("tbl_users");

                    b.HasData(
                        new
                        {
                            user_id = new Guid("1259b6fb-fde3-430e-b2f7-22da18b08bde"),
                            fk_user_type = new Guid("73d04d9b-b178-43d5-836d-22d37e819d5d"),
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

            modelBuilder.Entity("MeteringManagementApi.Models.DBModels.DBTables.tbl_user_type", b =>
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
                            type_id = new Guid("73d04d9b-b178-43d5-836d-22d37e819d5d"),
                            is_active = true,
                            type_name = "Administrator"
                        });
                });

            modelBuilder.Entity("MeteringManagementApi.Models.DBModels.DBTables.tbl_user", b =>
                {
                    b.HasOne("MeteringManagementApi.Models.DBModels.DBTables.tbl_user_type", "user_type")
                        .WithMany("users")
                        .HasForeignKey("fk_user_type")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user_type");
                });

            modelBuilder.Entity("MeteringManagementApi.Models.DBModels.DBTables.tbl_user_type", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
