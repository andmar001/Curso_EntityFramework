using System.ComponentModel.DataAnnotations;

namespace project_ef.Models
{
    public class Categoria
    {
        // [Key]
        public Guid CategoriaId { get; set; }
        // [Required]
        // [MaxLength(150)]//only 150 characters
        public string Nombre { get; set; } 
        public string Decripcion { get; set; }
        public int Peso { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}