using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace GitHub
{
    class Program
    {
        public class Contacto {
            public string Nombre;
            public string Apellido;
            public string Telefono;
            public string NombreCompleto => $"{Apellido}, {Nombre}" ;
        }

        public class Agenda{
            private List<Contacto> contactos;

            public Agenda(){
                contactos = new List<Contacto>();
            }

            public void Leer(){
                var lineas = File.ReadAllLines(@"agenda.txt");
                contactos = new List<Contacto>();
                foreach(var linea in lineas) { 
                    var datos = linea.Split(",");
                    Agregar( new Contacto{ Nombre = datos[0], Apellido = datos[1], Telefono = datos[2] } );
                }
            }

            public void Escribir(){
                var lineas = contactos.Select( c => $"{c.Nombre},{c.Apellido},{c.Telefono}");
                Console.WriteLine("Escribindo Agenda... {0}",lineas.Count() );
                File.WriteAllLines(@"agenda.txt", lineas);
            }
            
            public void Listar(){
                var i = 1;
                foreach(var contacto in contactos){
                    Console.WriteLine($" {i}. {contacto.NombreCompleto,-30}  {contacto.Telefono}");
                    i++;
                }
            }

            public void Agregar(Contacto contacto){
                contactos.Add(contacto);
            }

            public void Editar(Contacto contacto, int posicion){
                contactos[posicion - 1] = contacto;
            }
            
            public void Borrar(int posicion){
                contactos.Remove( contactos[posicion - 1] );
            }
        }

        static Contacto IngresarContacto(){
            var  actual = new Contacto();
            Console.Write("   Nombre   >> "); actual.Nombre   = Console.ReadLine();
            Console.Write("   Apellido >> "); actual.Apellido = Console.ReadLine();
            Console.Write("   Teléfono >> "); actual.Telefono = Console.ReadLine();
            return actual;
        }

        static int ElegirContacto(){
            Console.WriteLine(" > Elegir contacto");
            agenda.Listar();
            Console.WriteLine();
            Console.WriteLine(" 0. Cancelar");
            while(true){
                Console.Write(" >> ");
                var opcion = int.Parse(Console.ReadLine());
                if(opcion >= 0 & opcion <= 3) {
                    return opcion;
                }
            }
        }

        static void AgregarContacto(){
            Console.WriteLine(" Agregando Contacto...");
            agenda.Agregar( IngresarContacto() );
        }

        static void EditarContacto(){
            Console.WriteLine(" Editando Contacto...");
            var i = ElegirContacto();
            if(i == 0) return;
            agenda.Editar( IngresarContacto(), i);
        }

        static void BorrarContacto(){
            Console.WriteLine(" Borrando Contacto...");
            var i = ElegirContacto();
            if(i == 0) return;
            agenda.Borrar(i);
        }

        static void ListarContactos(){
            Console.WriteLine(" Listado de Contactos...");
            agenda.Listar();
            Console.Write(" >> "); Console.ReadLine();
        }

        static Agenda agenda;

        static void Menu(){
            while(true) {
                Console.WriteLine();
                Console.WriteLine(" > Mi Agenda");
                Console.WriteLine(" 1. Agregar Contacto");
                Console.WriteLine(" 2. Editar Contacto");
                Console.WriteLine(" 3. Borrar Contacto");
                Console.WriteLine(" 4. Listar Contactos");
                Console.WriteLine();
                Console.WriteLine(" 0. Terminar");
                Console.Write(" >> ");
                var opcion = int.Parse(Console.ReadLine());
                switch(opcion){
                    case 1: 
                        AgregarContacto();
                        break;
                    case 2:
                        EditarContacto();
                        break;
                    case 3:
                        BorrarContacto();
                        break;
                    case 4:
                        ListarContactos();
                        break;
                    case 0 :
                        return;
                        break;
                }
            } 
        }

        static void Main(string[] args){
            agenda = new Agenda();
            agenda.Leer();
            Menu();
            agenda.Escribir();
        }
    }
}
