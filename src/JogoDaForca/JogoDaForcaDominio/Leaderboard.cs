namespace JogoDaForca.Dominio
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public Jogador Jogador { get; set; }
        public int Pontuacao { get; set; }
        public Dificuldade Dificuldade { get; set; }

        public Leaderboard() { }

        public Leaderboard(int id, Jogador jogador, int pontuacao, Dificuldade dificuldade)
        {
            this.Id = id;
            this.Jogador = jogador;
            this.Pontuacao = pontuacao;
            this.Dificuldade = dificuldade;
        }
    }
}
