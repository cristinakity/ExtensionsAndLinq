// See https://aka.ms/new-console-template for more information
using Bogus;
using ExtensionsAndLinq;
using Newtonsoft.Json;
using System.Text.Json;

#region Linq

// Crear una lista de Ventas
List<Venta> ventas = new List<Venta>();
ventas = GenerarVentasFalsas(10000);
//MostrarLista(ventas);
//foreach to add 1000 items
//for (int i = 0; i < 5; i++)
//{
//    ventas.Add(new Venta()
//    {
//        Id = i,
//        Producto = $"Producto {i}",
//        Cantidad = i,
//        Precio = i + 1,
//        Total = 0,
//        TipoDeVenta = i % 2 == 0 ? "Contado" : "Credito",
//        Fecha = DateTime.Now.AddDays(-i)
//    });
//}
//for (int i = 0; i < 5; i++)
//{
//    ventas.Add(new Venta()
//    {
//        Id = i,
//        Producto = $"Producto {i}",
//        Cantidad = i,
//        Precio = i + 1,
//        Total = 0,
//        TipoDeVenta = i % 2 == 0 ? "Contado" : "Credito",
//        Fecha = DateTime.Now.AddDays(-i)
//    });
//}

//MostrarVentas(ventas);

// Ejemplo de Select con linq
var listaDePrecios = ventas.Select(x => x.Precio).ToList();
//MostrarLista(listaDePrecios);
var listaDePreciosOrdenada = ventas.OrderBy(x => x.Precio)
                                    .Select(x => x.Precio)
                                    .ToList();
//MostrarLista(listaDePreciosOrdenada);
var listaDePrecioSinRepetir = listaDePreciosOrdenada.Distinct().ToList();
//MostrarLista(listaDePrecioSinRepetir);

Console.WriteLine(listaDePrecioSinRepetir.Max());
Console.WriteLine(ventas.Max(x=> x.Precio));
Console.WriteLine(listaDePrecioSinRepetir.Min());
Console.WriteLine(ventas.Min(x => x.Precio));

// Ejemplo de Where con linq
var ventasMayorA10 = ventas.Where(x => x.Precio > 10).ToList();
//conver to string json with newtonsoft
//MostrarLista(ventasMayorA10);

// ventas del  2023-05-20
var fecha = "2023-05-20";
var query = ventas.Where(x => x.Fecha.Date == Convert.ToDateTime(fecha));
if (query.Any())
{
    Console.WriteLine($"Se encontraron {query.Count()} ventas");
    //MostrarLista(query.ToList());
}
else
{
    Console.WriteLine("No hay ventas para la fecha indicada");
}


// Ejemplo de OrderBy con linq
var ventasOrdenasPorPrecio = ventas.OrderBy(x => x.Precio).ToList();
//MostrarLista(ventasOrdenasPorPrecio.Select(x=> x.Precio).ToList());

//Obtener lista de precios de mayor a menor
// Obtener la lista de precios
var listaPreciosOriginal = ventas.Select(x => x.Precio).ToList();
//Order descendentes o de mayor a menor

// Ejemplo de OrderByDescending con linq
var listaPreciosDescendente = listaPreciosOriginal.OrderByDescending(x => x);
var listaPreciosAscendente = listaPreciosOriginal.OrderBy(x=> x);
//MostrarLista(listaPciosAscendente.ToList());

// Obtener el producto mas caro

var precioMasCaro = ventas.Max(x => x.Precio);
// 1-Buscar el producto con el precio = precioMasCaro
var productoMasCaro1 = ventas.FirstOrDefault(x => x.Precio == precioMasCaro)?.Producto;
// 2-Order por precio descende y tomar el primero
var ventaConProductoMasCaro = ventas.OrderByDescending(x => x.Precio).FirstOrDefault();
Console.WriteLine($"Poducto:{productoMasCaro1}, Precio: {precioMasCaro}");
Console.WriteLine($"Poducto:{ventaConProductoMasCaro.Producto}, Precio: {ventaConProductoMasCaro.Precio}");

//Lista de categorias, y las voy a ordernar
var listaCategorias = ventas
    .Select(x => new { x.Category, x.Department })
    .OrderBy(x => x.Category).ToList();

////Lista de departamentos, y los voy a ordenar
//var listadepartamentos = ventas
//    .Select(x => new { x.Category, x.Department })
//    .OrderBy(x => x.Department).ToList();

Console.WriteLine("Lista ordenada por categorias");
//MostrarLista(listaCategorias);
//Console.WriteLine("Lista de Departamentos");
//MostrarLista(listadepartamentos);

// Ejemplo de ThenBy con linq
// Ejemplo de ThenByDescending con linq
var listaOrdenadaPorCategoriasYDespuesPorDepartamentos = 
    ventas
    .Select(x => new { x.Category, x.Department })
    .OrderBy(x => x.Category).ThenByDescending(x => x.Department)
    .ToList();

Console.WriteLine("Lista ordenada por categorias y despues por departamentos");
//MostrarLista(listaOrdenadaPorCategoriasYDespuesPorDepartamentos);

Console.WriteLine($"total ventas {ventas.Count}");

// Ejemplo de Take con linq
var primeras5Ventas = ventas.Take(5).ToList();
//MostrarLista(primeras5Ventas);

// Ejemplo de Skip con linq
var ultimos5 = ventas.Skip(ventas.Count-5).ToList();
//MostrarLista(ultimos5);

//ejemplo para ver datos de pagina 2, de 10 en 10 registros
var ventasPaginadas =  ObterVentasPagindas(ventas, 5, 10);
MostrarLista(ventasPaginadas);

// Ejemplo de TakeWhile con linq
// Ejemplo de SkipWhile con linq
// Ejemplo de First con linq
// Ejemplo de FirstOrDefault con linq
// Ejemplo de Last con linq
// Ejemplo de LastOrDefault con linq
// Ejemplo de Single con linq
// Ejemplo de SingleOrDefault con linq
// Ejemplo de ElementAt con linq
// Ejemplo de ElementAtOrDefault con linq
// Ejemplo de Any con linq
// Ejemplo de All con linq
// Ejemplo de Contains con linq
// Ejemplo de Count con linq
// Ejemplo de Sum con linq
// Ejemplo de Min con linq
// Ejemplo de Max con linq
// Ejemplo de Average con linq
// Ejemplo de Aggregate con linq
// Ejemplo de GroupBy con linq
// Ejemplo de Join con linq
// Ejemplo de GroupJoin con linq
// Ejemplo de SelectMany con linq
// Ejemplo de Distinct con linq
// Ejemplo de Union con linq
// Ejemplo de Intersect con linq
// Ejemplo de Except con linq
// Ejemplo de ToList con linq
// Ejemplo de ToArray con linq
// Ejemplo de ToDictionary con linq

#endregion Linq

#region extension methods
/*
Console.WriteLine("Hello, World!");
DateTime dateTime = DateTime.Now;
Console.WriteLine($"{dateTime}");
Console.WriteLine($"{dateTime.ToShortDateString()}");
Console.WriteLine($"{dateTime.ToSpecialDate("🙌")}");
*/
#endregion extension methods

// mostrar ventas
static void MostrarVentas(List<Venta> ventas)
{
    foreach (var venta in ventas)
    {
        Console.WriteLine($"{venta.Id} {venta.Producto} {venta.Cantidad} {venta.Precio} {venta.Total} {venta.Fecha} {venta.TipoDeVenta}");
    }
}

//mostar elementos de List<T> usando reflection
static void MostrarLista<T>(List<T> lista)
{
    Console.WriteLine(JsonConvert.SerializeObject(lista, Formatting.Indented));
}

static List<Venta> GenerarVentasFalsas(int numeroVentas)
{
    Faker faker = new Faker();

    Randomizer.Seed = new Random(41596461);

    var tipoDeVenta = new[] { "Contado", "Credito" };

    var orderIds = 1;
    var ventas = new Faker<Venta>()
        //Ensure all properties have rules. By default, StrictMode is false
        //Set a global policy by using Faker.DefaultStrictMode
        .StrictMode(true)
        //OrderId is deterministic
        .RuleFor(o => o.Id, f => orderIds++)
        //Pick some fruit from a basket
        .RuleFor(o => o.Cliente, f => f.Person.FullName)
        .RuleFor(o => o.Producto, f => f.Commerce.Product())
        //A random quantity from 1 to 10
        .RuleFor(o => o.Cantidad, f => f.Random.Number(1, 20))
        //A nullable int? with 80% probability of being null.
        //The .OrNull extension is in the Bogus.Extensions namespace.
        .RuleFor(o => o.TipoDeVenta, f => f.PickRandom(tipoDeVenta))
        .RuleFor(o => o.Precio, f => Math.Round(f.Random.Decimal(1,100),4))
        .RuleFor(o => o.Department, f => f.Commerce.Department())
        .RuleFor(o => o.Category, f => f.Commerce.Categories(10)[0])
        .RuleFor(o => o.Total, (f, o) => o.Cantidad * o.Precio)
        .RuleFor(o => o.Fecha, f => f.Date.Past(0));
    return ventas.Generate(numeroVentas).ToList();
}

static List<Venta> ObterVentasPagindas(List<Venta> ventas, int numeroPagina, int ventasPorPagina)
{
    var skip = ventasPorPagina * (numeroPagina-1);
    return ventas.Skip(skip).Take(ventasPorPagina).ToList();
}