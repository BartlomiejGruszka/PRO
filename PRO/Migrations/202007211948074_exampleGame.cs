namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class exampleGame : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "SeriesId", "dbo.Series");
            DropIndex("dbo.Games", new[] { "SeriesId" });
            AlterColumn("dbo.Games", "SeriesId", c => c.Int());
            CreateIndex("dbo.Games", "SeriesId");
            AddForeignKey("dbo.Games", "SeriesId", "dbo.Series", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Games", "SeriesId", "dbo.Series");
            DropIndex("dbo.Games", new[] { "SeriesId" });
            AlterColumn("dbo.Games", "SeriesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "SeriesId");
            AddForeignKey("dbo.Games", "SeriesId", "dbo.Series", "Id", cascadeDelete: true);
        }
    }
}
