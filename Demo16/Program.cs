using System;

namespace Demo16 {
    class Precio : IComparable<Precio>, IEquatable<Precio> {
        public double Valor { get; set; }
        public Precio (double valor) => Valor = valor;

        public Precio Sumar (Precio otro) => new Precio (Valor + otro.Valor);
        public Precio Restar (Precio otro) => new Precio (Valor - otro.Valor);

        public static Precio Cero => new Precio (0);
        public override string ToString () => $"${Valor:#,###.00}";

        public static Precio operator + (Precio a, Precio b) => a.Sumar (b);

        public int CompareTo (Precio b) => Valor.CompareTo (b.Valor);

        public bool Equals (Precio otro) => CompareTo (otro) == 0;
        public static bool operator < (Precio a, Precio b) => a.CompareTo (b) < 0;
        public static bool operator > (Precio a, Precio b) => a.CompareTo (b) > 0;
        public static bool operator <= (Precio a, Precio b) => a.CompareTo (b) <= 0;
        public static bool operator >= (Precio a, Precio b) => a.CompareTo (b) >= 0;

        public static implicit operator Precio(double valor) => new Precio (valor);
    }

    class Program {
        static void Main (string[] args) {
            Precio a = 100;
            var b = new Precio (200);
            var c = a + b;
            Console.WriteLine ($"El precio es de {c}, == {a == b}  > {a < b}");
        }
    }
}