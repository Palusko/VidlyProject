namespace VidlyProject.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class GenreId : DbMigration
  {
    public override void Up()
    {
      AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
    }

    public override void Down()
    {     
      DropColumn("dbo.Movies", "GenreId");
    }
  }
}
