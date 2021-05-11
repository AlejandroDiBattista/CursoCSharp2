using System;
using System.Collections.Generic;

namespace Demo18{

    interface IComponente {
        void Ejecutar();
    }

    class Componente : IComponente{
        public void Ejecutar(){
            Console.WriteLine("Componente.Ejecutar");
        }
    }

    class Decorar : IComponente {
        IComponente Componente;
        public Decorar(IComponente componente) => Componente = componente;
        
        public void Ejecutar(){
            Componente.Ejecutar();
            Console.WriteLine("Despues con Decorar.Ejecutar");
        }
    }

    delegate bool CondicionDelegate();
    interface ICondicion {
        bool Valido();
    }

    class Condicion : ICondicion{
        bool ICondicion.Valido() => true;
    }
    class Condicional : IComponente {
        IComponente Componente;
        ICondicion Condicion;
        public Condicional(IComponente componente, ICondicion condicion){
            Componente = componente;
            Condicion = condicion;
        } 

        public void Ejecutar(){
            if( Condicion.Valido() )
                Componente.Ejecutar();
        }
    }

    class Bifurcar: IComponente {
        IComponente Si;
        IComponente No;
        ICondicion Condicion;
        public Bifurcar(IComponente si, IComponente no, ICondicion condicion){
            Si = si;
            No = no;
            Condicion = condicion;
        }

        public void Ejecutar(){
            if(Condicion.Valido() ){
                Si.Ejecutar();
            } else {
                No.Ejecutar();
            }
        }
    }

    class Componer : IComponente {
        List<IComponente> Componentes = new();
        public Componer(){}
        public void Agregar(IComponente componente) => Componentes.Add(componente);

        public void Ejecutar(){
            foreach(IComponente c in Componentes){
                c.Ejecutar();
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            Componente  a = new();
            Decorar     b = new(a);
            Condicional c = new (a, new Condicion());
            Bifurcar    d = new(a,b, new Condicion());
            
            Componer    e = new();
            e.Agregar(b);
            e.Agregar(c);
            e.Agregar(d);

            e.Ejecutar();
        }
    }
}
