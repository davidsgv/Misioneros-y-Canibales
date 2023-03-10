using ArbolBusqueda;
using MisionerosCanibales;
using static MisionerosCanibales.State;

var estadoInicial = new State(0,0,3,3, BoatStates.Right);
var estadoEsperado = new State(3,3,0,0, BoatStates.Left);

//var movimientos = new List<IProcess<State>>();
//movimientos.Add(new Canibales2());

var arbol = new BusquedaProfundidad<State>(estadoInicial, estadoEsperado, 100000);
var resultados = arbol.FindResult();

foreach (var resultado in resultados)
{
    Console.WriteLine("------------------------------------");
    Console.WriteLine($"Solucion: {resultados.IndexOf(resultado) + 1}");
    foreach (var item in resultado)
    {
        var texto = $"Paso {item.Step}: {item.ProcessName}";
        Console.WriteLine(texto);
    }
    Console.WriteLine("------------------------------------" + "\n\n");
}

Console.ReadLine();