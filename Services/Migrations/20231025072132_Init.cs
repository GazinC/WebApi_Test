using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Services.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_TASK_DTLS",
                columns: table => new
                {
                    TASK_ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TASK_TITLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TASK_DESC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    STATUS = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_TASK_DTLS", x => x.TASK_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_TASK_DTLS");
        }
    }
}
