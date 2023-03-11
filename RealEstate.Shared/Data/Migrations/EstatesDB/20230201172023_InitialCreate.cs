using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstate.Data.Migrations.EstatesDB
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
                    AddressId = table.Column<string>(name: "Address_Id", type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    Neighbourhood = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<int>(type: "integer", nullable: true),
                    MapCoordinates = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    AgencyId = table.Column<string>(name: "Agency_Id", type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(name: "Phone_Number", type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.AgencyId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
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
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<string>(name: "Company_Id", type: "text", nullable: false),
                    CompanyName = table.Column<string>(name: "Company_Name", type: "text", nullable: false),
                    CompanyDescription = table.Column<string>(name: "Company_Description", type: "text", nullable: false),
                    EmployeeCount = table.Column<int>(name: "Employee_Count", type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(name: "Country_Name", type: "text", nullable: false),
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
                    EstateStatusName = table.Column<string>(name: "Estate_Status_Name", type: "text", nullable: false),
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
                    TypeName = table.Column<string>(name: "Type_Name", type: "text", nullable: false),
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
                    EstateId = table.Column<int>(name: "Estate_Id", type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(name: "Employee_Id", type: "integer", nullable: false),
                    DateFrom = table.Column<DateTime>(name: "Date_From", type: "timestamp with time zone", nullable: false),
                    DateTo = table.Column<DateTime>(name: "Date_To", type: "timestamp with time zone", nullable: false),
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
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    EmployeeId = table.Column<int>(name: "Employee_Id", type: "integer", nullable: false),
                    EstateId = table.Column<int>(name: "Estate_Id", type: "integer", nullable: false),
                    ContactTime = table.Column<DateTime>(name: "Contact_Time", type: "timestamp with time zone", nullable: false),
                    ContactDetails = table.Column<string>(name: "Contact_Details", type: "text", nullable: false),
                    ClientId = table.Column<string>(name: "Client_Id", type: "text", nullable: false),
                    ApplicationUserId0 = table.Column<string>(name: "ApplicationUser_Id", type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_ApplicationUser_Contact_Details",
                        column: x => x.ContactDetails,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(name: "Employee_Id", type: "text", nullable: false),
                    FirstName = table.Column<string>(name: "First_Name", type: "text", nullable: false),
                    LastName = table.Column<string>(name: "Last_Name", type: "text", nullable: false),
                    CompanyId = table.Column<string>(name: "Company_Id", type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Company_Company_Id",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(name: "City_Name", type: "text", nullable: false),
                    CountryId = table.Column<int>(name: "Country_Id", type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_Country_Id",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<string>(name: "Agent_Id", type: "text", nullable: false),
                    AgentName = table.Column<string>(name: "Agent_Name", type: "text", nullable: false),
                    AgentAddress = table.Column<string>(name: "Agent_Address", type: "text", nullable: false),
                    ContactPerson = table.Column<string>(name: "Contact_Person", type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    EMail = table.Column<string>(type: "text", nullable: false),
                    AgentDetails = table.Column<string>(name: "Agent_Details", type: "text", nullable: false),
                    TimeCreated = table.Column<DateTime>(name: "Time_Created", type: "timestamp with time zone", nullable: false),
                    ContactId = table.Column<string>(type: "text", nullable: true),
                    AgencyId = table.Column<string>(name: "Agency_Id", type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK_Agent_Agency_Agency_Id",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Agency_Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ClientId = table.Column<string>(name: "Client_Id", type: "text", nullable: false),
                    ClientId0 = table.Column<string>(name: "ClientId", type: "text", nullable: false),
                    EmployeeId = table.Column<string>(name: "Employee_Id", type: "text", nullable: false),
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
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AgentId = table.Column<string>(name: "Agent_Id", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Agent_Agent_Id",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Agent_Id");
                    table.ForeignKey(
                        name: "FK_Contract_ApplicationUser_ClientId",
                        column: x => x.ClientId0,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EstateId0 = table.Column<int>(name: "Estate_Id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<string>(name: "Comment_Id", type: "text", nullable: false),
                    CommentTitle = table.Column<string>(name: "Comment_Title", type: "text", nullable: false),
                    CommentContent = table.Column<string>(name: "Comment_Content", type: "text", nullable: false),
                    CommentRating = table.Column<string>(name: "Comment_Rating", type: "text", nullable: false),
                    DatePosted = table.Column<DateTime>(name: "Date_Posted", type: "timestamp with time zone", nullable: false),
                    ListingId = table.Column<string>(name: "Listing_Id", type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EstateName = table.Column<string>(name: "Estate_Name", type: "character varying(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(name: "City_Id", type: "integer", nullable: false),
                    EstateTypeId = table.Column<int>(name: "Estate_Type_Id", type: "integer", nullable: false),
                    FloorSpaceSquareMeters = table.Column<decimal>(name: "Floor_Space_Square_Meters", type: "numeric", nullable: false),
                    NumberOfBalconies = table.Column<int>(name: "Number_Of_Balconies", type: "integer", nullable: false),
                    BalconiesSpace = table.Column<decimal>(name: "Balconies_Space", type: "numeric", nullable: false),
                    NumberOfBedrooms = table.Column<int>(name: "Number_Of_Bedrooms", type: "integer", nullable: false),
                    NumberOfBathrooms = table.Column<int>(name: "Number_Of_Bathrooms", type: "integer", nullable: false),
                    NumberOfGarages = table.Column<int>(name: "Number_Of_Garages", type: "integer", nullable: false),
                    NumberOfParkingSpaces = table.Column<int>(name: "Number_Of_Parking_Spaces", type: "integer", nullable: false),
                    PetsAllowed = table.Column<bool>(name: "Pets_Allowed", type: "boolean", nullable: false),
                    EstateDescription = table.Column<string>(name: "Estate_Description", type: "text", nullable: true),
                    EstateStatusId = table.Column<string>(name: "Estate_Status_Id", type: "text", nullable: true),
                    EstateImageUrl = table.Column<string>(name: "Estate_ImageUrl", type: "text", nullable: false),
                    EstateYearBuilt = table.Column<int>(name: "Estate_Year_Built", type: "integer", nullable: false),
                    EstateYearListed = table.Column<int>(name: "Estate_Year_Listed", type: "integer", nullable: false),
                    BuildMaterial = table.Column<string>(name: "Build_Material", type: "text", nullable: false),
                    IsOnFloor = table.Column<int>(name: "Is_On_Floor", type: "integer", nullable: true),
                    BuldingFloors = table.Column<int>(name: "Bulding_Floors", type: "integer", nullable: true),
                    AddressId = table.Column<string>(name: "Address_Id", type: "text", nullable: false),
                    ListingId = table.Column<string>(name: "Listing_Id", type: "text", nullable: false),
                    EstateTypeId0 = table.Column<int>(name: "Estate_TypeId", type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    CompanyId = table.Column<string>(name: "Company_Id", type: "text", nullable: true),
                    EmployeeId = table.Column<string>(name: "Employee_Id", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estates_Address_Address_Id",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Address_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estates_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estates_Cities_City_Id",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estates_Company_Company_Id",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_Estates_Employee_Employee_Id",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id");
                    table.ForeignKey(
                        name: "FK_Estates_Estate_Types_Estate_TypeId",
                        column: x => x.EstateTypeId0,
                        principalTable: "Estate_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    ListingId = table.Column<string>(name: "Listing_Id", type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EstateId = table.Column<string>(name: "Estate_Id", type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    PricePerSquareMeter = table.Column<double>(type: "double precision", nullable: false),
                    IsFromAnAgency = table.Column<bool>(name: "Is_From_An_Agency", type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    DateBuilt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateListed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstateTypeId = table.Column<int>(name: "Estate_TypeId", type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<string>(name: "Address_Id", type: "text", nullable: true),
                    ListingStatsId = table.Column<int>(name: "ListingStats_Id", type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId0 = table.Column<string>(name: "Employee_Id", type: "text", nullable: true),
                    AgentId = table.Column<string>(name: "Agent_Id", type: "text", nullable: false),
                    AgentId1 = table.Column<string>(name: "Agent_Id1", type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AgencyId = table.Column<string>(name: "Agency_Id", type: "text", nullable: true),
                    CompanyId = table.Column<string>(name: "Company_Id", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.ListingId);
                    table.ForeignKey(
                        name: "FK_Listing_Address_Address_Id",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Address_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Agency_Agency_Id",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Agency_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Agent_Agent_Id1",
                        column: x => x.AgentId1,
                        principalTable: "Agent",
                        principalColumn: "Agent_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listing_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listing_Company_Company_Id",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Company_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Employee_Employee_Id",
                        column: x => x.EmployeeId0,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id");
                    table.ForeignKey(
                        name: "FK_Listing_Estate_Types_Estate_TypeId",
                        column: x => x.EstateTypeId,
                        principalTable: "Estate_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ListingId = table.Column<string>(name: "Listing_Id", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceHistory_Listing_Listing_Id",
                        column: x => x.ListingId,
                        principalTable: "Listing",
                        principalColumn: "Listing_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<string>(name: "Review_Id", type: "text", nullable: false),
                    ReviewTitle = table.Column<string>(name: "Review_Title", type: "text", nullable: false),
                    ReviewContent = table.Column<string>(name: "Review_Content", type: "text", nullable: false),
                    ReviewRating = table.Column<string>(name: "Review_Rating", type: "text", nullable: false),
                    DatePosted = table.Column<DateTime>(name: "Date_Posted", type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ListingId = table.Column<string>(name: "Listing_Id", type: "text", nullable: false),
                    ListingId1 = table.Column<string>(name: "Listing_Id1", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Listing_Listing_Id1",
                        column: x => x.ListingId1,
                        principalTable: "Listing",
                        principalColumn: "Listing_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListingStats",
                columns: table => new
                {
                    ListingStatsId = table.Column<int>(name: "ListingStats_Id", type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_ListingStats", x => x.ListingStatsId);
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
                name: "IX_ApplicationUser_Id",
                table: "ApplicationUser",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EstateId",
                table: "Categories",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Country_Id",
                table: "Cities",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Listing_Id",
                table: "Comment",
                column: "Listing_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ApplicationUserId",
                table: "Contact",
                column: "ApplicationUserId");

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
                name: "IX_Contract_ClientId",
                table: "Contract",
                column: "ClientId");

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
                name: "IX_IdentityRole_ClientId",
                table: "IdentityRole",
                column: "ClientId");

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
                principalColumn: "Listing_Id",
                onDelete: ReferentialAction.Cascade);

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
                principalColumn: "ListingStats_Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "ApplicationUser");

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
