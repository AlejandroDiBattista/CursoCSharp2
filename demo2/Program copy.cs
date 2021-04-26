// using static System.Console;

// namespace Demo2
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             WriteLine("Bienvenido");
            
//             var usuario = new Persona();

//             Write("Ingresar Nombre  :");
//             usuario.Nombre = ReadLine();

//             Write("Ingresar Apellido:");
//             usuario.Apellido = ReadLine();

//             if (string.IsNullOrEmpty(usuario.Nombre))
//             {
//                 WriteLine("Debe Ingresar un Nombre valido");
//                 ReadLine();
//                 return;
//             }

//             if (string.IsNullOrEmpty(usuario.Apellido))
//             {
//                 WriteLine("Debe Ingresar un Apellido valido");
//                 ReadLine();
//                 return;
//             }

//             WriteLine($"Su usuario es {usuario.Nombre.Substring(0, 1) + usuario.Apellido}");
//             ReadLine();
//         }
//     }
// }
