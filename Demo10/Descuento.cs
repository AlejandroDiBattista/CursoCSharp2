namespace Demo10
{
    public class Descuento : Venta
    {
        double Porcentaje;
        public Descuento(Producto producto, int cantidad, double porcentaje) : base(producto, cantidad){
            Porcentaje = porcentaje;
        }

        public override double Importe => base.Importe * (1.0 - Porcentaje);
        public override string ToString() => $"{Producto} x {Cantidad,2} = ${Importe, 5} (off {Porcentaje*100,2}%)";
    }
}