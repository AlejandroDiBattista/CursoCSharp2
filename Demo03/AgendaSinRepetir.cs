using System;
using System.Collections.Generic;

namespace Demo3 {

    // IMostrar.cs
    public interface IMostrar{
        void Mostrar();
    }

    // IBuscar.cs
    public interface IBuscar{
        bool Contiene(string texto);
    }

    // Persona.cs
    public class Persona: IBuscar, IMostrar {
        private static int ProximoID = 1;

        public int ID { get; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        public Persona(string nombre, string apellido, string telefono){
            this.ID = ProximoID++;

            this.Nombre   = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
        }

        public bool Contiene(string texto){
            return  this.Nombre.Contains(texto) || 
                    this.Apellido.Contains(texto) || 
                    this.Telefono.Contains(texto);
        }

        public void Mostrar(){
            Console.WriteLine($"{this.Apellido+", " + this.Nombre, -40} {this.Telefono}");
        }
    }

    // Agenda.cs
    public class Agenda {
        private List<Persona> personas = new List<Persona>();

        public void Agregar(Persona contacto) {
            if(! Existe(contacto)){
                personas.Add(contacto);
            }
        }

        public void Cambiar(Persona contacto) {
            Borrar(contacto);
            Agregar(contacto);
        }

        public void Borrar(Persona contacto) {
            if (personas.Exists(p => p.ID == contacto.ID)) {
                personas.RemoveAt(personas.FindIndex(p => p.ID == contacto.ID));
            }
        }

        private bool Existe(Persona contacto) {
            return personas.Exists(p => p.ID == contacto.ID);
        }

        public Persona Buscar(string texto) {
            return personas.Find(persona => persona.Contiene(texto));
        }

        public void Mostrar() {
            Console.WriteLine($"Hay {personas.Count} personas en la Agenda");
            personas.ForEach(persona => persona.Mostrar());
        }
    }

    class AgendaSinRepetir {
        static void Main(string[] args) {
            var a = new Agenda();
            a.Agregar( new Persona("Alejandro", "Di Battista", "534-3458"));
            a.Agregar( new Persona("Franco", "Di Battista", "534-3459"));

            a.Mostrar();
            var c = a.Buscar("Franco");
            a.Borrar(c);
            a.Mostrar();

            Console.ReadLine();
        }
    }
}
