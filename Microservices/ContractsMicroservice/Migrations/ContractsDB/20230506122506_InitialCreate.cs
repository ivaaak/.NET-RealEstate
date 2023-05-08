using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ContractsMicroservice.Migrations.ContractsDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
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
                    table.PrimaryKey("PK_Client", x => x.Client_Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract_Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Contract_Invoice_Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Contract_Type_Name = table.Column<string>(type: "text", nullable: true),
                    Fee_Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Frequencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Payment_Frequency_Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Frequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Under_Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Estate_Id = table.Column<int>(type: "integer", nullable: false),
                    Contract_Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Under_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
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
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Client_Client_Id",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Client_Id = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Client_Client_Id",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_IdentityRole_Client_Client_Id",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Client_Id",
                table: "Contact",
                column: "Client_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Invoices_Id",
                table: "Contract_Invoices",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Type_Id",
                table: "Contract_Type",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Client_Id",
                table: "Contracts",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Id",
                table: "Contracts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_Client_Id",
                table: "IdentityRole",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Frequencies_Id",
                table: "Payment_Frequencies",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Under_Contracts_Id",
                table: "Under_Contracts",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Contract_Invoices");

            migrationBuilder.DropTable(
                name: "Contract_Type");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "Payment_Frequencies");

            migrationBuilder.DropTable(
                name: "Under_Contracts");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
