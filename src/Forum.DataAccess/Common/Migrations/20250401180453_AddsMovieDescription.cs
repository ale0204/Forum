using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.DataAccess.Common.Migrations;

/// <inheritdoc />
public partial class AddsMovieDescription : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<float>(
            name: "Score",
            table: "Movies",
            type: "real",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Duration",
            table: "Movies",
            type: "int",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Duration",
            table: "Movies");

        migrationBuilder.AlterColumn<int>(
            name: "Score",
            table: "Movies",
            type: "int",
            nullable: true,
            oldClrType: typeof(float),
            oldType: "real",
            oldNullable: true);
    }
}
