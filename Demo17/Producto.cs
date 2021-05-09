namespace Demo17 {

    public interface IProducto { 
        string Descripcion { get; } 
        double Precio { get; }
    }

    public class Producto : IProducto {
        public int Codigo { get; init; }
        public string Descripcion { get; init; } 
        public double Precio { get; set; }

        public Producto(int codigo, string descripcion, double precio) => (Codigo, Descripcion, Precio) = (codigo, descripcion, precio);
    }
}