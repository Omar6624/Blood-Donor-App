using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonorAppv4.Migrations
{
    /// <inheritdoc />
    public partial class addres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "BloodRider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "BloodRider");
        }
    }
}
