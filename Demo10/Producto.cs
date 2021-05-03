namespace Demo10 {
    
    public class Producto {
        public string Descripcion { get; init; }
        public double Precio { get; init;}

        public Producto(string descripcion, double precio){
            Descripcion = descripcion;
            Precio = precio;
        }

        public override string ToString() => $"{Descripcion,-20} ${Precio,5}";

        public static Producto Coca = new Producto("Coca Cola", 100);
        public static Producto Pesi = new Producto("Pepsi Cola", 90);
        public static Producto Manao = new Producto("Manao Cola", 50);
    }
}