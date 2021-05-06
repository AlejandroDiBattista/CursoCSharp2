using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo10 {
    public class Factura {
        static int ProximaFactura = 1; 
        int NroFactura;
        List<IVendible> ventas;

        public Factura(){
            NroFactura = ProximaFactura++;
            ventas = new List<IVendible>();
        }

        public double Total => ventas
            .Select(v => v.Importe)
            .Sum( );
        
        public Factura Agregar(IVendible venta) {
            ventas.Add(venta);
            return this; // Esto es para que se pueden usar interface fluidas 
        } 

        public void Mostrar(){
            Console.WriteLine($"\nFactura #001-{NroFactura,5:00000}");
            ventas.ForEach( v => Console.WriteLine($"- {v}") );
            Console.WriteLine($"                               TOTAL ${Total,5}\n");
        }
    }
}