namespace Demo9
{
    public class Empleado: IUsuario
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public string Cargo{ get; init;}

        private Empleado(){}

        public Empleado(string nombre, string apellido, string cargo) {
            Nombre = nombre;
            Apellido = apellido;
            Cargo = cargo;
        }
    }
}