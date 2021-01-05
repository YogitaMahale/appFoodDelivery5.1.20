using Microsoft.EntityFrameworkCore.Migrations;

namespace appFoodDelivery.Persistence.Migrations
{
    public partial class testttghgfgfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
create PROCEDURE  getNearestStoredbyLocationNew
	 	@Latitude decimal(18,6)
	,@Longitude  decimal(18,6)
	,@distance numeric
	 
AS
BEGIN
DECLARE @g geography;
DECLARE @h geography;

	SELECT  
	
	id,storename, latitude, longitude, storeid, storename, latitude,longitude, contactpersonname, emailaddress, contactno, gender, fooddelivery, storename, radiusid, 
deliverytimeid, orderMinAmount, packagingCharges, storeBannerPhoto, address, description, storetime, licPhoto,
 isdeleted, cityid, latitude, longitude, discount, promocode
		
	FROM storedetails mm
	WHERE  
		  ROUND((((ACOS(SIN((@Latitude * PI() / 180)) * SIN((mm.latitude * PI() / 180)) + COS((@Latitude * PI() / 180)) * COS((mm.latitude * PI() / 180)) * COS(((@Longitude - mm.longitude) * PI() / 180)))) * 180 / PI()) * 60 * 1.1515 * 1.609344), 0) 
		  <= @distance		 
END
 
");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop PROCEDURE getNearestStoredbyLocation");
        }
    }
}
