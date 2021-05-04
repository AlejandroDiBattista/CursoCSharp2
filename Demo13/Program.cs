using System;

namespace Demo13
{
    class Producto{
        public string Descripcion { get;set;}
        public double Precio { get; set;}
    }

    delegate double CalculadorImporte(double precio, int cantidad);

    class Venta { // Usa delegado para generalizar el calculo de los importes de la venta. 
        CalculadorImporte calculador;
        Producto producto;
        int cantidad;

        public Venta(Producto producto, int cantidad, CalculadorImporte calculador){
            this.producto = producto;
            this.cantidad = cantidad;
            this.calculador = calculador;
        }

        public double Importe() {
            return this.calculador(producto.Precio, cantidad);
        }
    }

    class Program {
        delegate void Mostrador(int x);


        static void Mostrar(int valor){
            Console.WriteLine($" el valor es {valor}");
        }
     
        static double Oferta2x1(double precio, int cantidad){
            return precio * (cantidad / 2 + cantidad % 2);
        }
        static double Descuento20(double precio, int cantidad){
            return precio * cantidad * 0.8;
        }

        // Robo0 a Robo2 son exactamente mismo, solo cambia la sintaxis 
        static double Robo0(double precio, int cantidad){
            return precio * cantidad * 2;
        }

        static double Robo1(double precio, int cantidad) => precio * cantidad * 2;

        static CalculadorImporte Robo2 = (p, c) => p * c * 2;

        static void Main(string[] args)
        {
            var coca = new Producto{ Descripcion= "Coca Cola",Precio=100};
            
            var v1 = new Venta(coca, 100, Oferta2x1);
            Console.WriteLine($"El importe es {v1.Importe()}");

            var v2 = new Venta(coca, 100, Descuento20);
            Console.WriteLine($"El importe es {v2.Importe()}");

            // v3 a v5 hacen exactamente lo mismo... solo usan diferentes sintasis
            var v3 = new Venta(coca, 100, Robo0);
            var v4 = new Venta(coca, 100, Robo1);
            var v5 = new Venta(coca, 100, Robo2);
            var v6 = new Venta(coca, 100, (p, c) => p * c * 2);

            Console.WriteLine($"El importe es {v3.Importe()}");

        }
    }
}
