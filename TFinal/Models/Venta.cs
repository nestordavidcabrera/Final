using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFinal.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_venta { get; set; }
        [ForeignKey("id_inmueble")]
        public int id_inmueble { get; set; }
        [ForeignKey("id_cliente")]
        public int id_cliente { get; set; }
        [ForeignKey("id_condicion")]
        public int id_condicion { get; set; }
        [ForeignKey("id_forma_pago")]
        public int id_forma_pago { get; set; }
        [StringLength(255)]
        public string desc_venta { get; set; }
        public int total_venta { get; set; }
        public int total_iva { get; set; }
        public int total_general { get; set; }
        public DateTime fecha_venta { get; set; }
    }
}
