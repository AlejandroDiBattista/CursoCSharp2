using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo10
{
    public class Factura
    {
        List<IVendible> ventas = new List<IVendible>();

        public double Total => ventas
            .Select(v => v.Importe)
            .Sum( );
        
        public Factura Agregar(IVendible venta) {
            ventas.Add(venta);
            return this;
        } 

        public void Mostrar(){
            Console.WriteLine("Factura #0000");
            ventas.ForEach( v => Console.WriteLine($"- {v}") );
            Console.WriteLine($"                               TOTAL ${Total,5}");
        }
    }
}