using System.Collections.Generic;

public class Diretor
{
    public Diretor(string nome)
    {
        Nome = nome;
        Filmes = new List<Filme>();
    }
    public int Id { get; set; }
    
    public string Nome { get; set; }
    public ICollection<Filme> Filmes { get; set; }
    
     
     
}