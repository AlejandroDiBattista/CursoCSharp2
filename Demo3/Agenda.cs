using System;
namespace Demo3 {
    public class Agenda{
        private Persona[] personas = new Persona[100];
        private int cantidad = 0;

        public void Agregar(Persona contacto){
            for(var i = 0; i < cantidad; i++){
                if(personas[i].ID == contacto.ID){
                    personas[i] = contacto;
                    return;
                }
            }
            personas[cantidad++] = contacto;
        }

        public void Cambiar(Persona contacto){
            for(var i = 0; i < cantidad; i++){
                if(personas[i].ID == contacto.ID){
                    personas[i] = contacto;
                    return;
                }
            }
        }

        public void Borrar(Persona contacto){
            for(var i = 0; i < cantidad; i++){
                if(personas[i].ID == contacto.ID){
                    personas[i] = null;
                    return;
                }
            }
            Compactar();
        }

        public Persona Buscar(string texto){
            for(var i = 0; i < cantidad; i++){
                if(personas[i].Contiene(texto)){
                    return personas[i];
                }
            }
            return null; 
        }

        public void Mostrar(){
            Console.WriteLine($"Hay {cantidad} personas en la agenda");
            for(var i = 0; i < cantidad; i++){
                personas[i].Mostrar();
            }
        }
        private void Compactar(){
            var j = 0;
            for(var i = 0; i < cantidad; i++){
                if(personas[i] != null){
                    personas[j++] = personas[i];
                }
            }
            cantidad = j;
        }

    }
}

