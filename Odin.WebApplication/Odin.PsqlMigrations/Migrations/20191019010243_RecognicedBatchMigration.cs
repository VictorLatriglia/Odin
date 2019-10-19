using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Odin.PsqlMigrations.Migrations
{
    public partial class RecognicedBatchMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetectionBatchId",
                table: "ObjectDetected",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetectionBatch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectionBatch", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectDetected_DetectionBatchId",
                table: "ObjectDetected",
                column: "DetectionBatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectDetected_DetectionBatch_DetectionBatchId",
                table: "ObjectDetected",
                column: "DetectionBatchId",
                principalTable: "DetectionBatch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectDetected_DetectionBatch_DetectionBatchId",
                table: "ObjectDetected");

            migrationBuilder.DropTable(
                name: "DetectionBatch");

            migrationBuilder.DropIndex(
                name: "IX_ObjectDetected_DetectionBatchId",
                table: "ObjectDetected");

            migrationBuilder.DropColumn(
                name: "DetectionBatchId",
                table: "ObjectDetected");
        }
    }
}
