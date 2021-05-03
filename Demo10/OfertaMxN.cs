namespace Demo10 {
    public class OfertaMxN : Venta {
        int M = 3;
        int N = 2;
        public OfertaMxN(Producto producto, int cantidad, int m, int n) : base(producto, cantidad){
            M = m;
            N = n;
        }

        public override double Importe => Producto.Precio * (N * Cantidad / M + Cantidad % M);
        public override string ToString() => $"{base.ToString()} ({M}x{N})";
    }
}