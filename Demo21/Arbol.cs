using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo22 {
    
    static class Extensiones {
        public static void ForEach<T>(this IEnumerable<T> e, Action<T> accion){
            foreach(var a in e)
                accion(a);
        }
    }

    record Contacto(string Nombre, int Telefono);

    class Agenda: IEnumerable<Contacto> {
        Contacto Dato;
        Agenda Menor, Mayor;

        public void Agregar(Contacto c){
            var a = this;
            while(a.Dato != null){
                if(c.Nombre.CompareTo(a.Dato.Nombre) < 0){
                    a.Menor ??= new();
                    a = a.Menor;
                } else {
                    a.Mayor ??= new();
                    a = a.Mayor;
                }
            }
            a.Dato = c;
        }

        public void AgregarR(Contacto c){
            if(Dato == null) {
                Dato = c;
            } else if(c.Nombre.CompareTo(Dato.Nombre) < 0){
                Menor ??= new();
                Menor.AgregarR(c);
            } else {
                Mayor ??= new();
                Mayor.AgregarR(c);
            }
        }

        public IEnumerator<Contacto> GetEnumerator() {
            var q = new Stack<Agenda>();
            var a = this;
            while(q.Count > 0 || a != null) {
                if(a != null) {
                    q.Push(a);
                    a = a.Menor;
                } else {
                    a = q.Pop();
                    if(a.Dato != null) yield return a.Dato;
                    a = a.Mayor;
                }
            } 
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class Program {
        static void Main2(string[] args) {
            var a = new Agenda();
            a.Agregar( new("Marcelo",  1001) );
            a.Agregar( new("Alejadro", 1002) );
            a.Agregar( new("Carlos",   1003) );
            a.Agregar( new("Enrique",  1004) );
            a.Agregar( new("Juan",     1005) );

            Console.WriteLine($"{a.Count()}");

            a.Where(c => c.Telefono > 1002)
                // .OrderByDescending(c => c.Telefono)
                .ForEach( c => Console.WriteLine($"{c.Nombre,-20} {c.Telefono}") );
        }
    }
}
