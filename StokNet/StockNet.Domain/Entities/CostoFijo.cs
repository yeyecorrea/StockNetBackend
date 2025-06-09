using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class CostoFijo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
    }
}
