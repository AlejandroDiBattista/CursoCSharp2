using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo19{

    public record Contacto(string Nombre, int Telefono);

    public class Agenda: IEnumerable<Contacto>
    {
        List<Contacto> contactos = new();
        public void Agregar(Contacto contacto) => contactos.Add(contacto);

        public void Listar(Action<Contacto> Mostrar){
            foreach(var c in contactos) 
                Mostrar(c);
        }
        
        public IEnumerator<Contacto> GetEnumerator(){
            foreach(var c in contactos)
                yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public static class Extensiones {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action) {
             foreach(T item in enumeration) 
                action(item);
        }
    }

    class Program {      

        static void Main(){
            Console.Clear();
            var a = new Agenda();
            a.Agregar( new("Alejandro", 456_7890) );
            a.Agregar( new("Franco",    456_7894) );
            a.Agregar( new("Alvaro",    456_7895) );
            a.Agregar( new("Hugo",      456_7893) );
            a.Agregar( new("Nahuel",    456_7892) );

            Console.WriteLine("\nRecorrido normal");
            foreach(var c in a) 
                Console.WriteLine($"- {c.Nombre,-20} {c.Telefono}") ;
            
            Console.WriteLine("\nRecorrido Ordenado (Nombre)");
            foreach(var c in a.OrderBy(c => c.Nombre))
                Console.WriteLine($"- {c.Nombre,-20} {c.Telefono}") ;

            a.OrderBy(c => c.Nombre).ForEach( c=> Console.WriteLine($"- {c.Nombre,-20} {c.Telefono}") );

            Console.WriteLine("\nRecorrido Ordenado (Telefono)");
            foreach(var c in a.OrderBy(c => c.Telefono))
                Console.WriteLine($"- {c.Nombre,-20} {c.Telefono}") ;

            Console.WriteLine($"Hay {a.Count()} contactos");
        }
    }
}