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
}