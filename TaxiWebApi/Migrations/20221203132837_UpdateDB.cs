using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiWebApi.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dispatchers_DispatcherId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_Cities_CityId",
                table: "Riders");

            migrationBuilder.DropTable(
                name: "Dispatchers");

            migrationBuilder.DropIndex(
                name: "IX_Riders_CityId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Riders");

            migrationBuilder.RenameColumn(
                name: "DispatcherId",
                table: "Orders",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DispatcherId",
                table: "Orders",
                newName: "IX_Orders_CityId");

            migrationBuilder.RenameColumn(
                name: "DriverLicence",
                table: "Drivers",
                newName: "DriverLicense");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Riders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdministratorId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarType",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasAirConditioner",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSeatBeltsBehind",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUkrRegistration",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverOptions",
                columns: table => new
                {
                    DriverOptionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverOptions", x => x.DriverOptionId);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    ParameterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.ParameterId);
                });

            migrationBuilder.CreateTable(
                name: "DriverDriverOption",
                columns: table => new
                {
                    DriverOptionsDriverOptionId = table.Column<int>(type: "int", nullable: false),
                    DriversId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverDriverOption", x => new { x.DriverOptionsDriverOptionId, x.DriversId });
                    table.ForeignKey(
                        name: "FK_DriverDriverOption_DriverOptions_DriverOptionsDriverOptionId",
                        column: x => x.DriverOptionsDriverOptionId,
                        principalTable: "DriverOptions",
                        principalColumn: "DriverOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverDriverOption_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderParameter",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ParametersParameterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderParameter", x => new { x.OrdersId, x.ParametersParameterId });
                    table.ForeignKey(
                        name: "FK_OrderParameter_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderParameter_Parameters_ParametersParameterId",
                        column: x => x.ParametersParameterId,
                        principalTable: "Parameters",
                        principalColumn: "ParameterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DriverOptions",
                columns: new[] { "DriverOptionId", "Name" },
                values: new object[,]
                {
                    { 0, "OrderForTime" },
                    { 1, "DrivePassengerCar" },
                    { 2, "DeliverParcel" },
                    { 3, "TruckDriver" },
                    { 4, "EnglishSpeaking" }
                });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "ParameterId", "Name" },
                values: new object[,]
                {
                    { 0, "AirConditioner" },
                    { 1, "UseSeatBeltsBehind" },
                    { 2, "UkrainianRegistration" },
                    { 3, "EnglishSpeakingDriver" },
                    { 4, "WithChildren" },
                    { 5, "WithPets" },
                    { 6, "SilentDriver" },
                    { 7, "DoNotCall" },
                    { 8, "Deaf" },
                    { 9, "EmptyTrunk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Riders_Phone",
                table: "Riders",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdministratorId",
                table: "Orders",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverDriverOption_DriversId",
                table: "DriverDriverOption",
                column: "DriversId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderParameter_ParametersParameterId",
                table: "OrderParameter",
                column: "ParametersParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Administrators_AdministratorId",
                table: "Orders",
                column: "AdministratorId",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cities_CityId",
                table: "Orders",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Administrators_AdministratorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cities_CityId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "DriverDriverOption");

            migrationBuilder.DropTable(
                name: "OrderParameter");

            migrationBuilder.DropTable(
                name: "DriverOptions");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropIndex(
                name: "IX_Riders_Phone",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AdministratorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CarType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HasAirConditioner",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HasSeatBeltsBehind",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsUkrRegistration",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Orders",
                newName: "DispatcherId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                newName: "IX_Orders_DispatcherId");

            migrationBuilder.RenameColumn(
                name: "DriverLicense",
                table: "Drivers",
                newName: "DriverLicence");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Riders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Riders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dispatchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dispatchers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Riders_CityId",
                table: "Riders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatchers_CityId",
                table: "Dispatchers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dispatchers_DispatcherId",
                table: "Orders",
                column: "DispatcherId",
                principalTable: "Dispatchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_Cities_CityId",
                table: "Riders",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
