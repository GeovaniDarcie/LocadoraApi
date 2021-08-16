public class FilmeOutputGetAllDTO {
    public FilmeOutputGetAllDTO(int id, string titulo, int ano, string genero)
    {
        Id = id;
        Titulo = titulo;
        Ano = ano;
        Genero = genero;
    }

    public int Id { get; set; }
    public string Titulo { get; set; }
    public int Ano { get; set; }
    public string Genero { get; set; }
}