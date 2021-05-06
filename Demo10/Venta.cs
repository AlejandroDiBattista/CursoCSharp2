namespace Demo10 {
    public class Venta : IVendible {
        public Producto Producto { get; init; }
        public int Cantidad { get; init; }

        public Venta(Producto producto, int cantidad){
            Producto = producto;
            Cantidad = cantidad;
        }

        public virtual double Importe => Producto.Precio * Cantidad;
        public override string ToString() => $"{Producto} x {Cantidad,2} = ${Importe, 5}";
    }
}