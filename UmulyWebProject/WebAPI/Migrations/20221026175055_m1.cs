using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovementType = table.Column<short>(type: "smallint", nullable: false),
                    Incoterm = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit1Value = table.Column<double>(type: "float", nullable: false),
                    Unit2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit2Value = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                });


            var sp1 = @"CREATE PROCEDURE OfferList 
                            @id int = NULL
                       AS
                       BEGIN
                          IF(@id IS NULL)
                            BEGIN
                             select * from Offers
                            END
                          ELSE
                            BEGIN
                             select * from Offers WHERE id=@id
                            END
                      END";

            var sp2 = @"CREATE PROCEDURE [dbo].[OfferAdd]

                          @Mode            NVARCHAR(MAX) ,
                          @MovementType    smallint,
                          @Incoterm        bit,
                          @Country         NVARCHAR(MAX) ,
                          @City            NVARCHAR(MAX) ,
                          @PackageType     NVARCHAR(MAX) ,
                          @Unit1           NVARCHAR(MAX) ,
                          @Unit1Value      NVARCHAR(MAX),
                          @Unit2           NVARCHAR(MAX) ,
                          @Unit2Value      NVARCHAR(MAX),
                          @Currency        NVARCHAR(MAX) ,
                          @Price           NVARCHAR(MAX)

                         AS
                       BEGIN
                         Insert Into Offers  
                                    VALUES( 
                                                @Mode,
                                                @MovementType,
                                                @Incoterm,
                                                @Country,
                                                @City,
                                                @PackageType,
                                                @Unit1, 
                                                convert(float,@Unit1Value),
                                                @Unit2,
                                                convert(float,@Unit2Value),
                                                @Currency,
                                                convert(float,@Price)
                                            )
                      END";

            migrationBuilder.Sql(sp1);
            migrationBuilder.Sql(sp2);



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
