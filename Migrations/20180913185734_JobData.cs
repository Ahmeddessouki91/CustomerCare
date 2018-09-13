using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerCare.Migrations
{
    public partial class JobData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Ortho')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Neuro')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Ped')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Surgery')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Chest')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Ophtha')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Gyna')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('ENT')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Uorolgy')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Family')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Pharmacist')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Eng')");
            migrationBuilder.Sql("INSERT INTO Jobs (Name) VALUES ('Others')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
