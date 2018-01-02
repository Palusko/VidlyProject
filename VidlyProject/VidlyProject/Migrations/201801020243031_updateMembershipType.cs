namespace VidlyProject.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class updateMembershipType : DbMigration
  {
    public override void Up()
    {
      Sql("Update MembershipTypes set Name='Pay As You Go' where Id=1");
      Sql("Update MembershipTypes set Name='Mothly' where Id=2");
      Sql("Update MembershipTypes set Name='Quarterly' where Id=3");
      Sql("Update MembershipTypes set Name='Yearly' where Id=4");
    }

    public override void Down()
    {
    }
  }
}
