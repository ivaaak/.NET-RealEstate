using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientsMicroservice.Migrations.ClientsDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Client_Id = table.Column<string>(type: "text", nullable: false),
                    Client_Name = table.Column<string>(type: "text", nullable: true),
                    Client_Address = table.Column<string>(type: "text", nullable: true),
                    Contact_Person = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    EMail = table.Column<string>(type: "text", nullable: true),
                    Client_Details = table.Column<string>(type: "text", nullable: true),
                    Time_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Client_Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: true),
                    Employee_Id = table.Column<int>(type: "integer", nullable: false),
                    Estate_Id = table.Column<int>(type: "integer", nullable: false),
                    Contact_Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Contact_Details = table.Column<string>(type: "text", nullable: true),
                    Client_Id = table.Column<string>(type: "text", nullable: true),
                    ApplicationUser_Id = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Clients_Contact_Details",
                        column: x => x.Contact_Details,
                        principalTable: "Clients",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Client_Id = table.Column<string>(type: "text", nullable: true),
                    Client_Id1 = table.Column<string>(type: "text", nullable: true),
                    Employee_Id = table.Column<string>(type: "text", nullable: true),
                    Contract_Type_Id = table.Column<int>(type: "integer", nullable: false),
                    Contract_Details = table.Column<string>(type: "text", nullable: true),
                    Payment_Frequency_Id = table.Column<int>(type: "integer", nullable: false),
                    Number_Of_Invoices = table.Column<int>(type: "integer", nullable: false),
                    Payment_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Fee_Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    Fee_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date_Signed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Transaction_Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Clients_Client_Id1",
                        column: x => x.Client_Id1,
                        principalTable: "Clients",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Client_Id = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRole_Clients_Client_Id",
                        column: x => x.Client_Id,
                        principalTable: "Clients",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Client_Id",
                table: "Clients",
                column: "Client_Id",
                unique: true);

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
                name: "IX_Contract_Client_Id1",
                table: "Contract",
                column: "Client_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_Client_Id",
                table: "IdentityRole",
                column: "Client_Id");
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
                name: "Clients");
        }
    }
}
