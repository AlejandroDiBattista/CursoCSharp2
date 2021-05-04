using System;

namespace Demo12{

    delegate void Mostrar(int monto);


    static class Extension {
        static public void Print(this string s){
            Console.WriteLine(s);
        }
    }
    
    class Program {
        static void MostrarDoble(int valor){
            Console.WriteLine($"El doble de {valor} es {2*valor}");
        }

        static Mostrar Repetir(Mostrar m, int veces){
            return delegate(int v) {
                for(int i=0;i<veces;i++){
                    m(v);
                }
            };
        }


        static void Main() {
            Mostrar m = Program.MostrarDoble;
            Mostrar n = Repetir(m, 3);
            Mostrar ñ = x => n(x+1);

            m(50);
            n(100);
            ñ(1000);
            "HOla Mundo".Print();
        }
    }
}
