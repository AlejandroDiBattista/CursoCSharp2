using System;
namespace Demo2{
    public class CuentaGenerador{
        public static void Generar(Persona usuario){
            var cuenta = usuario.Nombre.Substring(0, 1) + usuario.Apellido;
            Mensajes.UsuarioGenerado(cuenta);
        }
    }
}