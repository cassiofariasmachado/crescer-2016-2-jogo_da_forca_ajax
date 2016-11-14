namespace JogoDaForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionarmodo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogada", "Modo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogada", "Modo");
        }
    }
}
