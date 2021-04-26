using System;
namespace Demo2
{
    public class Mensajes
    {
        public static void Bienvienda()
        {
            Console.ForegroundColor = ConsoleColor.Gray ;
            Console.WriteLine("Bienvenido\n");
        }

        public static void Finalizar(){
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"\nPulse INTRO para terminar...");
            Console.ReadLine();
        }

        public static void MostrarMensajeError(string campo){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Debe Ingresar un {campo} válido");
        }

        public static void UsuarioGenerado(string cuenta){
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nSu usuario es '{cuenta}'");
        }

        public static void IngresarCampo(string campo){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Ingresar {campo,-10} :");
        }
    }
}