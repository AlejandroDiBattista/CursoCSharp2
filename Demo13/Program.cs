using System;

namespace Demo13
{
    class Producto{
        public string Descripcion { get;set;}
        public double Precio { get; set;}
    }
    delegate double CalculadorImporte(double precio, int cantidad);


    class Venta {
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


    class Program
    {
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

        static double Robo(double precio, int cantidad) => precio * cantidad * 2;

        static CalculadorImporte Robo2 = (p, c) => p * c * 2;


        static void Main(string[] args)
        {
            var coca = new Producto{ Descripcion= "Coca Cola",Precio=100};
            
            var v1 = new Venta(coca, 100, Oferta2x1);
            Console.WriteLine($"El importe es {v1.Importe()}");

            var v2 = new Venta(coca, 100, Descuento20);
            Console.WriteLine($"El importe es {v2.Importe()}");

            var v3 = new Venta(coca, 100, (p, c) => p * c *2);
        //    var v3 = new Venta(coca, 100, Robo2);
            Console.WriteLine($"El importe es {v3.Importe()}");

        }
    }
}
