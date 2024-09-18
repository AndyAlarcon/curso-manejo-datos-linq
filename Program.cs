// See https://aka.ms/new-console-template for more information
LinqQueries queries = new LinqQueries();

//Toda la colección
// ImprimirValores(queries.TodaLaColeccion());

//Libros después del 2000.
// ImprimirValores(queries.LibrosDespuesDel200());

//Libros con más de 250 páginas y con "in action" en título
// ImprimirValores(queries.LibrosMas250PagTituloInAction());

//Todos los libros tienen Status.
// Console.WriteLine($"Todos los libros tienen Status? - {queries.TodosLibrosTienenStatus()}");

//Hay libros publicados en 2005
// Console.WriteLine($"Hay libros publicados en 2005? - {queries.HayLibrosPublicadosEn2005()}");

//Libros de Python.
// ImprimirValores(queries.LibrosDePython());

//Libros de Java, ordenados de manera ascendente por título.
// ImprimirValores(queries.LibrosDeJavaOrdenAscendente());

//Libros con más de 450 páginas, ordenados de forma descendente por número de páginas.
ImprimirValores(queries.LibrosConMasDe450PaginasOrdenDescendente());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}