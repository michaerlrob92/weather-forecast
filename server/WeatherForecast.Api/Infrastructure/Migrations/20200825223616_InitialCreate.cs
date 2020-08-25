using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecast.Api.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecastLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WoEId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    LocationType = table.Column<string>(maxLength: 128, nullable: false),
                    LatLong = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Sunrise = table.Column<DateTime>(nullable: true),
                    Sunset = table.Column<DateTime>(nullable: true),
                    TimezoneName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecastLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecastDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherForecastLocationId = table.Column<int>(nullable: false),
                    WeatherId = table.Column<long>(nullable: false),
                    ApplicableDate = table.Column<DateTime>(nullable: false),
                    WeatherStateName = table.Column<string>(maxLength: 128, nullable: false),
                    WeatherStateAbbr = table.Column<string>(maxLength: 128, nullable: false),
                    WindSpeed = table.Column<decimal>(nullable: false),
                    WindDirection = table.Column<decimal>(nullable: false),
                    WindDirectionCompass = table.Column<string>(maxLength: 128, nullable: false),
                    MinTemp = table.Column<decimal>(nullable: false),
                    MaxTemp = table.Column<decimal>(nullable: false),
                    TheTemp = table.Column<decimal>(nullable: false),
                    AirPressure = table.Column<decimal>(nullable: false),
                    Humidity = table.Column<decimal>(nullable: false),
                    Visibility = table.Column<decimal>(nullable: false),
                    Predictability = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecastDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherForecastDays_WeatherForecastLocations_WeatherForecastLocationId",
                        column: x => x.WeatherForecastLocationId,
                        principalTable: "WeatherForecastLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecastDays_WeatherForecastLocationId",
                table: "WeatherForecastDays",
                column: "WeatherForecastLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecastDays");

            migrationBuilder.DropTable(
                name: "WeatherForecastLocations");
        }
    }
}
