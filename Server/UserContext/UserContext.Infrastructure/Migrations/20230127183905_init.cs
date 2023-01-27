using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserContext.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsNew = table.Column<sbyte>(type: "tinyint", nullable: false),
                    EmailVerified = table.Column<sbyte>(type: "tinyint", nullable: false),
                    PhoneVerified = table.Column<sbyte>(type: "tinyint", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeStampsCreatedAt = table.Column<DateTime>(name: "TimeStamps_CreatedAt", type: "date", nullable: true),
                    TimeStampsUpdatedAt = table.Column<DateTime>(name: "TimeStamps_UpdatedAt", type: "date", nullable: true),
                    UsernameValue = table.Column<string>(name: "Username_Value", type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailValue = table.Column<string>(name: "Email_Value", type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordValue = table.Column<string>(name: "Password_Value", type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhonePhoneNumber = table.Column<long>(name: "Phone_PhoneNumber", type: "bigint", nullable: true),
                    PhoneAreaCode = table.Column<short>(name: "Phone_AreaCode", type: "smallint", nullable: true),
                    PhoneCountryPrefix = table.Column<string>(name: "Phone_CountryPrefix", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TimeStampsCreatedAt = table.Column<DateTime>(name: "TimeStamps_CreatedAt", type: "date", nullable: false),
                    TimeStampsUpdatedAt = table.Column<DateTime>(name: "TimeStamps_UpdatedAt", type: "date", nullable: false),
                    NameFirstName = table.Column<string>(name: "Name_FirstName", type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameLastName = table.Column<string>(name: "Name_LastName", type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AddressCountry = table.Column<string>(name: "Address_Country", type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressCity = table.Column<string>(name: "Address_City", type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressState = table.Column<string>(name: "Address_State", type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressZipCodeValue = table.Column<string>(name: "Address_ZipCode_Value", type: "varchar(8)", maxLength: 8, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressStreet = table.Column<string>(name: "Address_Street", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressStreetNumber = table.Column<int>(name: "Address_StreetNumber", type: "int", nullable: true),
                    EmergencyContactNameFirstName = table.Column<string>(name: "EmergencyContact_Name_FirstName", type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactNameLastName = table.Column<string>(name: "EmergencyContact_Name_LastName", type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactRelationShip = table.Column<int>(name: "EmergencyContact_RelationShip", type: "int", nullable: true),
                    EmergencyContactPhoneNumber = table.Column<long>(name: "EmergencyContact_Phone_Number", type: "bigint", nullable: true),
                    EmergencyContactPhoneAreaCode = table.Column<int>(name: "EmergencyContact_Phone_AreaCode", type: "int", nullable: true),
                    EmergencyContactPhoneCountryPrefix = table.Column<string>(name: "EmergencyContact_Phone_CountryPrefix", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BioValue = table.Column<string>(name: "Bio_Value", type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalAptitude = table.Column<string>(name: "Medical_Aptitude", type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalDisabilities = table.Column<string>(name: "Medical_Disabilities", type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProfile_Account_Id",
                        column: x => x.Id,
                        principalTable: "Account",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email_Value",
                table: "Account",
                column: "Email_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Phone_PhoneNumber",
                table: "Account",
                column: "Phone_PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username_Value",
                table: "Account",
                column: "Username_Value",
                unique: true,
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonProfile");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
