using System;

namespace Demo10 {
    class Program
    {

        static void Main(string[] args){
            new Factura()
                .Agregar(new Venta(Producto.Coca, 10))
                .Agregar(new Oferta(Producto.Pesi, 3))
                .Agregar(new Oferta(Producto.Manao, 6))
                .Agregar(new Oferta(Producto.Manao, 1))
                .Agregar(new Descuento(Producto.Pesi, 8, 0.5))
            .Mostrar();
        }
    }
}
