using System;

namespace Demo4 {
    class Program {
        static void Main(string[] args) {
            Mensajes.Bienvienda();

            var persona  = Capturador.Capturar();
            var isValido = Validador.Validar(persona);
            if(isValido) Generador.Cuenta(persona);
            
            Mensajes.Despedida();
        }
    }
}
