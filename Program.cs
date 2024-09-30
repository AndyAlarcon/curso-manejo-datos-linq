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
// ImprimirValores(queries.LibrosConMasDe450PaginasOrdenDescendente());

//Top 3 Libros de Java por fecha de publicación.
// ImprimirValores(queries.Top3LibrosJavaPorFechaDePublicacion());

//Tercer y cuarto libro con más de 400 páginas.
// ImprimirValores(queries.TercerYCuartoLibroConMasDe400Paginas());

//Top 3 libros con propiedades título y número de páginas
// ImprimirValores(queries.Top3LibrosConTituloYNumeroDePaginas());

//Libros con número de páginas entre 200 y 500
// Console.WriteLine($"El total de libros con número de páginas entre 200 y 500 es: {queries.LibrosConPaginasEntre200Y500()}");

//Libro más antiguo publicado
// Console.WriteLine($"La fecha {queries.LibroMasAntiguoPublicado()} corresponde al libro más antiguo publicado.");

//Libro más extenso publicado
// Console.WriteLine($"El libro más extenso tiene {queries.LibroMasExtensoPublicado()} páginas");

//Libro más corto
// var libroMasCorto = queries.LibroMasCorto();
// Console.WriteLine($"El libro {libroMasCorto.Title} es el más corto con {libroMasCorto.PageCount} páginas");

//Libro más reciente
// var libroMasReciente = queries.LibroMasRecientePublicado();
// Console.WriteLine($"El libro {libroMasReciente.Title} es el más reciente con fecha {libroMasReciente.PublishedDate} de publicación");

//Total de páginas de libros entre 0 y 500 páginas
// Console.WriteLine($"{queries.TotalPaginasLibrosHasta500Paginas()} es el total de páginas de libros entre 0 y 500 páginas");

//Libros publicados después del 2015
// Console.WriteLine(queries.TitulosLibrosDespuesDel2015Concatenados());

//Promedio de carácteres de los títulos de los libros
// Console.WriteLine($"Promedio de carácteres de los títulos de los libros: {queries.PromedioCaracteresTitulo()}");

//Promedio de páginas de los libros
// Console.WriteLine($"Promedio de páginas de los libros: {queries.PromedioPaginasLibros()}");

//Libros publicados a partir del 2000 agrupados ppor año
// ImprimirValoresAgrupados(queries.LibrosDespuesDel200AgrupadosAno());

//Diccionario de libros agrupados por primera letra del título
// var diccionarioLookUp = queries.BuscarLibrosPorInicial();
// ImprimirValoresDiccionario(diccionarioLookUp, 'A');

//Libros filtrados por cláusula Join

ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Paginas());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirValoresAgrupados(IEnumerable<IGrouping<int, Book>> ListaLibros)
{
    foreach(var grupo in ListaLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key}");
        Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}

void ImprimirValoresDiccionario(ILookup<char, Book> listaLibros, char letra)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listaLibros[letra])
    {
         Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}