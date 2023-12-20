using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_CRUD_Challange.Migrations
{
    public partial class Ruturaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    addressId = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    pinCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.addressId);
                });

            migrationBuilder.CreateTable(
                name: "dept",
                columns: table => new
                {
                    deptId = table.Column<int>(type: "int", nullable: false),
                    deptName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept", x => x.deptId);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    deptId = table.Column<int>(type: "int", nullable: true),
                    addressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_employee_address",
                        column: x => x.addressId,
                        principalTable: "address",
                        principalColumn: "addressId");
                    table.ForeignKey(
                        name: "FK_employee_dept",
                        column: x => x.deptId,
                        principalTable: "dept",
                        principalColumn: "deptId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_addressId",
                table: "employee",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_deptId",
                table: "employee",
                column: "deptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "dept");
        }
    }
}
