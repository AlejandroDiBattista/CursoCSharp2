using System;
namespace Demo9{
    public class Validador
    {
        public static bool EsValido(Persona usuario){
            if(string.IsNullOrEmpty(usuario.Nombre)){
                Mensajes.ErrorEnCampo("NOMBRE");
                return false ;
            }

            if(string.IsNullOrEmpty(usuario.Apellido)){
                Mensajes.ErrorEnCampo("APELLIDO");
                return false;
            }
            return true;
        }
    }
}