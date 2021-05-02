namespace Demo9
{
    public class Generador
    {
        public static string Cuenta(IUsuario usuario){
            return usuario.Nombre.Substring(0,1)+usuario.Apellido;
        }
    }
}
