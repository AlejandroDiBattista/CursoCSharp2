using System;
using System.Collections.Generic;

namespace Demo7{
    interface IStack<T> {
        void Push(T valor);
        bool IsEmpty { get; }
        T Pop();
    }

    class StackSimple<T> : IStack<T> {
        T[] pila = new T[100];
        int cantidad = 0;

        public void Push(T valor) => pila[cantidad++] = valor;
        public bool IsEmpty => cantidad == 0;
        public T Pop() => pila[--cantidad];
    }

    class StackEnlazada<T> : IStack<T> {
        class Nodo {
            public T Valor;
            public Nodo Anterior;
        }
        Nodo raiz = null;

        public void Push(T valor) =>  raiz = new Nodo { Valor = valor, Anterior = raiz };
        public bool IsEmpty => raiz == null;
        public T Pop() {
            var valor = raiz.Valor;
            raiz = raiz.Anterior;
            return valor;
        }
        public T Top => raiz.Valor;
    }

    class StackAdaptada<T> : IStack<T> {
        Stack<T> pila = new Stack<T>();

        public void Push(T valor) => pila.Push(valor);
        public bool IsEmpty => pila.Count == 0;
        public T Pop() => pila.Pop();
    }

    class DemoPilaImplementadaConInterface {
        static void Main(string[] args) {
            //IStack<int> s = new StackSimple<int>();
            //IStack<int> s = new StackEnlazada<int>();
            IStack<int> s = new StackAdaptada<int>();
            s.Push(10);
            s.Push(20);
            s.Push(30);
            
            while (!s.IsEmpty) {
                Console.WriteLine(s.Pop());
            }

            Console.Write("Pulsar ENTER"); Console.ReadLine();
        }
    }
}
