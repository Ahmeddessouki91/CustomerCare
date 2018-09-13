using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerCare.Migrations
{
    public partial class GovernerateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Cairo',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Alex',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Giza',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Mansoura',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Sharkia',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Gharbia',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Suez',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('PortSaed',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Ismallia',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Assuit',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Minnia',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Beniswif',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Fauom',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Sohag',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Aswan',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Luxur',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Banha',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");
           migrationBuilder.Sql("INSERT INTO Governerates (Name,CountryId) VALUES ('Others',(SELECT Id FROM Countries WHERE Name = 'Egypt'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
