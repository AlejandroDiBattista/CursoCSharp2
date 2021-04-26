using System;

namespace Demo4
{
    public class Stack<Tipo>
    {
        private Tipo[] pila = new Tipo[100];
        private int cantidad = 0;
        public void Push(Tipo valor) { pila[cantidad++] = valor; }
        public bool IsEmpty() { return cantidad == 0; }
        public Tipo Pop() { return pila[--cantidad]; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo PILA Básica (int)");
            var s = new Stack<string>();
            s.Push("Cruel");
            s.Push("Mundo");
            s.Push("Hola");
            while (!s.IsEmpty())
            {
                Console.WriteLine($" - {s.Pop()}");
            }
            Console.Write("Press ENTER"); Console.ReadLine();
        }
    }
}
