namespace Demo4 {
    public class Validador {
        public static bool Validar(Persona usuario) {

            if(string.IsNullOrEmpty(usuario.Nombre)) {
                Mensajes.MostrarMensajeError("Nombre");
                return false;
            }

            if(string.IsNullOrEmpty(usuario.Apellido)) {
                Mensajes.MostrarMensajeError("Apellido");
                return false;
            }
            
            return true;
         }
    }
}