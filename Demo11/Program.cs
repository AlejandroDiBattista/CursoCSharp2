using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo11
{
    class Producto{
        public string Descripcion { get; set; }
        public double Precio { get; set; }
    }

    interface IVendible {
        double Importe { get; }
    }

    class Venta: IVendible {
        Producto producto;
        int cantidad;

        public Venta(Producto producto, int cantidad){
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public virtual double Importe { 
            get { 
                return producto.Precio * cantidad;
            }
        }
    }

    class Oferta: Venta {
        public Oferta(Producto producto, int cantidad): base(producto, cantidad){}
        public override double Importe { 
            get {
                var importe = base.Importe;
                importe *= 0.8; 
                return importe;
            }
        }
    }

    class Descuento: IVendible {
        IVendible venta;
        public Descuento(IVendible venta){
            this.venta = venta;
        }
        public double Importe { 
            get {
                var importe = venta.Importe;
                importe *= 0.8; 
                return importe;
            }
        }
    }

    class Mayorista: IVendible {
        IVendible venta;
        public Mayorista(IVendible venta){
            this.venta = venta;
        }
        public double Importe { 
            get {
                var importe = venta.Importe;
                if(importe > 1000) importe *= 0.9; 
                return importe;
            }
        }
    }

    class OfertaLoca: IVendible {
        IVendible venta;
        public OfertaLoca(IVendible venta){
            this.venta = venta;
        }
        
        public double Importe { 
            get {
                var importe = venta.Importe;
                if(importe == 123.0) importe = 100; 
                return importe;
            }
        }
    }

    class Paquete : IVendible{
        List<IVendible> ventas;
        public Paquete(){
            ventas = new List<IVendible>();
        }

        public void Agregar(IVendible venta){
            ventas.Add(venta);
        }

        public double Importe { 
            get {
                return ventas.Sum( v => v.Importe);
            }
        }
    }

    class Auditoria : IVendible{
        IVendible venta;

        public Auditoria(IVendible venta){
            this.venta = venta;
        }

        public double Importe { 
            get {
                var importe = venta.Importe;
                Console.WriteLine($"Estamos vendiendo ${importe}"); 
                return importe;
            }
        }
    }


    delegate IVendible Promocion(IVendible entrada);

    class Sucursal {
        List<Promocion>  promociones = new List<Promocion>();
        public void Registrar(Promocion v) { 
            promociones.Add(v); 
        }

        public IVendible Aplicar(IVendible venta) { 
            foreach (var v in promociones){
                venta = v(venta);
            }
            return venta;
        }
    }

    class Program {
        // Ejemplo de uso de interface para delegar funcionalidad
        // Padron: Decorador 

        static void Mostrar(IVendible venta){
            Console.WriteLine($"El importe es {venta.Importe}");
        }

        static void Main(string[] args)
        {
            var c = new Producto{ Descripcion = "Cola Cola", Precio = 100};
            var m = new Producto{ Descripcion = "Mirinda", Precio = 80};

            var v = new Descuento(new Venta(c, 10));
            var p = new Paquete();

            var s = new Sucursal();
            s.Registrar( v => new Descuento(v));
            s.Registrar( v => new Auditoria(v));
            s.Registrar( v => new OfertaLoca(v));
            s.Registrar( v => new Descuento(v));
            s.Registrar( v => new Auditoria(v));

            // p.Agregar( new Auditoria(new OfertaLoca(new Descuento(new Venta(m, 5)))));
            // p.Agregar( new OfertaLoca(new Descuento(new Auditoria(new Venta(m, 5)))));
            // p.Agregar( new Mayorista(new OfertaLoca(new Venta(m, 5))));

            Mostrar(s.Aplicar(new Venta(c, 10)));
        }
    }
}
