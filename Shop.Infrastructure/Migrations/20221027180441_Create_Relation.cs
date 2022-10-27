using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class Create_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    ALTER TABLE [Seller].Inventories
                    ADD CONSTRAINT FK_Inventories_Product_ProductId
                    FOREIGN KEY (ProductId) REFERENCES [Product].Product(Id);
                ");

            migrationBuilder.Sql(@"
                    ALTER TABLE [Order].Items
                    ADD CONSTRAINT FK_Items_Inventories_InventoryId
                    FOREIGN KEY (InventoryId) REFERENCES [Seller].Inventories(Id);
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
