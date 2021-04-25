using System.IO;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Demo01 {

    class Program {

        public class Contacto {
            public string Nombre {get; set; }
            public string Apellido;
            public string Telefono;
    
            public string NombreCompleto => $"{Apellido}, {Nombre}" ;
        }

        public class Agenda {
            private List<Contacto> contactos;

            public Agenda() {
                contactos = new List<Contacto>();
            }

            public void Leer() {
                var lineas = File.ReadAllLines(@"agenda.txt");
                contactos = new List<Contacto>();
                foreach(var linea in lineas) { 
                    var datos = linea.Split(",");
                    var contacto = new Contacto{ Nombre = datos[0], Apellido = datos[1], Telefono = datos[2]};
                    Agregar( contacto  );
                }
            }

            public void Escribir() {
                var lineas = contactos.Select( c => $"{c.Nombre},{c.Apellido},{c.Telefono}");
                WriteLine($"Escribiendo Agenda... {lineas.Count()}" );
                File.WriteAllLines(@"agenda.txt", lineas);
            }
            
            public void Listar() {
                var i = 1;
                WriteLine($"      {"NOMBRE",-40}  {"TELÉFONO"}");
                foreach(var contacto in contactos) {
                    WriteLine($" {i++,3}. {contacto.NombreCompleto,-40}  {contacto.Telefono}");
                }
            }

            public void Agregar(Contacto contacto) {
                if(contacto == null) return;
                contactos.Add(contacto);
            }

            public void Editar(Contacto contacto, int posicion) {
                if(contacto == null) return;
                contactos[posicion - 1] = contacto;
            }
            
            public void Borrar(int posicion) {
                contactos.RemoveAt( posicion - 1 );
            }
        }

        static Contacto IngresarContacto() {
            var  actual = new Contacto();
            Write("   Nombre   :> "); actual.Nombre   = ReadLine();
            Write("   Apellido :> "); actual.Apellido = ReadLine();
            Write("   Teléfono :> "); actual.Telefono = ReadLine();
            
            if(actual.Nombre.Length < 2) {
                Write("Debe ingresar un Nombre válido");
                ReadLine();
                return null;
            }
            
            if(actual.Apellido.Length < 2) {
                Write("Debe ingresar un Apellido válido");
                ReadLine();
                return null;
            }
            
            if(actual.Telefono.Length < 7) {
                Write("Debe ingresar un Telefono válido");
                ReadLine();
                return null;
            }

            return actual;
        }

        static int ElegirContacto() {
            WriteLine(" > Elegir contacto");
            agenda.Listar();
            WriteLine();
            WriteLine(" 0. Cancelar");
            Write(" :> ");
            var opcion = int.Parse(ReadLine());
            return opcion;
        }

        static void AgregarContacto() {
            WriteLine(" Agregando Contacto...");
            agenda.Agregar( IngresarContacto() );
        }

        static void EditarContacto() {
            WriteLine(" Editando Contacto...");
            var i = ElegirContacto();
            if(i == 0) return;
            agenda.Editar( IngresarContacto(), i);
        }

        static void BorrarContacto() {
            WriteLine(" Borrando Contacto...");
            var i = ElegirContacto();
            if(i == 0) return;
            agenda.Borrar(i);
        }

        static void ListarContactos() {
            WriteLine(" Listado de Contactos...");
            agenda.Listar();
            Write(" :> "); ReadLine();
            WriteLine();
        }

        static Agenda agenda;

        static void Menu() {
            while(true) {
                Clear();
                WriteLine();
                WriteLine(" >  MI AGENDA");
                WriteLine(" 1. Agregar Contacto");
                WriteLine(" 2. Editar Contacto");
                WriteLine(" 3. Borrar Contacto");
                WriteLine(" 4. Listar Contactos");
                WriteLine();
                WriteLine(" 0. Terminar");
                Write(" :> ");
                var opcion = ReadLine();
                WriteLine();
                switch(opcion) {
                    case "1": 
                        AgregarContacto();
                        break;
                    case "2":
                        EditarContacto();
                        break;
                    case "3":
                        BorrarContacto();
                        break;
                    case "4":
                        ListarContactos();
                        break;
                    case "0":
                    case "" :
                        return;
                }
            }
        }

        static void Main(string[] args) {
            agenda = new Agenda();
            agenda.Leer();
            Menu();
            agenda.Escribir();
        }
    }
}
