// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using ArbolBusqueda;
using Baldes;

var estadoInicial = new State(new Buckect(6), new Buckect(8));

var valde6 = new Buckect(6);
var valde8 = new Buckect(8);
valde6.Value = 0;
valde8.Value = 4;
var estadoEsperado = new State(valde6, valde8);

var arbol = new BusquedaProfundidad<State>(estadoInicial, estadoEsperado, 2000);
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