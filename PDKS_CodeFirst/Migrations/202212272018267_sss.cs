namespace PDKS_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonelKiyafets", "İstekNedeni", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelKiyafets", "Renk", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelKiyafets", "ÜstBedenNo", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelKiyafets", "AltBedenNo", c => c.String(nullable: false));
            AlterColumn("dbo.PersonelKiyafets", "KafaBedenNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonelKiyafets", "KafaBedenNo", c => c.String());
            AlterColumn("dbo.PersonelKiyafets", "AltBedenNo", c => c.String());
            AlterColumn("dbo.PersonelKiyafets", "ÜstBedenNo", c => c.String());
            AlterColumn("dbo.PersonelKiyafets", "Renk", c => c.String());
            AlterColumn("dbo.PersonelKiyafets", "İstekNedeni", c => c.String());
        }
    }
}
