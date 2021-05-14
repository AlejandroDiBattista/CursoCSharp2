using System;
using System.Collections.Generic;

namespace Demo20.Interface {    
    public record Contacto(string Nombre, int Telefono);

    public class Agenda {
        List<Contacto> contactos = new();

        public void Agregar(Contacto contacto) => contactos.Add(contacto);

        public void Listar(IMostrador m){
            Console.WriteLine($"> Contactos");
            foreach(var c in contactos) 
                m.Mostrar(c);
            Console.WriteLine();
        }
    }

    // Delegar usando Interface
    public interface IMostrador{
        void Mostrar(Contacto c);
    }

    public class MostrarNormal: IMostrador {
        public void Mostrar(Contacto c) => Console.WriteLine($"  - {c.Nombre,-20} >> {c.Telefono} ");
    }

    public class MostrarInvertido: IMostrador {
        public void Mostrar(Contacto c) => Console.WriteLine($"  - {c.Telefono,-20} << {c.Nombre,-20}");
    }
    
    // Decoradores 
    public class Doble : IMostrador{
        public Doble(IMostrador mostrador) => Mostrador = mostrador;
        
        public void Mostrar(Contacto c) {
            Mostrador.Mostrar(c);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Mostrador.Mostrar(c);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private IMostrador Mostrador;
    }

    public class ExcluirFijo : IMostrador{
        public ExcluirFijo(IMostrador mostrador, string nombre) => (Mostrador, Nombre) = (mostrador, nombre);
        
        public void Mostrar(Contacto c) {
            if(c.Nombre != Nombre) Mostrador.Mostrar(c);
        }
        private IMostrador Mostrador;
        private string Nombre;
    }

    public class ExcluirDinamico : IMostrador{
        public ExcluirDinamico(Predicate<Contacto> excluir, IMostrador mostrador) => (Mostrador, Excluir) = (mostrador, excluir);
        
        public void Mostrar(Contacto c) {
            if(! Excluir(c)) Mostrador.Mostrar(c);
        }
        private IMostrador Mostrador;
        private Predicate<Contacto> Excluir;
    }

    public class Componer : IMostrador{
        public void Agregar(IMostrador m) => Miembros.Add(m);
        public void Mostrar(Contacto c) {
            foreach(var m in Miembros) 
                m.Mostrar(c);
        }
        private List<IMostrador> Miembros = new();
    }

    public class Decidir : IMostrador{
        public Decidir(Predicate<Contacto> condicion, IMostrador si, IMostrador no) => (Condicion, Si, No) = (condicion, si, no);
        
        public void Mostrar(Contacto c) {
            if(! Condicion(c)) 
                Si.Mostrar(c);
            else 
                No.Mostrar(c);
        }

        private Predicate<Contacto> Condicion;
        private IMostrador Si;
        private IMostrador No;
    }

    public class Programa {
        public static void Probar() {
            Console.Clear();

            IMostrador a = new MostrarNormal();
            a = new ExcluirDinamico(c => c.Telefono > 456_7892, a);
            a = new Doble(a); // probar eliminar

            IMostrador b = new MostrarInvertido();
            b = new ExcluirFijo(b, "Alejandro");
            
            IMostrador d = new Decidir(c => c.Telefono > 456_7892, a, b);
            
            Componer c = new Componer();
            c.Agregar(a);
            c.Agregar(b);

            var agenda = new Agenda();
            agenda.Agregar( new("Alejandro", 456_7890) );
            agenda.Agregar( new("Alvaro",    456_7891) );
            agenda.Agregar( new("Franco",    456_7892) );
            agenda.Agregar( new("Hugo",      456_7893) );
            agenda.Agregar( new("Nahuel",    456_7894) );
            
            Console.Clear();
            Console.WriteLine("Demo Open/Close (Usando Interface con Decorador)");

            Console.WriteLine("\nEjemplo 1");
            agenda.Listar(d);

            Console.WriteLine("\nEjemplo 2");
            agenda.Listar(c);
        }
    }
}
