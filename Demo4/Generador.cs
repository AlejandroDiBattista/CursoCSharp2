namespace Demo4 {
    public class Generador {
        public static void Cuenta(Persona usuario) {
            var cuenta =  usuario.Nombre.Substring(0,1) + usuario.Apellido;
            Mensajes.MostrarUsuario( cuenta );
        }
    }
}