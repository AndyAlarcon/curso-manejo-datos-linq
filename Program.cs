// See https://aka.ms/new-console-template for more information
LinqQueries queries = new LinqQueries();

//Toda la colección
// ImprimirValores(queries.TodaLaColeccion());

//Libros después del 2000.
// ImprimirValores(queries.LibrosDespuesDel200());

//Libros con más de 250 páginas y con "in action" en título
ImprimirValores(queries.LibrosMas250PagTituloInAction());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}