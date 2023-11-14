using System.ComponentModel.DataAnnotations;

namespace Probamos.Models
{
    public class ToDoList
    {
        [Key]
        public int idTarea { get; set; }
        public string nombre { get; set; }
        public bool completa { get; set; }   
        public int IdCategoria { get; set; }
    }
}
