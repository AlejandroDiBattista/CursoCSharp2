using System;
namespace Demo2{
    public class PersonaValidador{
        public static bool Validar(Persona usuario){
             if (string.IsNullOrEmpty(usuario.Nombre))
            {
                Mensajes.MostrarMensajeError("nombre");
                return false;
            }

            if (string.IsNullOrEmpty(usuario.Apellido))
            {
                Mensajes.MostrarMensajeError("apellido");
                return false;
            }
            return true;
        }
    }
}