using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_Registration_Demo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newentitesforusersubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "UserSubscriptions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SubscriptionAmount",
                table: "UserSubscriptions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "UserSubscriptions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionAmount",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "UserSubscriptions");
        }
    }
}
