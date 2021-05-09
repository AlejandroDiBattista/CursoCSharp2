using System;

namespace Demo17{
    class Program {
        static void Main(string[] args) {
            Console.Clear();
            
            Catalogo catalogo = Catalogo.Cargar();
            PuntoVenta pv = new(catalogo);

            var f = pv.Abrir();
            f.Vender(1,  1);  // $100
            f.Vender(1,  2);
            f.Vender(4,  4);  // $ 20
            f.Vender(1, -1);

            // Console.WriteLine($"Vendimos {f.CantidadProductos} productos por {f.Total:C}");
            f.Mostrar();
        }
    }
}
