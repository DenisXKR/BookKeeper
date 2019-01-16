namespace BookKeeper.Data.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

			this.Sql("insert into dbo.Categories(Name) Values('Food')");
			this.Sql("insert into dbo.Categories(Name) Values('Bills')");
			this.Sql("insert into dbo.Categories(Name) Values('Taxi')");
			this.Sql("insert into dbo.Categories(Name) Values('Entertainment')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "CategoryId" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Categories");
        }
    }
}
