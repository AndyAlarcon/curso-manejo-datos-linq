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
}