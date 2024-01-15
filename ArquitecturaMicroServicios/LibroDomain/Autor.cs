using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroDomain
{
    [Table("AUTOR")]
    public class Autor
    {
        [Key]
        [Column("IDAUTOR")]
        public int Idautor { get; set; }

        [Column("NOMBRE")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;

        [Column("APELLIDO")]
        [StringLength(50)]
        public string Apellido { get; set; } = null!;

        [InverseProperty("IdautorNavigation")]
        public virtual ICollection<AutorLibro> Libroautores { get; set; } = new List<AutorLibro>();
    }
}
