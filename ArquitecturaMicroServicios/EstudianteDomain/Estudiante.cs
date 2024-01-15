using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudianteDomain
{
    [Table("ESTUDIANTE")]
    public class Estudiante
    {
        [Key]
        [Column("IDESTUDIANTE")]
        public int Idestudiante { get; set; }

        [Column("CI")]
        public int ci { get; set; }

        [Column("NOMBRE")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Column("APELLIDO")]
        [StringLength(50)]
        public string Apellido { get; set; } = null!;

    }
}
