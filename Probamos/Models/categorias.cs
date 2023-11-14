using System.ComponentModel.DataAnnotations;

namespace Probamos.Models
{
    public class categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
    }
}
