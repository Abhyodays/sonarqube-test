using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class createCarTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalPrice = table.Column<double>(type: "float", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "Availability", "Maker", "Model", "RentalPrice" },
                values: new object[,]
                {
                    { 1, "Available", "Honda", "City", 2345.5999999999999 },
                    { 2, "Available", "Toyota", "Corolla", 1899.99 },
                    { 3, "Available", "Ford", "Mustang", 3456.75 },
                    { 4, "Available", "Chevrolet", "Cruze", 1750.0 },
                    { 5, "Available", "Nissan", "Altima", 1999.0 },
                    { 6, "Available", "Hyundai", "Elantra", 1689.5 },
                    { 7, "Available", "Volkswagen", "Jetta", 2200.25 },
                    { 8, "Available", "Mazda", "CX-5", 2799.0 },
                    { 9, "Available", "Subaru", "Outback", 2499.5 },
                    { 10, "Available", "Tesla", "Model Y", 3999.9899999999998 },
                    { 11, "Available", "Audi", "A3", 2999.0 },
                    { 12, "Available", "BMW", "X3", 3499.75 },
                    { 13, "Available", "Mercedes-Benz", "C-Class", 3899.0 },
                    { 14, "Available", "Lexus", "RX", 3799.25 },
                    { 15, "Available", "Jeep", "Wrangler", 2899.5 },
                    { 16, "Available", "Land Rover", "Range Rover", 4999.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
