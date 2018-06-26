using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelCRMData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CustomerID = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    MobileNUmber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true),
                    ManagerName = table.Column<string>(nullable: true),
                    ManagerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    MobileNUmber = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Active = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false),
                    ControllerName = table.Column<string>(nullable: false),
                    ActionName = table.Column<string>(nullable: false),
                    PermissionSet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => new { x.RoleID, x.ControllerName, x.ActionName });
                    table.ForeignKey(
                        name: "FK_Permission_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LeadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadSource = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: true),
                    JourneySource = table.Column<string>(nullable: true),
                    JourneyDestination = table.Column<string>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    CurrentStatus = table.Column<int>(nullable: false),
                    ModeOfTravel = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    StayPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.LeadID);
                    table.ForeignKey(
                        name: "FK_Leads_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    IsLoggedIn = table.Column<bool>(nullable: false),
                    SecretCode = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    EmployeeID1 = table.Column<int>(nullable: true),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Employees_EmployeeID1",
                        column: x => x.EmployeeID1,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEnquiryDetails",
                columns: table => new
                {
                    EnquiryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    LeadID = table.Column<int>(nullable: false),
                    Loaction = table.Column<string>(nullable: true),
                    TravelSource = table.Column<string>(nullable: true),
                    TravelDestination = table.Column<string>(nullable: true),
                    TraveCategory = table.Column<string>(nullable: true),
                    AccomdationCategory = table.Column<string>(nullable: true),
                    TourCategory = table.Column<string>(nullable: true),
                    TravelExpectedDate = table.Column<DateTime>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CustomerID1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEnquiryDetails", x => x.EnquiryID);
                    table.ForeignKey(
                        name: "FK_CustomerEnquiryDetails_Customers_CustomerID1",
                        column: x => x.CustomerID1,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerEnquiryDetails_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEnquiryDetails_Leads_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Leads",
                        principalColumn: "LeadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadEmployeeMapper",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    LeadEmployeeMapperID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadEmployeeMapper", x => x.LeadEmployeeMapperID);
                    table.ForeignKey(
                        name: "FK_LeadEmployeeMapper_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadEmployeeMapper_Leads_LeadID",
                        column: x => x.LeadID,
                        principalTable: "Leads",
                        principalColumn: "LeadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_EmployeeID1",
                table: "ApplicationUsers",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_RoleID",
                table: "ApplicationUsers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEnquiryDetails_CustomerID1",
                table: "CustomerEnquiryDetails",
                column: "CustomerID1");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEnquiryDetails_EmployeeID",
                table: "CustomerEnquiryDetails",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEnquiryDetails_LeadID",
                table: "CustomerEnquiryDetails",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadEmployeeMapper_EmployeeID",
                table: "LeadEmployeeMapper",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeadEmployeeMapper_LeadID",
                table: "LeadEmployeeMapper",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_TeamId",
                table: "Leads",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "CustomerEnquiryDetails");

            migrationBuilder.DropTable(
                name: "LeadEmployeeMapper");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
