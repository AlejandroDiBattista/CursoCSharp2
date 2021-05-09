using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo17 {
    public class Factura {
        class Linea {
            public IProducto Producto;
            public int Cantidad;
            public double Importe => Producto.Precio * Cantidad;
        }
        
        int NroFactura;
        List<Linea> Lineas;
        ICatalogo Catalogo;

        public Factura(ICatalogo catalogo) {
            NroFactura = ProximaFactura++;
            Catalogo = catalogo;
            Lineas = new();
        }

        private Linea BuscarLinea(Producto producto) {
            foreach(var linea in Lineas){
                if(linea.Producto == producto) return linea;
            }
            var nueva = new Linea{ Producto = producto };
            Lineas.Add(nueva);
            return nueva;
        } 
        
        public void Vender(int codigo, int cantidad) {
            var producto = Catalogo.Buscar(codigo);
            
            //var producto = Catalogo.Global.Buscar(codigo);

            if(producto == null) return;
            
            var linea = BuscarLinea(producto);
            if(linea == null) return;

            linea.Cantidad += cantidad;
        }


        public double Total => Lineas.Sum( l => l.Importe );
        public int Articulos => Lineas.Sum( l => l.Cantidad);

        public void Mostrar(){
            Console.WriteLine($"Factura #{NroFactura}");
            Lineas.ForEach( l => Console.WriteLine($" - {l.Producto.Descripcion,-20} {l.Producto.Precio,8:C} x {l.Cantidad,2} = {l.Importe,8:C} "));
            Console.WriteLine($" Son {Articulos,2} articulos por {Total,26:c}");
        }

        static int ProximaFactura = 1;
    }
}