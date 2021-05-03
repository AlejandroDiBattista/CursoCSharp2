using System;
namespace Demo4{
    public class Mensajes    {
        public static void  Bienvienda(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("\nBienvenido\n");
        }

        public static void  Despedida(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPulsar ENTER para terminar...");
            Console.ReadLine();
        }

        public static void MostrarMensajeError(string campo){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Debe ingresar un {campo} válido");            
        }

        public static void IngresarCampo(string campo){
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Ingresar {campo,-12}:> ");   
        }

        public static void MostrarUsuario(string usuario){
            Console.WriteLine($"\nSu usuario es '{usuario}'");
        }
    }
}