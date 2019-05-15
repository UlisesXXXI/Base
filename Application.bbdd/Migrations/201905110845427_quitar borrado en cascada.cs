namespace Application.bbdd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quitarborradoencascada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gasto", "TipoGastoID", "dbo.TipoGasto");
            AddForeignKey("dbo.Gasto", "TipoGastoID", "dbo.TipoGasto", "TipoGastoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gasto", "TipoGastoID", "dbo.TipoGasto");
            AddForeignKey("dbo.Gasto", "TipoGastoID", "dbo.TipoGasto", "TipoGastoID", cascadeDelete: true);
        }
    }
}
