using System.Reflection.Metadata;

public class LinqQueries
{
    private List<Book> librosCollection;
    public LinqQueries()
    {
        this.librosCollection = new List<Book>();
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
        }
    }
    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }
    public IEnumerable<Book> LibrosDespuesDel200()
    {
        //Extension method
        // return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //Query expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }
    
    public IEnumerable<Book> LibrosMas250PagTituloInAction()
    {
        //Extension method
        // return librosCollection.Where(p => p.PageCount > 250).Where(p=> p.Title.Contains("in Action"));
        return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        //Query expresion
        // return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }
    public bool TodosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }
    public bool HayLibrosPublicadosEn2005()
    {
        return librosCollection.Any(p=> p.PublishedDate.Year == 2005);
    }
    public IEnumerable<Book> LibrosDePython()
    {
        return librosCollection.Where(p=> p.Categories.Contains("Python"));
    }
    public IEnumerable<Book> LibrosDeJavaOrdenAscendente()
    {
        return librosCollection.Where(p=> p.Categories.Contains("Java")).OrderBy(p=> p.Title);
    }
    public IEnumerable<Book> LibrosConMasDe450PaginasOrdenDescendente()
    {
        return librosCollection.Where(p=> p.PageCount > 450).OrderByDescending(p=> p.PageCount);
    }
    public IEnumerable<Book> Top3LibrosJavaPorFechaDePublicacion()
    {
        return librosCollection
        .Where(p=> p.Categories.Contains("Java"))
        .OrderByDescending(p=> p.PublishedDate)
        .Take(3);
    }
    public IEnumerable<Book> TercerYCuartoLibroConMasDe400Paginas()
    {
        return librosCollection
        .Where(p=> p.PageCount > 400)
        .Skip(2)
        .Take(2);
    }
    public IEnumerable<Book> Top3LibrosConTituloYNumeroDePaginas()
    {
        return librosCollection
        .Take(3)
        .Select(p=> new Book() { Title = p.Title, PageCount = p.PageCount});
    }

    public long LibrosConPaginasEntre200Y500()
    {
        //Mala práctica con oportunidad de refactorizar
        // return librosCollection.Where(p=> p.PageCount >= 200 && p.PageCount <= 500).LongCount();

        //Dado que count y long count, pemriten evaluar condiciones, se elimina el operador Where
        //Con el fin de no realizar dos operaciones sobre la colección.
        return librosCollection.LongCount(p=> p.PageCount >= 200 && p.PageCount <= 500);
    }
    public DateTime LibroMasAntiguoPublicado()
    {
        return librosCollection.Min(p=> p.PublishedDate);
    }
    public int LibroMasExtensoPublicado()
    {
        return librosCollection.Max(p=> p.PageCount);
    }
    public Book LibroMasCorto()
    {
        return librosCollection.Where(p=> p.PageCount > 0).MinBy(p=> p.PageCount);
    }
    public Book LibroMasRecientePublicado()
    {
        return librosCollection.MaxBy(p=> p.PublishedDate);
    }
    public int TotalPaginasLibrosHasta500Paginas()
    {
        return librosCollection
        .Where(p=> p.PageCount >= 0 && p.PageCount <= 500)
        .Sum(p=> p.PageCount);
    }
    public string TitulosLibrosDespuesDel2015Concatenados()
    {
        return librosCollection
        .Where(p=> p.PublishedDate.Year > 2015)
        .Aggregate("", (TitulosLibros, next) =>
        {
            if(TitulosLibros != string.Empty)
                TitulosLibros += " - " + next.Title;
            else    
                TitulosLibros += next.Title;

            return TitulosLibros;
        });
    }
}