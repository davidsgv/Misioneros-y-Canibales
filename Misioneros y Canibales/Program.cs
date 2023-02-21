using ArbolBusqueda;
using MisionerosCanibales;
using MisionerosCanibales.Conditions;
using MisionerosCanibales.Movimientos;
using static MisionerosCanibales.State;

var estadoInicial = new State(0,0,3,3, BoatStates.Right);
var estadoEsperado = new State(3,3,0,0, BoatStates.Left);

//var movimientos = new List<IProcess<State>>();
//movimientos.Add(new Canibales2());

var movimientos = new List<IProcess<State>>()
{
    new Cannibals2(),
    new Cannibal1(),
    new Missionary1(),
    new Missionaries2(),
    new MisioneroCanibal()
};

var conditions = new List<ICondition<State>>()
{
    new Condition()
};

var arbol = new BusquedaProfundidad<State>(estadoInicial, estadoEsperado, movimientos, conditions, 100000);
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
    Console.WriteLine(texto + " pasos: " + (resultado.Count - 1) + "\n");
}

Console.ReadLine();