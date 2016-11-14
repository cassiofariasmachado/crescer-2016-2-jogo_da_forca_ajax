namespace JogoDaForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retirarsenha : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Senha", c => c.String());
        }
    }
}
