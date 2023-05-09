using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EstatesMicroservice.Migrations.EstatesDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
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
                    table.PrimaryKey("PK_Address", x => x.Address_Id);
                });

            migrationBuilder.CreateTable(
                name: "Agency",
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
                    table.PrimaryKey("PK_Agency", x => x.Agency_Id);
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
                name: "Countries",
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estate_Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Estate_Status_Name = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estate_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estate_Types",
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
                    table.PrimaryKey("PK_Estate_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "In_Charges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Estate_Id = table.Column<int>(type: "integer", nullable: false),
                    Employee_Id = table.Column<int>(type: "integer", nullable: false),
                    Date_From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_In_Charges", x => x.Id);
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
                        name: "FK_Contact_Client_Contact_Details",
                        column: x => x.Contact_Details,
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
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<string>(type: "text", nullable: false),
                    First_Name = table.Column<string>(type: "text", nullable: true),
                    Last_Name = table.Column<string>(type: "text", nullable: true),
                    Company_Id = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City_Name = table.Column<string>(type: "text", nullable: true),
                    Country_Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_Country_Id",
                        column: x => x.Country_Id,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
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
                    table.PrimaryKey("PK_Agent", x => x.Agent_Id);
                    table.ForeignKey(
                        name: "FK_Agent_Agency_Agency_Id",
                        column: x => x.Agency_Id,
                        principalTable: "Agency",
                        principalColumn: "Agency_Id");
                    table.ForeignKey(
                        name: "FK_Agent_Contact_ContactId",
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
                        name: "FK_Contract_Agent_Agent_Id",
                        column: x => x.Agent_Id,
                        principalTable: "Agent",
                        principalColumn: "Agent_Id");
                    table.ForeignKey(
                        name: "FK_Contract_Client_Client_Id1",
                        column: x => x.Client_Id1,
                        principalTable: "Client",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
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
                    table.PrimaryKey("PK_Comment", x => x.Comment_Id);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Estate_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    City_Id = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Estates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estates_Address_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "Address",
                        principalColumn: "Address_Id");
                    table.ForeignKey(
                        name: "FK_Estates_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estates_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estates_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_Estates_Employee_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id");
                    table.ForeignKey(
                        name: "FK_Estates_Estate_Types_Estate_TypeId",
                        column: x => x.Estate_TypeId,
                        principalTable: "Estate_Types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Listing",
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
                    table.PrimaryKey("PK_Listing", x => x.Listing_Id);
                    table.ForeignKey(
                        name: "FK_Listing_Address_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "Address",
                        principalColumn: "Address_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Agency_Agency_Id",
                        column: x => x.Agency_Id,
                        principalTable: "Agency",
                        principalColumn: "Agency_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Agent_Agent_Id1",
                        column: x => x.Agent_Id1,
                        principalTable: "Agent",
                        principalColumn: "Agent_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listing_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Employee_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Estate_Types_Estate_TypeId",
                        column: x => x.Estate_TypeId,
                        principalTable: "Estate_Types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceHistory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Listing_Id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceHistory_Listing_Listing_Id",
                        column: x => x.Listing_Id,
                        principalTable: "Listing",
                        principalColumn: "Listing_Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Review_Listing_Listing_Id1",
                        column: x => x.Listing_Id1,
                        principalTable: "Listing",
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
                        name: "FK_ListingStats_PriceHistory_PriceHistoryId",
                        column: x => x.PriceHistoryId,
                        principalTable: "PriceHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_Agency_Id",
                table: "Agent",
                column: "Agency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Agent_ContactId",
                table: "Agent",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EstateId",
                table: "Categories",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Country_Id",
                table: "Cities",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Client_Id",
                table: "Client",
                column: "Client_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Listing_Id",
                table: "Comment",
                column: "Listing_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Contact_Details",
                table: "Contact",
                column: "Contact_Details",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Id",
                table: "Contact",
                column: "Id",
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
                name: "IX_Employee_Company_Id",
                table: "Employee",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_Address_Id",
                table: "Estates",
                column: "Address_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_CategoryId",
                table: "Estates",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_City_Id",
                table: "Estates",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_Company_Id",
                table: "Estates",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_Employee_Id",
                table: "Estates",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_Estate_TypeId",
                table: "Estates",
                column: "Estate_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_Listing_Id",
                table: "Estates",
                column: "Listing_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRole_Client_Id",
                table: "IdentityRole",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_Address_Id",
                table: "Listing",
                column: "Address_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_Agency_Id",
                table: "Listing",
                column: "Agency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_Agent_Id1",
                table: "Listing",
                column: "Agent_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_CategoryId",
                table: "Listing",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_Company_Id",
                table: "Listing",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_Employee_Id",
                table: "Listing",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_Estate_TypeId",
                table: "Listing",
                column: "Estate_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_ListingStats_Id",
                table: "Listing",
                column: "ListingStats_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ListingStats_PriceHistoryId",
                table: "ListingStats",
                column: "PriceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHistory_Listing_Id",
                table: "PriceHistory",
                column: "Listing_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_Listing_Id1",
                table: "Review",
                column: "Listing_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Estates_EstateId",
                table: "Categories",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Listing_Listing_Id",
                table: "Comment",
                column: "Listing_Id",
                principalTable: "Listing",
                principalColumn: "Listing_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Listing_Listing_Id",
                table: "Estates",
                column: "Listing_Id",
                principalTable: "Listing",
                principalColumn: "Listing_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_ListingStats_ListingStats_Id",
                table: "Listing",
                column: "ListingStats_Id",
                principalTable: "ListingStats",
                principalColumn: "ListingStats_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Agency_Agency_Id",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Agency_Agency_Id",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Contact_ContactId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Estates_EstateId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceHistory_Listing_Listing_Id",
                table: "PriceHistory");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Estate_Statuses");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "In_Charges");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Estate_Types");

            migrationBuilder.DropTable(
                name: "ListingStats");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "PriceHistory");
        }
    }
}
