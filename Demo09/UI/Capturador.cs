using System;
namespace Demo9{
    public class Capturador{
        public static Persona Capturar(){
            var usuario = new Persona();
            Mensajes.IngresarCampo("NOMBRE");
            usuario.Nombre = Console.ReadLine();
            
            Mensajes.IngresarCampo("APELLIDO");
            usuario.Apellido = Console.ReadLine();
            return usuario;
        }
    }
}