using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ListingsMicroservice.Data.Migrations.ListingsDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Address_Id = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    Neighbourhood = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<int>(type: "integer", nullable: true),
                    MapCoordinates = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Address_Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Agency_Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageURL = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Phone_Number = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Agency_Id);
                });

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
                name: "Company",
                columns: table => new
                {
                    Company_Id = table.Column<string>(type: "text", nullable: false),
                    Company_Name = table.Column<string>(type: "text", nullable: true),
                    Company_Description = table.Column<string>(type: "text", nullable: true),
                    Employee_Count = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Company_Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country_Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estate_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type_Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estate_Type", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<string>(type: "text", nullable: false),
                    First_Name = table.Column<string>(type: "text", nullable: true),
                    Last_Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employees_Company_Id",
                        column: x => x.Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City_Name = table.Column<string>(type: "text", nullable: true),
                    Country_Id = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Agent_Id = table.Column<string>(type: "text", nullable: false),
                    Agent_Name = table.Column<string>(type: "text", nullable: true),
                    Agent_Address = table.Column<string>(type: "text", nullable: true),
                    Contact_Person = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    EMail = table.Column<string>(type: "text", nullable: true),
                    Agent_Details = table.Column<string>(type: "text", nullable: true),
                    Time_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContactId = table.Column<string>(type: "text", nullable: true),
                    Agency_Id = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Agents", x => x.Agent_Id);
                    table.ForeignKey(
                        name: "FK_Agents_Agencies_Agency_Id",
                        column: x => x.Agency_Id,
                        principalTable: "Agencies",
                        principalColumn: "Agency_Id");
                    table.ForeignKey(
                        name: "FK_Agents_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
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
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Agent_Id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Agents_Agent_Id",
                        column: x => x.Agent_Id,
                        principalTable: "Agents",
                        principalColumn: "Agent_Id");
                    table.ForeignKey(
                        name: "FK_Contract_Client_Client_Id1",
                        column: x => x.Client_Id1,
                        principalTable: "Client",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstateId = table.Column<string>(type: "text", nullable: true),
                    Estate_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Comment_Id = table.Column<string>(type: "text", nullable: false),
                    Comment_Title = table.Column<string>(type: "text", nullable: true),
                    Comment_Content = table.Column<string>(type: "text", nullable: true),
                    Comment_Rating = table.Column<string>(type: "text", nullable: true),
                    Date_Posted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Listing_Id = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Comment_Id);
                });

            migrationBuilder.CreateTable(
                name: "Estate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Estate_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City_Id = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    Estate_Type_Id = table.Column<int>(type: "integer", nullable: false),
                    Floor_Space_Square_Meters = table.Column<decimal>(type: "numeric", nullable: false),
                    Number_Of_Balconies = table.Column<int>(type: "integer", nullable: false),
                    Balconies_Space = table.Column<decimal>(type: "numeric", nullable: false),
                    Number_Of_Bedrooms = table.Column<int>(type: "integer", nullable: false),
                    Number_Of_Bathrooms = table.Column<int>(type: "integer", nullable: false),
                    Number_Of_Garages = table.Column<int>(type: "integer", nullable: false),
                    Number_Of_Parking_Spaces = table.Column<int>(type: "integer", nullable: false),
                    Pets_Allowed = table.Column<bool>(type: "boolean", nullable: false),
                    Estate_Description = table.Column<string>(type: "text", nullable: true),
                    Estate_Status_Id = table.Column<string>(type: "text", nullable: true),
                    Estate_ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Estate_Year_Built = table.Column<int>(type: "integer", nullable: false),
                    Estate_Year_Listed = table.Column<int>(type: "integer", nullable: false),
                    Build_Material = table.Column<string>(type: "text", nullable: true),
                    Is_On_Floor = table.Column<int>(type: "integer", nullable: true),
                    Bulding_Floors = table.Column<int>(type: "integer", nullable: true),
                    Address_Id = table.Column<string>(type: "text", nullable: true),
                    Listing_Id = table.Column<string>(type: "text", nullable: true),
                    Estate_TypeId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    Company_Id = table.Column<string>(type: "text", nullable: true),
                    Employee_Id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estate_Addresses_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "Addresses",
                        principalColumn: "Address_Id");
                    table.ForeignKey(
                        name: "FK_Estate_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estate_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estate_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_Estate_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id");
                    table.ForeignKey(
                        name: "FK_Estate_Estate_Type_Estate_TypeId",
                        column: x => x.Estate_TypeId,
                        principalTable: "Estate_Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    Listing_Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Estate_Id = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    PricePerSquareMeter = table.Column<double>(type: "double precision", nullable: false),
                    Is_From_An_Agency = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    DateBuilt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateListed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estate_TypeId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Address_Id = table.Column<string>(type: "text", nullable: true),
                    ListingStats_Id = table.Column<int>(type: "integer", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Employee_Id = table.Column<string>(type: "text", nullable: true),
                    Agent_Id = table.Column<string>(type: "text", nullable: true),
                    Agent_Id1 = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Agency_Id = table.Column<string>(type: "text", nullable: true),
                    Company_Id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.Listing_Id);
                    table.ForeignKey(
                        name: "FK_Listings_Addresses_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "Addresses",
                        principalColumn: "Address_Id");
                    table.ForeignKey(
                        name: "FK_Listings_Agencies_Agency_Id",
                        column: x => x.Agency_Id,
                        principalTable: "Agencies",
                        principalColumn: "Agency_Id");
                    table.ForeignKey(
                        name: "FK_Listings_Agents_Agent_Id1",
                        column: x => x.Agent_Id1,
                        principalTable: "Agents",
                        principalColumn: "Agent_Id");
                    table.ForeignKey(
                        name: "FK_Listings_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listings_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_Listings_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id");
                    table.ForeignKey(
                        name: "FK_Listings_Estate_Type_Estate_TypeId",
                        column: x => x.Estate_TypeId,
                        principalTable: "Estate_Type",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Listing_Id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceHistories_Listings_Listing_Id",
                        column: x => x.Listing_Id,
                        principalTable: "Listings",
                        principalColumn: "Listing_Id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Review_Id = table.Column<string>(type: "text", nullable: false),
                    Review_Title = table.Column<string>(type: "text", nullable: true),
                    Review_Content = table.Column<string>(type: "text", nullable: true),
                    Review_Rating = table.Column<string>(type: "text", nullable: true),
                    Date_Posted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Listing_Id = table.Column<string>(type: "text", nullable: true),
                    Listing_Id1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Review_Listings_Listing_Id1",
                        column: x => x.Listing_Id1,
                        principalTable: "Listings",
                        principalColumn: "Listing_Id");
                });

            migrationBuilder.CreateTable(
                name: "ListingStats",
                columns: table => new
                {
                    ListingStats_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimesViewed = table.Column<int>(type: "integer", nullable: false),
                    TimesSaved = table.Column<int>(type: "integer", nullable: false),
                    TimesCommented = table.Column<int>(type: "integer", nullable: false),
                    TimesReviewed = table.Column<int>(type: "integer", nullable: false),
                    TimesRented = table.Column<int>(type: "integer", nullable: false),
                    TimesReported = table.Column<int>(type: "integer", nullable: false),
                    PriceHistoryId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingStats", x => x.ListingStats_Id);
                    table.ForeignKey(
                        name: "FK_ListingStats_PriceHistories_PriceHistoryId",
                        column: x => x.PriceHistoryId,
                        principalTable: "PriceHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Agency_Id",
                table: "Agents",
                column: "Agency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ContactId",
                table: "Agents",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_EstateId",
                table: "Category",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Listing_Id",
                table: "Comments",
                column: "Listing_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Client_Id",
                table: "Contact",
                column: "Client_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Agent_Id",
                table: "Contract",
                column: "Agent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Client_Id1",
                table: "Contract",
                column: "Client_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Id",
                table: "Employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_Address_Id",
                table: "Estate",
                column: "Address_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_CategoryId",
                table: "Estate",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_CityId",
                table: "Estate",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_Company_Id",
                table: "Estate",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_Employee_Id",
                table: "Estate",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estate_Estate_TypeId",
                table: "Estate",
                column: "Estate_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_Client_Id",
                table: "IdentityRole",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Address_Id",
                table: "Listings",
                column: "Address_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Agency_Id",
                table: "Listings",
                column: "Agency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Agent_Id1",
                table: "Listings",
                column: "Agent_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryId",
                table: "Listings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Company_Id",
                table: "Listings",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Employee_Id",
                table: "Listings",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_Estate_TypeId",
                table: "Listings",
                column: "Estate_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_ListingStats_Id",
                table: "Listings",
                column: "ListingStats_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ListingStats_PriceHistoryId",
                table: "ListingStats",
                column: "PriceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHistories_Listing_Id",
                table: "PriceHistories",
                column: "Listing_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_Listing_Id1",
                table: "Review",
                column: "Listing_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Estate_EstateId",
                table: "Category",
                column: "EstateId",
                principalTable: "Estate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Listings_Listing_Id",
                table: "Comments",
                column: "Listing_Id",
                principalTable: "Listings",
                principalColumn: "Listing_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estate_Listings_Id",
                table: "Estate",
                column: "Id",
                principalTable: "Listings",
                principalColumn: "Listing_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_ListingStats_ListingStats_Id",
                table: "Listings",
                column: "ListingStats_Id",
                principalTable: "ListingStats",
                principalColumn: "ListingStats_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Agencies_Agency_Id",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Agencies_Agency_Id",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Contact_ContactId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Estate_EstateId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceHistories_Listings_Listing_Id",
                table: "PriceHistories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Estate");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Listings");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Estate_Type");

            migrationBuilder.DropTable(
                name: "ListingStats");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "PriceHistories");
        }
    }
}
