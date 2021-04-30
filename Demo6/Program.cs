using System;
using static System.Console;

namespace Demo6 {
    class Contacto {
        private static int proximoID = 1; 
        
        private int id;
        public string Nombre { get; init; }
        public string Apellido { get; init; }

        public Contacto(string nombre, string apellido) {
            this.id = proximoID++;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
    }

    class Program {
        static void Main(string[] args) {
            var ale = new Contacto(apellido: "Di Battista", nombre: "Alejandro");

            WriteLine($"{ale.Nombre} {ale.Apellido}");
            Write("Pulsa ENTER"); ReadLine();
        }
    }
}
