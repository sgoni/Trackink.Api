using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Customer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "customer");

            migrationBuilder.CreateTable(
                name: "parameters",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    description = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    name = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedByAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoDocument = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DocumentTypeId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    mobile = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    email = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: true),
                    Gender = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true, defaultValue: "Male"),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Address_Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Address_Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Address_PlusCode = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedByAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_parameters_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "customer",
                        principalTable: "parameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "Idx_NoDocument",
                schema: "customer",
                table: "clients",
                column: "NoDocument",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clients_DocumentTypeId",
                schema: "customer",
                table: "clients",
                column: "DocumentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients",
                schema: "customer");

            migrationBuilder.DropTable(
                name: "parameters",
                schema: "customer");
        }
    }
}
