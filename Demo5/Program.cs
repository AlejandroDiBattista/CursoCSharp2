using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo5
{
    class Producto
    {
        public string Descripcion { get; init; }
        public double Precio { get; init; }
        public Producto(string descripcion, double Precio)
        {
            this.Descripcion = descripcion;
            this.Precio = Precio;
        }
        public override string ToString()
        {
            return $"{this.Descripcion,-40} ${this.Precio,5}";
        }
    }

    class ProductoFisico : Producto
    {
        public int Existencia { get; set; }
        public ProductoFisico(string descripcion, double precio, int existencia) : base(descripcion, precio)
        {
            this.Existencia = existencia;
        }
    }

    class ProductoDigital : Producto
    {
        public int Descargas { get; set; }
        public ProductoDigital(string descripcion, double precio, int descargas) : base(descripcion, precio)
        {
            this.Descargas = descargas;
        }
    }

    class Venta
    {
        public Producto Producto;
        public int Cantidad;

        public Venta(Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

        virtual public double Importe
        {
            get { return Producto.Precio * Cantidad; }
        }

        public override string ToString() => $"{Producto} x {Cantidad,3} = ${Importe}";
    }

    class Oferta2x1 : Venta
    {
        public Oferta2x1(Producto producto, int cantidad) : base(producto, cantidad)
        {
        }

        override public double Importe => Producto.Precio * (Cantidad / 2 + Cantidad % 2);

        public override string ToString() => $"{base.ToString()} (2x1)";
    }

    class Oferta3x2 : Venta
    {

        public Oferta3x2(Producto producto, int cantidad) : base(producto, cantidad)
        {
        }

        override public double Importe
        {
            get => Producto.Precio * (2 * (Cantidad / 3) + Cantidad % 3);
        }

        public override string ToString() => $"{base.ToString()} (3x2)";
    }

    class Descuento : Venta
    {
        private double descuento = 0;

        public Descuento(Producto producto, int cantidad, double porcentaje) : base(producto, cantidad)
        {
            this.descuento = porcentaje / 100.0;
        }

        public Descuento(Producto producto, int cantidad) : this(producto, cantidad, 100.0)
        {
        }

        override public double Importe
        {
            get { 
                return (1.0 - descuento) * base.Importe;
            }
        }

        public override string ToString() => $"{base.ToString()} ({descuento*100}% off)";
    }

    class Ventas
    {
        private List<Venta> ventas = new List<Venta>();
        public void Vender(Venta venta)
        {
            ventas.Add(venta);
        }
        public void Imprimir()
        {
            foreach (var venta in ventas)
            {
                Console.WriteLine($" - {venta} ");
            };
            Console.WriteLine($"Total : {Total}");
        }

        public double Total { get => ventas.Sum(item => item.Importe); }
    }




    class Program
    {
        static void Main(string[] args)
        {
            var coca = new Producto("Coca Cola", 100);
            var pepsi = new Producto("Pepsi Cola", 120);
            var secco = new Producto("Secco Cola", 80);
            var manao = new Producto("Manao Cola", 60);

            var vs = new Ventas();

            vs.Vender(new Venta(coca, 10));
            vs.Vender(new Oferta2x1(pepsi, 10));
            vs.Vender(new Oferta3x2(producto: secco, cantidad: 10));
            vs.Vender(new Descuento(producto: manao, cantidad: 10, porcentaje: 70));
            vs.Imprimir();

            Console.Write("Pulse ENTER"); Console.ReadLine();
        }
    }
}
