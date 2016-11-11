namespace JogoDaForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pontuacao = c.Int(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Palavra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vocabulo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogada", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Jogada", new[] { "Usuario_Id" });
            DropTable("dbo.Palavra");
            DropTable("dbo.Usuario");
            DropTable("dbo.Jogada");
        }
    }
}
