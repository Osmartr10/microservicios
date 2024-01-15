using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCliente.Models
{
    public class Libro
    {
        public int Idlibro { get; set; }      
        public string Titulo { get; set; } = null!;       
        public int Anio { get; set; }      
        public string Editorial { get; set; } = null!;
        public virtual ICollection<AutorLibro> Libroautores { get; set; } = new List<AutorLibro>();
        public string[]? IdAutor { get; set; }
    }
}
