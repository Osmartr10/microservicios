namespace AppCliente.Models
{
    public class Prestamo
    {
        public string? Idprestamo { get; set; }      
        public int Idestudiante { get; set; }       
        public DateTime FechaPrestamo { get; set; }  = DateTime.Now;
        public DateTime FechaDevolucion { get; set; } = DateTime.Now;      
        public string Estado { get; set; } = "No Entregado";       
        public List<Detalle>? PrestamoDetalle { get; set; }
    }
}
