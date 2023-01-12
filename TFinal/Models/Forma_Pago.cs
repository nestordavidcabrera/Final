using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFinal.Models
{
    public class Forma_Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_forma_pago { get; set; }
        public string desc_forma_pago { get; set; }
    }
}
