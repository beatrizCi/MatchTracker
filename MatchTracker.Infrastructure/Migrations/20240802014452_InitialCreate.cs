﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamA = table.Column<string>(type: "TEXT", nullable: true),
                    TeamB = table.Column<string>(type: "TEXT", nullable: true),
                    KickOffTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Stadium = table.Column<string>(type: "TEXT", nullable: true),
                    MatchDay = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
