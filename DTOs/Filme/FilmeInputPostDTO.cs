public class FilmeInputPostDTO {
     public FilmeInputPostDTO(string titulo, int ano, string genero, int diretorId)
    {
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
        DiretorId = diretorId;
    }
    public string Titulo { get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }
    public int DiretorId { get; set; }
}