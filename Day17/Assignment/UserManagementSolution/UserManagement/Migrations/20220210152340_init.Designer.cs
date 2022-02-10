﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Models;

#nullable disable

namespace UserManagement.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20220210152340_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserManagement.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"), 1L, 1);

                    b.Property<string>("user_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            user_id = 101,
                            user_email = "raindy@email.com",
                            user_name = "Raindy Keng",
                            user_password = "123123Aa@"
                        },
                        new
                        {
                            user_id = 102,
                            user_email = "jane123123@email.com",
                            user_name = "Jane Wong",
                            user_password = "123123Aa@"
                        },
                        new
                        {
                            user_id = 103,
                            user_email = "jupiterleong@email.com",
                            user_name = "Jupiter Leong",
                            user_password = "123123Aa@"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
