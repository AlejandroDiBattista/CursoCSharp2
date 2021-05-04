using System;
using System.Collections.Generic;

namespace Demo14 {

    public interface IEnumerable {
        bool Next { get; }
        int Current { get; }
    }

    public static class Extensiones {
        public static void Mostrar(this IEnumerable a){
            while (a.Next) {
                Console.WriteLine(a.Current);
            }
        }

        public static int Contar(this IEnumerable a) {
            var c = 0;
            while (a.Next) {
                c++;
            }
            return c;
        }

        public delegate bool Condicion(int x);

        public static IEnumerable Filtrar(this IEnumerable a, Condicion condicion) {
            var salida = new Lista();
            while (a.Next) {
                if (condicion(a.Current))
                    salida.Agregar(a.Current);
            }
            return salida;
        }

        public static IEnumerable Unir(this IEnumerable a, IEnumerable b){
            var salida = new Lista();
            while(a.Next) { salida.Agregar(a.Current); }
            while(b.Next) { salida.Agregar(b.Current); }
            return salida;
        }
    }

    class Decena : IEnumerable {
        int proximo = 0;
        public bool Next => ++proximo <= 10;
        public int Current => proximo;
    }

    public class Lista : IEnumerable {
        List<int> lista = new List<int>();
        int proximo = -1;
        public bool Next => ++proximo < lista.Count;
        public int Current => lista[proximo];

        public void Agregar(int valor) => lista.Add(valor);
        public int Item(int p) => lista[p];
        public int Cantidad => lista.Count;
    }

    public class Pares : IEnumerable {
        IEnumerable Lista;
        public Pares(IEnumerable lista){
            Lista = lista;
        }

        public bool Next {
            get  {
                if(Lista.Next && Lista.Current % 2 == 2) return true;
                return Lista.Next;
            }
        }

        public int Current => Lista.Current;
    }

    delegate void Mostrar(int valor);

    class Program {

        static Mostrar GenerarMostrar(int n) {
            return (x) => Console.WriteLine($"{n++} : {x}");
        }

        static void Main(string[] args){
            var a = new Decena();

            Lista b = new Lista();
            b.Agregar(10);
            b.Agregar(21);
            b.Agregar(30);
            b.Agregar(31);
            b.Agregar(31);
            b.Agregar(35);

            var c = new Pares(a);
            // b.Unir(c).Filtrar( (x) => { return x % 5 == 0;}).Mostrar();

            var mm = GenerarMostrar(100);
            mm(1);
            mm(2);
            mm(3);
        }
    }
}

