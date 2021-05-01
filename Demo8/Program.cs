using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo8 {
    class Program {
        public class Producto {
            public string Descripcion { get; set; }
            public double Precio { get; set; }

            public Producto(string descripcion, double precio){
                Descripcion = descripcion;
                Precio = precio;
            }

            public override string ToString() => $"{Descripcion, -20}   ${Precio,5}";

            public static Producto Coca  = new Producto("Coca Cola", 100);
            public static Producto Pepsi = new Producto("Pepsi Cola", 90);
            public static Producto Manao = new Producto("Manao Cola", 50);
        }

        public class Venta {
            public Producto Producto { get; set; }
            public int Cantidad; 

            public Venta(Producto producto, int cantidad){
                Producto = producto;
                Cantidad = cantidad;
            }

            public virtual double Importe => Producto.Precio * Cantidad;
            public override string ToString() => $"{Producto} x {Cantidad,3} = ${Importe,5}";
        }

        public class OfertaMxN: Venta {
            int M = 1;
            int N = 1;

            public OfertaMxN(Producto producto, int cantidad, int m, int n): base(producto, cantidad){
                M = m;
                N = n;
            }

            public override double Importe => Producto.Precio * (N * (Cantidad / M) + Cantidad % M);
            public override string ToString() => $"{base.ToString()} ({M}x{N})";
        }

        public class Oferta2x1 : OfertaMxN{
            public Oferta2x1(Producto producto, int cantidad): base(producto, cantidad, 2, 1){}
        }

        public class Oferta3x2 : OfertaMxN{
            public Oferta3x2(Producto producto, int cantidad): base(producto, cantidad, 3, 2){}
        }

        public class Factura {
            List<Venta> ventas = new List<Venta>();

            public void Agregar(Venta  venta) {
                ventas.Add(venta);
            }

            public double Total => ventas.Sum( p => p.Importe);

            public void Mostrar(){
                Console.WriteLine("Factura ");
                ventas.ForEach(v => Console.WriteLine($"- {v.ToString()}"));
                Console.WriteLine($"                                TOTAL : ${Total,5}");
            }
        }

        static void Main(string[] args) {
            Console.Clear();
            Console.WriteLine("\nDemo 'Facturación'\n");
            var f = new Factura();
            
            f.Agregar( new Venta(Producto.Coca, 10) );
            f.Agregar( new Oferta2x1(Producto.Pepsi, 10) );
            f.Agregar( new Oferta3x2(Producto.Manao, 10) );
            f.Agregar( new OfertaMxN(Producto.Coca, 30, 12, 10) );
            f.Mostrar();
        }
    }
}
