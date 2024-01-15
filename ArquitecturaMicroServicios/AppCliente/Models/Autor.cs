

namespace AppCliente.Models
{
    public class Autor
    {
        public int Idautor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        private string? nombreCompleto;
        public string? NombreCompleto
        {
            get
            {
                return nombreCompleto = Nombre + " " + Apellido;
            }

        }
    }
}
