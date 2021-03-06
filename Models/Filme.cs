public class Filme {
    public Filme(string titulo, int ano, string genero, int diretorId)
    {
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
        DiretorId = diretorId;
    }

    public int Id { get; set; }
    public string Titulo { get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }

    public int DiretorId { get; set; }
    public Diretor Diretor { get; set; }
    
}