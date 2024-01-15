using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroDomain
{
    [Table("AUTORLIBRO")]
    public class AutorLibro
    {
        [Key]
        [Column("IDAUTORLIBRO")]
        public int Idautorlibro { get; set; }

        [Column("IDAUTOR")]
        public int Idautor { get; set; }

        [Column("IDLIBRO")]
        public int Idlibro { get; set; }

        [ForeignKey("Idautor")]
        [InverseProperty("Libroautores")]
        public virtual Autor? IdautorNavigation { get; set; }

        [ForeignKey("Idlibro")]
        [InverseProperty("Libroautores")]
        public virtual Libro? IdlibroNavigation { get; set; }
    }
}
