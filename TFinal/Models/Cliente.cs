using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFinal.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cliente { get; set; }
        [StringLength(50)]
        public string nombre_cliente { get; set; }
        [StringLength(255)]
        public string dir_cliente { get; set; }
        [StringLength(50)]
        public string correo_cliente { get; set; }
        public int telefono_cliente { get; set; }  
    }
}
