using System;

namespace Demo12{
    delegate void Mostrar(int monto);

    class DemostracionDelegados {

        static void MostrarDoble(int valor){
            Console.WriteLine($"El doble de {valor} es {2*valor}");
        }

        static Mostrar Repetir(Mostrar mostrador, int veces){
            return delegate(int v) {
                Console.WriteLine($"Repetir {veces} veces");
                for(int i=0; i < veces; i++){
                    mostrador(v);
                }
            };
        }

        static void Main() {
            Mostrar a = MostrarDoble;
            Mostrar b = Repetir(a, 3);
            Mostrar c = (x) => b(x + 1);

            MostrarDoble(1);
            a(10);
            b(100);
            c(1000);
        }

    }
}
