namespace Application.bbdd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entidadgastos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gasto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 250),
                        Fecha = c.DateTime(nullable: false),
                        TipoGastoID = c.Int(nullable: false),
                        Importe = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoGasto", t => t.TipoGastoID, cascadeDelete: true)
                .Index(t => t.TipoGastoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gasto", "TipoGastoID", "dbo.TipoGasto");
            DropIndex("dbo.Gasto", new[] { "TipoGastoID" });
            DropTable("dbo.Gasto");
        }
    }
}
