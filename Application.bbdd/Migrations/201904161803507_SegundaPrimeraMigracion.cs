namespace Application.bbdd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaPrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoGasto",
                c => new
                    {
                        TipoGastoID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.TipoGastoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoGasto");
        }
    }
}
