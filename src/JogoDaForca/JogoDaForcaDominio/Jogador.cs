namespace JogoDaForca.Dominio
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Jogador() { }

        public Jogador(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}