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

            MostrarDoble(1);    //El doble de 1 es 2
            a(10);              //El doble de 10 es 20 
            b(100);             //Repetir 3 veces;;El doble de 100 es 200;;El doble de 100 es 200;;El doble de 100 es 200;;
            c(1000);            //Repetir 3 veces;;El doble de 1000 es 2000;;El doble de 1000 es 2000;;El doble de 1000 es 2000;;
        }

        //a(10)  equivale a MostrarDoble(10)
        //b(100) equivale a Repetir(MostrarDoble,3) 
    }
}
