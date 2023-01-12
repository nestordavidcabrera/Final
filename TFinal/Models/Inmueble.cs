using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFinal.Models
{
    public class Inmueble
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_inmueble { get; set; }
        [ForeignKey("id_tipo_inmueble")]
        public int id_tipo_inmueble { get; set; }
        public string desc_inmueble { get; set; }
        public string ubic_inmueble { get; set; }
        public double costo_inmueble { get; set; }

    }
}
