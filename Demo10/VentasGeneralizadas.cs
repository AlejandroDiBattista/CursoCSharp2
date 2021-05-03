using System;

namespace Demo10 {

    // Este ejemplo muestra como usar las herencia para implementar comportamientos especializados. 
    class VentasGeneralizadas {
        static void Main(string[] args){
            var f = new Factura();                          // Uso normal
            f.Agregar(new Venta(Producto.Coca, 10));
            f.Agregar(new Oferta3x2(Producto.Pesi, 3));
            f.Agregar(new Oferta2x1(Producto.Manao, 6));
            f.Mostrar();

            new Factura()                                   // Uso fluido. Llamadas en cascada
                .Agregar(new Venta(Producto.Coca, 10))
                .Agregar(new Oferta(Producto.Pesi, 3))
                .Agregar(new Oferta(Producto.Manao, 6))
                .Agregar(new Oferta(Producto.Manao, 1))
                .Agregar(new Descuento(Producto.Pesi, 8, 0.5))
            .Mostrar();

        }
    }
}
