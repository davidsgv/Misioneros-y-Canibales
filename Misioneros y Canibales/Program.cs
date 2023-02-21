using ArbolBusqueda;
using MisionerosCanibales;
using MisionerosCanibales.Movimientos;

var estadoInicial = new State(0,0,3,3,1);
var estadoEsperado = new State(3,3,0,0,0);

//var movimientos = new List<IProcess<State>>();
//movimientos.Add(new Canibales2());

var movimientos = new List<IProcess<State>>()
{
    new Canibales2(),
    new Canibal1(),
    new Misionero1(),
    new Misioneros2(),
    new MisioneroCanibal()
};


var arbol = new BusquedaProfundidad<State>(estadoInicial, movimientos, estadoEsperado, 10);
var resultados = arbol.FindResult();

foreach (var resultado in resultados)
{
    var texto = "";
    foreach (var item in resultado)
    {
        switch (item)
        {
            case 1:
                texto += "2 Canibales + ";
                break;
            case 2:
                texto += "2 Misioneros + ";
                break;
            case 3:
                texto += "1 Canibal + ";
                break;
            case 4:
                texto += "1 Misionero + ";
                break;
            case 5:
                texto += "1 Misionero y 1 Canibal + ";
                break;
        }
    }
    Console.WriteLine(texto);
}

Console.ReadLine();