using System;

namespace Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Agenda();
            a.Agregar( new Persona("Alejandro", "Di Battista", "534-3458"));
            a.Agregar( new Persona("Franco", "Di Battista", "534-3459"));

            a.Mostrar();
            var c = a.Buscar("Franco");
            a.Borrar(c);
            a.Mostrar();

            Console.ReadLine();
        }
    }
}
