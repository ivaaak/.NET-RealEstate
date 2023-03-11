using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstate.Data.Migrations.ClientsDB
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<string>(name: "Client_Id", type: "text", nullable: true),
                    ClientName = table.Column<string>(name: "Client_Name", type: "text", nullable: true),
                    ClientAddress = table.Column<string>(name: "Client_Address", type: "text", nullable: true),
                    ContactPerson = table.Column<string>(name: "Contact_Person", type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    EMail = table.Column<string>(type: "text", nullable: true),
                    ClientDetails = table.Column<string>(name: "Client_Details", type: "text", nullable: true),
                    TimeCreated = table.Column<DateTime>(name: "Time_Created", type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(name: "Employee_Id", type: "integer", nullable: false),
                    EstateId = table.Column<int>(name: "Estate_Id", type: "integer", nullable: false),
                    ContactTime = table.Column<DateTime>(name: "Contact_Time", type: "timestamp with time zone", nullable: false),
                    ContactDetails = table.Column<string>(name: "Contact_Details", type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_ApplicationUser_Contact_Details",
                        column: x => x.ContactDetails,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(name: "Client_Id", type: "integer", nullable: false),
                    ClientId0 = table.Column<string>(name: "ClientId", type: "text", nullable: false),
                    EmployeeId = table.Column<int>(name: "Employee_Id", type: "integer", nullable: false),
                    ContractTypeId = table.Column<int>(name: "Contract_Type_Id", type: "integer", nullable: false),
                    ContractDetails = table.Column<string>(name: "Contract_Details", type: "text", nullable: false),
                    PaymentFrequencyId = table.Column<int>(name: "Payment_Frequency_Id", type: "integer", nullable: false),
                    NumberOfInvoices = table.Column<int>(name: "Number_Of_Invoices", type: "integer", nullable: false),
                    PaymentAmount = table.Column<decimal>(name: "Payment_Amount", type: "numeric", nullable: false),
                    FeePercentage = table.Column<decimal>(name: "Fee_Percentage", type: "numeric", nullable: false),
                    FeeAmount = table.Column<decimal>(name: "Fee_Amount", type: "numeric", nullable: false),
                    DateSigned = table.Column<DateTime>(name: "Date_Signed", type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTime>(name: "Start_Date", type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(name: "End_Date", type: "timestamp with time zone", nullable: false),
                    TransactionId = table.Column<int>(name: "Transaction_Id", type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_ApplicationUser_ClientId",
                        column: x => x.ClientId0,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRole_ApplicationUser_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_Id",
                table: "ApplicationUser",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Contact_Details",
                table: "Contacts",
                column: "Contact_Details",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Id",
                table: "Contacts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ClientId",
                table: "Contract",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_ClientId",
                table: "IdentityRole",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
