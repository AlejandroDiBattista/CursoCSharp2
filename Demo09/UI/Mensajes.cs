using System;

namespace Demo9 {
    public class Mensajes {
        public static void Bienvenido(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bienvenido ");
        }

        public static void Despedida(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pulse Enter");
            Console.ReadLine();
        }
        public static void IngresarCampo(string campo){
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Ingrese un {campo, -10} :>");
        }

        public static void ErrorEnCampo(string campo){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Debe ingresar un {campo} valido");
        }

        public static void MostrarCuenta(Persona usuario){
            Console.WriteLine($"El usuario es {usuario.Nombre.Substring(0,1)+usuario.Apellido}");
        }
    }
}
