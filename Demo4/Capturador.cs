using System;

namespace Demo4 {
    public class Capturador    {
        public static Persona Capturar(){
            var usuario = new Persona();
            Mensajes.IngresarCampo("Nombre");   usuario.Nombre   = Console.ReadLine();
            Mensajes.IngresarCampo("Apellido"); usuario.Apellido = Console.ReadLine();
            return usuario;
        }
    }
}