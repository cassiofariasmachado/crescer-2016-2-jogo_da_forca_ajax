namespace JogoDaForca.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificarNomeTabelaJogadorELeaderboardEAdicionarEnumParaDificuldade : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Usuario", newName: "Jogador");
            DropForeignKey("dbo.Jogada", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Jogada", new[] { "Usuario_Id" });
            CreateTable(
                "dbo.Leaderboard",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pontuacao = c.Int(nullable: false),
                        Dificuldade = c.Int(nullable: false),
                        Jogador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jogador", t => t.Jogador_Id)
                .Index(t => t.Jogador_Id);
            
            AddColumn("dbo.Palavra", "Texto", c => c.String());
            DropColumn("dbo.Palavra", "Vocabulo");
            DropTable("dbo.Jogada");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Jogada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pontuacao = c.Int(nullable: false),
                        Modo = c.String(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Palavra", "Vocabulo", c => c.String());
            DropForeignKey("dbo.Leaderboard", "Jogador_Id", "dbo.Jogador");
            DropIndex("dbo.Leaderboard", new[] { "Jogador_Id" });
            DropColumn("dbo.Palavra", "Texto");
            DropTable("dbo.Leaderboard");
            CreateIndex("dbo.Jogada", "Usuario_Id");
            AddForeignKey("dbo.Jogada", "Usuario_Id", "dbo.Usuario", "Id");
            RenameTable(name: "dbo.Jogador", newName: "Usuario");
        }
    }
}
