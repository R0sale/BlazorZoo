using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correctedbugwithpasswordhash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b8dd6cb1-d02c-440d-828b-3056017e4390",
                column: "PasswordHash",
                value: "A55FD8DDBE049632BF24D0615A52B9D5021527DDF478215A0257A4E80879D340");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cd244cd6-239f-49c7-9532-7dbd95e4a156",
                columns: new[] { "Address_City", "Address_Country", "Address_PostalCode", "Address_State", "Address_Street", "PasswordHash" },
                values: new object[] { "Tampa", "USA", "222435", "South Florida", "Lenina", "A55FD8DDBE049632BF24D0615A52B9D5021527DDF478215A0257A4E80879D340" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b8dd6cb1-d02c-440d-828b-3056017e4390",
                column: "PasswordHash",
                value: "System.Byte[]");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cd244cd6-239f-49c7-9532-7dbd95e4a156",
                column: "PasswordHash",
                value: "System.Byte[]");
        }
    }
}
