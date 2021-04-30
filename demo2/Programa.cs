using static System.Console;

namespace Demo2
{
    class Programa
    {
        static void Main(string[] args)
        {
            Mensajes.Bienvienda();
            var usuario = PesonaCapturador.Capturar();

            var esValido = PersonaValidador.Validar(usuario);
            if (!esValido)
            {
                Mensajes.Finalizar();
                return;
            }

            CuentaGenerador.Generar(usuario);
            Mensajes.Finalizar();
        }
    }
}
