using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo21 {
    record Producto(string Descripcion, double Precio);

    class Inventario : IEnumerable<Producto>{
        List<Producto> productos = new();
        
        public void Agregar(Producto producto) => productos.Add(producto);

        public IEnumerable<Producto> Todos() => productos;

        public IEnumerator<Producto> GetEnumerator() {
            foreach(var x in productos){
                yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    
        public static Producto Crear(string Descripcion, double Precio) {
            Console.WriteLine("Holis");
            return new(Descripcion, Precio);
        }

    }    

    static class Extenciones  {

        public static void ForEach<T>(this IEnumerable<T> enumeracion, Action<T> accion) {
            foreach(var p in enumeracion)
                accion(p);
        }
    } 
    class Program {
        static void Main(string[] args) {
            var inventario = new Inventario();
            inventario.Agregar( new Producto("Coca", 100));
            inventario.Agregar( new("Pepsi", 80));
            inventario.Agregar( new("Manao", 40));

            // foreach(var p in inventario){
            //     Console.WriteLine($"{p}");
            // }

           inventario.ForEach( p => Console.WriteLine($"{p}"));
            // Extenciones.ForEach(inventario, p => Console.WriteLine($"{p}"));

        }
    }
}
