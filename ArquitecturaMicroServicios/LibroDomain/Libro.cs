using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibroDomain
{
    [Table("LIBRO")]
    public class Libro
    {
        [Key]
        [Column("IDLIBRO")]
        public int Idlibro { get; set; }

        [Column("TITULO")]
        [StringLength(50)]
        public string Titulo { get; set; } = null!;

        [Column("ANIO")]        
        public int Anio { get; set; }

        [Column("EDITORIAL")]
        [StringLength(50)]
        public string Editorial { get; set; } = null!;

        [InverseProperty("IdlibroNavigation")]
        public virtual ICollection<AutorLibro> Libroautores { get; set; } = new List<AutorLibro>();
    }
}
