public class FilmeOutputGetByIdDTO {
    public FilmeOutputGetByIdDTO(int id, string titulo, int ano, string genero, string nomeDoDiretor)
    {
        Id = id;
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
        NomeDoDiretor = nomeDoDiretor;
    }

    public int Id { get; set; }
    public string Titulo { get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }
    public string NomeDoDiretor { get; set; }
}