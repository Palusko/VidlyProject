namespace VidlyProject.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class UpdateBday : DbMigration
  {
    public override void Up()
    {
      Sql("Update Customers set Birthday='2/2/1973' where Id=1");
    }

    public override void Down()
    {
    }
  }
}
