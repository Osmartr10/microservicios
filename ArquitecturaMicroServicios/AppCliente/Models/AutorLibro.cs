

namespace AppCliente.Models
{
    public class AutorLibro
    {
        public int Idautorlibro { get; set; }       
        public int Idautor { get; set; }       
        public int Idlibro { get; set; }

        public string? NombreAutor;
        public virtual Autor? IdautorNavigation { get; set; }       
        public virtual Libro? IdlibroNavigation { get; set; }
    }
}
