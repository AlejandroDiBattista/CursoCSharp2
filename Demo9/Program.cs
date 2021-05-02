using System;

namespace Demo9 {

    class Program {
        static void Main(string[] args) {
            Mensajes.Bienvenido();

            var usuario = Capturador.Capturar();
            var valido = Validador.EsValido(usuario);
            if(!valido){
                Mensajes.Despedida();
                return;
            }
            Console.WriteLine($"Persona : {usuario, 50}");
            Mensajes.MostrarCuenta(usuario);
            
            Mensajes.Despedida();
        }
    }
}
