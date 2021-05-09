using System.Collections.Generic;
using System.Linq;

namespace Demo17 {
    public interface ICatalogo {
        Producto Buscar(int codigo);
    }

    public class Catalogo: ICatalogo {
        private List<Producto> productos = new();

        public void Agregar(Producto producto) => productos.Add(producto);
        public Producto Buscar(int codigo) => productos.Where( p => p.Codigo == codigo).Single();

        public static Catalogo Cargar(){
            var salida = new Catalogo();
            salida.Agregar( new Producto(1, "Cola Cola", 100));
            salida.Agregar( new Producto(2, "Pepsi Cola", 80));
            salida.Agregar( new Producto(3, "Manao Cola", 40));
            salida.Agregar( new Producto(4, "Jorgito",    20));
            salida.Agregar( new Producto(5, "Cachafas",   90));
            return salida;
        }
    }
}