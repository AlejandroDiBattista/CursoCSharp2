using System;
using System.Collections.Generic;

namespace Demo16 {

    partial struct Precio {
        private double Valor;

        public Precio(double valor) {
            if(valor < 0) throw new Exception("Los precios no pueden ser negativos");
            Valor = valor;
        }

        private Precio Sumar(Precio otro) => new Precio(Valor + otro.Valor);
        private Precio Restar(Precio otro) => new Precio(Valor - otro.Valor);

        public static Precio operator+(Precio a, Precio b) => a.Sumar(b);
        public static Precio operator-(Precio a, Precio b) => a.Restar(b);
        public static Precio operator*(Precio a, Double b) => new Precio(a.Valor * b);

        public override string ToString() => $"${Valor:#,##0.00}";
        public static implicit operator Precio(double valor) => new Precio (valor);
    }

    partial struct Precio : IEquatable<Precio> {
        public override int GetHashCode() => Valor.GetHashCode();

        public override bool Equals(object b) => b == null ? false : Equals((Precio)b);
        public bool Equals(Precio b) => Math.Abs(Valor - b.Valor) < 0.01;

        public static bool operator == (Precio a, Precio b) => a.Equals(b);
        public static bool operator != (Precio a, Precio b) => !a.Equals(b);
    }

    partial struct Precio: IComparable<Precio> {
        public int CompareTo(Precio b) => Equals(b) ? 0 : Valor.CompareTo(b.Valor);

        public static bool operator < (Precio a, Precio b) => a.CompareTo(b) < 0;
        public static bool operator <= (Precio a, Precio b) => !(a > b);
        public static bool operator > (Precio a, Precio b) => a.CompareTo(b) > 0;
        public static bool operator >= (Precio a, Precio b) => !(a < b);
    }

    class Producto{
        public string Descripcion;
        public Precio Precio;

        public Producto(string descripcion, Precio precio){
            Descripcion = descripcion;
            Precio = precio;
        }
        
        public void Robar() => Precio *= 2;
        public void Descontar(Precio p) => Precio -= p;

        public override string ToString() => $"{Descripcion,-20} {Precio,10}";
    }

    class Program {
        static void Main (string[] args) {
            Console.Clear();
            Console.WriteLine("Demostración de redifición de operadores");

            Precio a = new Precio(250);
            Precio b = 100;                                     // Convesion implicita
            Precio c = 200;
            var d = a + b - c * 1.1;                            // Redefinir Operadores matematicos;

            // Ordenas usando IComparable 
            var lista = new List<Precio>(){a, b, c, d};
            lista.Sort();
            Console.WriteLine("\nPrecios Ordenados (IComparable)");
            lista.ForEach( x => Console.WriteLine($"- {x}"));

            Console.WriteLine("\nComparación redifiniendo operadores");
            Console.WriteLine($"- {a} >  {b} = {a > b}");
            Console.WriteLine($"- {b} <= {c} = {b <= c}");

            Producto coca  = new Producto("Coca Cola", a);
            Producto pepsi = new Producto("Pepsi Cola", 100);   // Convesion implicita

            Console.WriteLine("\nListar Productos");
            Console.WriteLine ($"- {coca}");
            Console.WriteLine ($"- {pepsi}");
        }
    }
}