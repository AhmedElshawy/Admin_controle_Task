using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class modleEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "ProductPropValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ProductPropValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkinType",
                table: "ProductPropValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "ProductPropValues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "ProductPropValues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BrandName",
                table: "CategoryProp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Color",
                table: "CategoryProp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SkinType",
                table: "CategoryProp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Volume",
                table: "CategoryProp",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Weight",
                table: "CategoryProp",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "ProductPropValues");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductPropValues");

            migrationBuilder.DropColumn(
                name: "SkinType",
                table: "ProductPropValues");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "ProductPropValues");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ProductPropValues");

            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "CategoryProp");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "CategoryProp");

            migrationBuilder.DropColumn(
                name: "SkinType",
                table: "CategoryProp");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "CategoryProp");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "CategoryProp");
        }
    }
}
