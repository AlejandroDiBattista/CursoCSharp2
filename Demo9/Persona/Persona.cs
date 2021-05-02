using System;
namespace Demo9 {

    public class Persona: IUsuario {
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string NombreCompleto => $"{Apellido}, {Nombre}";
    
        public Persona(){}
        
        public Persona(string nombre, string apellido){
            Nombre = nombre;
            Apellido = apellido;
        }

        public override string ToString() => NombreCompleto;
    }
}