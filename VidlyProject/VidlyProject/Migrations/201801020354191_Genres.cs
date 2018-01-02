namespace VidlyProject.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class Genres : DbMigration
  {
    public override void Up()
    {
      Sql("Update Movies set Name = 'Alien 2' where id = 4");
    }

    public override void Down()
    {
    }
  }
}
