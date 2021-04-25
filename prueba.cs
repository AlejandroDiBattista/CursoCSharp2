// using System;
// using static System.Console;

// namespace CursoCSharp {
//     static class Demo02 {

//         public interface IMostrable {
//             void Mostrar();
//         }

//         public class Contacto: IMostrable {
//             public string Nombre   { get; init; }
//             public string Apellido { get; init; }
//             public string Telefono { get; init; }

//             public Contacto(string nombre, string apellido, string telefono) {
//                 Nombre = nombre;
//                 Apellido = apellido;
//                 Telefono = telefono;
//             }

//             public void Mostrar() => WriteLine($"{Apellido}, {Nombre}");
//         }

//         public class Punto : IMostrable {
//             public int X;
//             public int Y;
//             public void Mostrar() => WriteLine($"{X}, {Y}");
//         }

//         static void Main(string[] args) {
//             var a = new Contacto("Alejandro", "Di Battista", "(381) 534-3458");
//             var b = new Contacto("Alejandro", "Di Battista", "(381) 534-3458");
//             var c = new Punto{X = 10, Y = 40};
//             var d = new Punto{X = 20, Y = 50};
//             var lista = new IMostrable[]{a, b, c, d};

//             foreach(var i in lista){
//                 i.Mostrar();
//             }
//             ReadLine();
//         }
//     }
// }

