using System;
class Programa {
    delegate void Mostrar(int valor);                       // 1 

    static Mostrar Generar(int n) {                         // 2
        return (x) => Console.WriteLine($"{n++} : {x}");    // 3
    }

    static void Main() {
        var mostrar = Generar(100);                         // 4
        mostrar(10);                                        // 5
        mostrar(20);                                        // 6
    }
}
