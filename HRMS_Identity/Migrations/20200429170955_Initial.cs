using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Identity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "AbsenceType",
                columns: table => new
                {
                    IdAbsenceType = table.Column<int>(nullable: false),
                    AbsenceType = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AbsenceType_pk", x => x.IdAbsenceType);
                });*/

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });
            /*
            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    IdBenefit = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Benefit_pk", x => x.IdBenefit);
                });

            migrationBuilder.CreateTable(
                name: "ContractStatus",
                columns: table => new
                {
                    IdContractStatus = table.Column<int>(nullable: false),
                    StatusName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ContractStatus_pk", x => x.IdContractStatus);
                });

            migrationBuilder.CreateTable(
                name: "ContractType",
                columns: table => new
                {
                    IdContractType = table.Column<int>(nullable: false),
                    ContractType = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ContractType_pk", x => x.IdContractType);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    IdJob = table.Column<int>(nullable: false),
                    JobName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Job_pk", x => x.IdJob);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    IdRequestStatus = table.Column<int>(nullable: false),
                    StatusName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RequestStatus_pk", x => x.IdRequestStatus);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    IdRequestType = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Object = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RequestType_pk", x => x.IdRequestType);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Role_pk", x => x.IdRole);
                });*/

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            /*
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    PESEL = table.Column<string>(maxLength: 11, nullable: false),
                    IdCardNumber = table.Column<string>(maxLength: 6, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: false),
                    Login = table.Column<string>(maxLength: 9, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IdJob = table.Column<int>(nullable: false),
                    IdManager = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IdRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employee_pk", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "Employee_Job",
                        column: x => x.IdJob,
                        principalTable: "Job",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Employee_Manager",
                        column: x => x.IdManager,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Employee_Role",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvailableAbsence",
                columns: table => new
                {
                    IdAvailableAbsence = table.Column<int>(nullable: false),
                    AvailableDays = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    IdAbsenceType = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    UsedAbsence = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AvailableAbsence_pk", x => x.IdAvailableAbsence);
                    table.ForeignKey(
                        name: "AvailableAbsence_AbsenceType",
                        column: x => x.IdAbsenceType,
                        principalTable: "AbsenceType",
                        principalColumn: "IdAbsenceType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "AvailableAbsence_Employee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    IdContract = table.Column<int>(nullable: false),
                    ContractNumber = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ContractStart = table.Column<DateTime>(type: "date", nullable: false),
                    ContractEnd = table.Column<DateTime>(type: "date", nullable: false),
                    IdContractType = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdContractStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Contract_pk", x => x.IdContract);
                    table.ForeignKey(
                        name: "Contract_ContractStatus",
                        column: x => x.IdContractStatus,
                        principalTable: "ContractStatus",
                        principalColumn: "IdContractStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Contract_ContractType",
                        column: x => x.IdContractType,
                        principalTable: "ContractType",
                        principalColumn: "IdContractType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Contract_Employee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Overtime",
                columns: table => new
                {
                    IdOvertime = table.Column<int>(nullable: false),
                    ToBeSettledBefore = table.Column<DateTime>(type: "date", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    IdEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Overtime_pk", x => x.IdOvertime);
                    table.ForeignKey(
                        name: "Overtime_Employee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    IdRequest = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    QuantityRequested = table.Column<decimal>(type: "decimal(3, 2)", nullable: false),
                    IdRequestType = table.Column<int>(nullable: false),
                    IdRequestStatus = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CommentManager = table.Column<string>(nullable: true),
                    CommentEmployee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Request_pk", x => x.IdRequest);
                    table.ForeignKey(
                        name: "Request_Employee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Request_Status",
                        column: x => x.IdRequestStatus,
                        principalTable: "RequestStatus",
                        principalColumn: "IdRequestStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Request_RequestType",
                        column: x => x.IdRequestType,
                        principalTable: "RequestType",
                        principalColumn: "IdRequestType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractBenefit",
                columns: table => new
                {
                    IdBenefitContract = table.Column<int>(nullable: false),
                    IdBenefit = table.Column<int>(nullable: false),
                    IdContract = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ContractBenefit_pk", x => new { x.IdBenefitContract, x.IdBenefit, x.IdContract });
                    table.ForeignKey(
                        name: "ContractBenefit_Benefit",
                        column: x => x.IdBenefit,
                        principalTable: "Benefit",
                        principalColumn: "IdBenefit",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ContractBenefit_Contract",
                        column: x => x.IdContract,
                        principalTable: "Contract",
                        principalColumn: "IdContract",
                        onDelete: ReferentialAction.Restrict);
                });*/

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableAbsence_IdAbsenceType",
                table: "AvailableAbsence",
                column: "IdAbsenceType");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableAbsence_IdEmployee",
                table: "AvailableAbsence",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IdContractStatus",
                table: "Contract",
                column: "IdContractStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IdContractType",
                table: "Contract",
                column: "IdContractType");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_IdEmployee",
                table: "Contract",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefit_IdBenefit",
                table: "ContractBenefit",
                column: "IdBenefit");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefit_IdContract",
                table: "ContractBenefit",
                column: "IdContract");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdJob",
                table: "Employee",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdManager",
                table: "Employee",
                column: "IdManager");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdRole",
                table: "Employee",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Overtime_IdEmployee",
                table: "Overtime",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IdEmployee",
                table: "Request",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IdRequestStatus",
                table: "Request",
                column: "IdRequestStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Request_IdRequestType",
                table: "Request",
                column: "IdRequestType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AvailableAbsence");

            migrationBuilder.DropTable(
                name: "ContractBenefit");

            migrationBuilder.DropTable(
                name: "Overtime");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AbsenceType");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "RequestStatus");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropTable(
                name: "ContractStatus");

            migrationBuilder.DropTable(
                name: "ContractType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
