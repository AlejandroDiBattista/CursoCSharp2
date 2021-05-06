namespace Demo10 {
    
    public class Oferta: IVendible {
        IVendible venta;

         public Oferta(Producto producto, int cantidad){
            if(cantidad == 3) {
                venta = new Oferta3x2(producto, cantidad);
            } else if(cantidad == 1) {
                venta = new Venta(producto, cantidad);
            } else {
                venta = new Oferta2x1(producto, cantidad);
            }
        }

        public virtual double Importe => venta.Importe;
        public override string ToString() => venta.ToString();
    }
}