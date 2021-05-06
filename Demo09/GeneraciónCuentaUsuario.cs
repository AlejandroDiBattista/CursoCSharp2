using System;

namespace Demo9 {

    // Este ejemplo muestra como delegar las responsabilidades entre varios
    // clases de manera que cada una se enfoque en un solo aspecto del problemas.

    class Program {

        static void Main(string[] args) {
            Mensajes.Bienvenido();

            var usuario = Capturador.Capturar();
            var valido = Validador.EsValido(usuario);
            if(!valido){
                Mensajes.Despedida();
                return;
            }
            Mensajes.MostrarCuenta(usuario);
            
            Mensajes.Despedida();
        }
    }
}
