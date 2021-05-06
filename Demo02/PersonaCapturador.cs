using System;
namespace Demo2
{
    public static class PesonaCapturador
    {

        public static Persona Capturar()
        {
            var usuario = new Persona();

            Mensajes.IngresarCampo("nombre");
            usuario.Nombre = Console.ReadLine();

            Mensajes.IngresarCampo("apellido");
            usuario.Apellido = Console.ReadLine();
            return usuario;
        }
    }
}