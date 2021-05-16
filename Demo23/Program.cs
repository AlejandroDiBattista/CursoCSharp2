using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleInjector;

namespace Demo23 {

    interface IEntidad {
        Guid ID {get; set;}
        IEnumerable<(string Nombre, object Valor)> Campos {get;}
        string Tabla {get;}
    }

    class Entidad: IEntidad {        
        public Guid ID {get; set;}
        public Entidad(Guid id) => ID = id;

        // Retorna una lista con todos los valores de una entidad para realizar la persistencia
        IEnumerable<(string Nombre, object Valor)> IEntidad.Campos => 
            this.GetType().GetProperties().Where(p => p.Name != "ID").Select(c => (c.Name, c.GetValue(this))); 
        string IEntidad.Tabla => this.GetType().Name;
    }

    
    class Producto : Entidad {
        public string Descripcion {get; set;}
        public double Precio {get; set;}
     
        public Producto(): base(Guid.Empty){}
        public Producto(Guid id, string descripcion, double precio) : base(id) {
            Descripcion = descripcion;
            Precio = precio;
        }
    }

    class Persona : Entidad {
        public string Nombre {get; set;}
        public Persona(Guid id, string nombre) : base(id) => Nombre = nombre;        
    }

    interface IDatos {
        void Ejecutar(string SQL);
    }

    class SQLServer: IDatos {
        public void Ejecutar(string SQL) {
            Console.Write($"Ejecutando SQL Server: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SQL);
            Console.ForegroundColor = ConsoleColor.White;
        }
    } 

    class Mongo: IDatos {
        public void Ejecutar(string SQL) {
            Console.Write($"Ejecutando Mongo: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SQL);
            Console.ForegroundColor = ConsoleColor.White;
        }
    } 

    interface IReader<T> where T: IEntidad {
        T ReadOne(Guid ID);
        IEnumerable<T> ReadAll();
    }

    interface IWriter<T> where T: IEntidad {
        void Save(T p);
        void Delete(T p);
    }

    class Reader<T>: IReader<T> where T: IEntidad, new() {
        IDatos Datos;
        public Reader(IDatos datos) => Datos = datos;

        public T ReadOne(Guid ID) {
            var salida = new T();
            Datos.Ejecutar($"SELECT * FROM { salida.Tabla } WHERE ID = '{ID};");
            return default;
        }

        public IEnumerable<T> ReadAll() {
            var salida = new T();
            Datos.Ejecutar($"SELECT * FROM { salida.Tabla };");
            return new List<T>();
        }
    }

    class Writer<T>: IWriter<T> where T: IEntidad {
        IDatos Datos;
        public Writer(IDatos datos) => Datos = datos;

        public void Save(T p){
            var campos  = p.Campos.Select(c => c.Nombre);
            var valores = p.Campos.Select(c => (c.Valor is string) ? $"'{c.Valor}'" : $"{c.Valor}" );
            var pares   = string.Join(", ", campos.Zip(valores).Select(c  =>  $"{ c.Item1 } = { c.Item2 }"));

            if(p.ID == Guid.Empty){
                p.ID = Guid.NewGuid();
                Datos.Ejecutar($"INSERT INTO { p.Tabla } (ID, { string.Join(", ", campos) } ) VALUES ('{ p.ID.ToString() }', { string.Join(", ", valores) });");

            } else {
                Datos.Ejecutar($"UPDATE { p.Tabla } SET { pares } WHERE ID = '{ p.ID.ToString() }';");
            }
        } 

        public void Delete(T p) => Datos.Ejecutar($"DELETE { p.Tabla } ID = '{ p.ID }';");
    }
    interface IStore<T>: IReader<T>, IWriter<T> where T : IEntidad { }

    class Store<T>: IStore<T> where T: IEntidad {
        IReader<T> Reader;
        IWriter<T> Writer;

        public Store(IReader<T> reader, IWriter<T> writer) {
            Reader = reader;
            Writer = writer;
        }

        public T ReadOne(Guid ID) => Reader.ReadOne(ID);
        public IEnumerable<T> ReadAll() => Reader.ReadAll();
        public void Save(T p) => Writer.Save(p);
        public void Delete(T p) => Writer.Delete(p);
    }

    class Inventario : IEnumerable<Producto> {
        List<Producto> productos = new();
        IStore<Producto> Store;
        public Inventario(IStore<Producto> store) => Store = store;

        public void Add(Producto p) => productos.Add(p);
        public void Persistir() {
            foreach(var p in this) {
                Store.Save(p);
            }
        }

        public IEnumerator<Producto> GetEnumerator() => productos.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException(); 
    }

    class WriterLog<T>: IWriter<T> where T: IEntidad {
        IWriter<T> Writer;
        public WriterLog(IWriter<T> writer) => Writer = writer;

        public void Save(T p) {
            Console.WriteLine("Estoy logeando");
            Writer.Save(p);
        }
        public void Delete(T p) {
            Console.WriteLine("Estoy logeando");
            Writer.Delete(p);
        }
    }

     class WriterTest<T>: IWriter<T> where T: IEntidad {
        IWriter<T> Writer;
        public WriterTest(IWriter<T> writer) => Writer = writer;

        public void Save(T p) => Console.WriteLine("Estoy testeando");
        public void Delete(T p) => Console.WriteLine("Estoy testeando");
    }

    class DatosTest: IDatos {
        public void Ejecutar(string SQL){
            Console.Write($"Ejecutando Test: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(SQL);
            Console.ForegroundColor = ConsoleColor.White;
        } 
    } 


    // ** Inicialización tradicional **
    // var s = new DatosTest();
    // var r = new Reader<Producto>(s);
    // IWriter<Producto> w = new Writer<Producto>(s);
    // w = new WriteLog(w);
    // w = new WriterTest(w);

    // var store  = new Store<Producto>(r, w);


    class Program {
        static void Main(string[] args) {

            var contenedor = new SimpleInjector.Container();
            contenedor.Register<IDatos, DatosTest>(Lifestyle.Singleton);
            contenedor.Register<IStore<Producto>, Store<Producto>>();
            contenedor.Register<IReader<Producto>, Reader<Producto>>();
            contenedor.Register<IWriter<Producto>, Writer<Producto>>();
            // contenedor.RegisterDecorator<IWriter<Producto>, WriterTest<Producto>>();     // Comentar/Descomentar para probar el decorador
            // contenedor.RegisterDecorator<IWriter<Producto>, WriterLog<Producto>>();      // Comentar/Descomentar para probar el decorador
            contenedor.Verify();

            Console.Clear();
            Console.WriteLine("Ejemplos de Segregacion de interfaces (y Single Responsabiliti, Open/Close, Dependence Injection)");
            var inventario = contenedor.GetInstance<Inventario>();
            
            inventario.Add(new(Guid.Empty,     "Coca Cola", 100));
            inventario.Add(new(Guid.NewGuid(), "Pepsi Cola", 80));
            inventario.Add(new(Guid.Empty,     "Manao Cola", 40));
            
            inventario.Persistir();
        }
    }
}
