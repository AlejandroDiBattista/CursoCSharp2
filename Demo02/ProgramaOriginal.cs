using System;
using static System.Console;
namespace Demo2 {
    class ProgramaOriginal {

        public class Persona {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
        }

        static void MainOriginal(string[] args) {
            WriteLine("Bienvenido");
            var usuario = new Persona();

            Write("Ingresar Nombre  :"); 
            usuario.Nombre = ReadLine();

            Write("Ingresar Apellido:"); 
            usuario.Apellido = ReadLine();

            if(string.IsNullOrEmpty(usuario.Nombre)){
                WriteLine("Debe Ingresar un Nombre valido");
                return;
            }

            if(string.IsNullOrEmpty(usuario.Apellido)){
                WriteLine("Debe Ingresar un Apellido valido");
                return;
            }

            WriteLine($"Su usuario es {usuario.Nombre.Substring(0,1) + usuario.Apellido}");
            ReadLine();
        }
    }
}