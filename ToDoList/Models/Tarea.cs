namespace ToDoList.Models
{
    public class Tarea
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }  

        public string Descripcion { get; set; }

        public string TareaEstado { get; set; }

        public int IdUsuario { get; set; }

        public DateTime FechaLimite { get; set; }

        

    }

    public enum TareaEstado
    {
        Pendiente,
        EnProceso,
        Terminada
    }   
}
