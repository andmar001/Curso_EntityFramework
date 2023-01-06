using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using project_ef.Utilidades;

namespace project_ef.Models
{
    public class Tarea
    {
        [Key]
        public Guid TareaId { get; set; }
        [ForeignKey("CategoriaId")] // Llave foranea
        public Guid CategoriaId { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        [MaxLength(200)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public  Prioridad PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual Categoria Categoria { get; set; }
        [NotMapped]// No se guarda en la base de datos
        public string Resumen { get; set; }// No se guarda en la base de datos
    }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}