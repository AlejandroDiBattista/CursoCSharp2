using System.Collections.Generic;
using System.Linq;

namespace Demo17{
    public class PuntoVenta {
        ICatalogo Catalogo;
        List<Factura> Facturas;

        public PuntoVenta(ICatalogo catalogo){
            Catalogo = catalogo;
            Facturas = new();
        }

        public Factura Abrir(){
            var f = new Factura(Catalogo);
            Facturas.Add(f);
            return f; 
        }
    }
}