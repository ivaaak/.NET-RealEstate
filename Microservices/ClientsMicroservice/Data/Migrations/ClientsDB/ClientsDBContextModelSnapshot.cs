﻿// <auto-generated />
using System;
using ClientsMicroservice.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientsMicroservice.Migrations.ClientsDB
{
    [DbContext(typeof(ClientsDBContext))]
    partial class ClientsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Client_Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id");

                    b.ToTable("IdentityRole");
                });

            modelBuilder.Entity("RealEstate.Shared.Models.Entities.Clients.Client", b =>
                {
                    b.Property<string>("Client_Id")
                        .HasColumnType("text");

                    b.Property<string>("Client_Address")
                        .HasColumnType("text");

                    b.Property<string>("Client_Details")
                        .HasColumnType("text");

                    b.Property<string>("Client_Name")
                        .HasColumnType("text");

                    b.Property<string>("Contact_Person")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EMail")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("Time_Created")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Client_Id");

                    b.HasIndex("Client_Id")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RealEstate.Shared.Models.Entities.Clients.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUser_Id")
                        .HasColumnType("text");

                    b.Property<string>("Client_Id")
                        .HasColumnType("text");

                    b.Property<string>("Contact_Details")
                        .HasColumnType("text");

                    b.Property<DateTime>("Contact_Time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Employee_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Estate_Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Contact_Details")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("RealEstate.Shared.Models.Entities.Contracts.Contract", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Client_Id")
                        .HasColumnType("text");

                    b.Property<string>("Client_Id1")
                        .HasColumnType("text");

                    b.Property<string>("Contract_Details")
                        .HasColumnType("text");

                    b.Property<int>("Contract_Type_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date_Signed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Employee_Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("End_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Fee_Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Fee_Percentage")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Number_Of_Invoices")
                        .HasColumnType("integer");

                    b.Property<decimal>("Payment_Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Payment_Frequency_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Transaction_Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id1");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.HasOne("RealEstate.Shared.Models.Entities.Clients.Client", null)
                        .WithMany("Roles")
                        .HasForeignKey("Client_Id");
                });

            modelBuilder.Entity("RealEstate.Shared.Models.Entities.Clients.Contact", b =>
                {
                    b.HasOne("RealEstate.Shared.Models.Entities.Clients.Client", "Client")
                        .WithOne("Contact")
                        .HasForeignKey("RealEstate.Shared.Models.Entities.Clients.Contact", "Contact_Details")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Client");
                });

            modelBuilder.Entity("RealEstate.Shared.Models.Entities.Contracts.Contract", b =>
                {
                    b.HasOne("RealEstate.Shared.Models.Entities.Clients.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("Client_Id1");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("RealEstate.Shared.Models.Entities.Clients.Client", b =>
                {
                    b.Navigation("Contact");

                    b.Navigation("Contracts");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}