namespace JogoDaForca.Repositorio.Migrations
{
    using Dominio;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<JogoDaForca.Repositorio.ContextoDeDados>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JogoDaForca.Repositorio.ContextoDeDados context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var palavras = new List<string>{
                                                "Gancho",
                                                "Dividir",
                                                "Erro",
                                                "Torre Eiffel",
                                                "Tomar",
                                                "Motor",
                                                "Centro",
                                                "Formigueiro",
                                                "Dois",
                                                "Gordura",
                                                "Lobisomem",
                                                "Estufa",
                                                "Tripe",
                                                "Vazamento",
                                                "Cachos",
                                                "Educaçao",
                                                "Pinturas",
                                                "Radiaçao",
                                                "Operadores",
                                                "Siames",
                                                "Barril",
                                                "Para-raios",
                                                "Bazuca",
                                                "Executivo",
                                                "Urgencia",
                                                "Irrigar",
                                                "Pontape",
                                                "Uva",
                                                "Microscopio",
                                                "Curva",
                                                "Narraçao",
                                                "Cabo",
                                                "Enterrar",
                                                "Inscriçao",
                                                "Enfermeira",
                                                "Vermelho",
                                                "Chamada",
                                                "Camadas",
                                                "Escuro",
                                                "Lobisomem",
                                                "Diagrama",
                                                "Coisa",
                                                "Machado",
                                                "Analise",
                                                "Valentao",
                                                "Soldado",
                                                "Avestruz",
                                                "Teoria",
                                                "Calça",
                                                "Antibiotico",
                                                "Sapato",
                                                "Perfurar",
                                                "Quebra cabeça",
                                                "Dividir",
                                                "Permanente",
                                                "Geometria",
                                                "Peregrino",
                                                "Membrana",
                                                "Misto",
                                                "Orelha"
                                        };

            var listaDePalavras = new List<Palavra>();

            foreach (var palavra in palavras)
            {
                listaDePalavras.Add(new Palavra() { Vocabulo = palavra });
            }

            context.Palavra.AddOrUpdate(p => p.Vocabulo, listaDePalavras.ToArray());
        }
    }
}
