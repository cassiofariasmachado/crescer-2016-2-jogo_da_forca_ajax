namespace JogoDaForca.Dominio
{
    public class Palavra
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public Palavra() { }

        public Palavra(int id, string texto)
        {
            this.Id = id;
            this.Texto = texto;
        }
    }
}