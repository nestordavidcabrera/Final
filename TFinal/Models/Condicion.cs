using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFinal.Models
{
    public class Condicion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_condicion { get; set; }
        [StringLength(100)]
        public string des_condicion { get; set; }

    }
}
