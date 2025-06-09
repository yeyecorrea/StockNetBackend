using System.ComponentModel.DataAnnotations;

namespace StockNet.Domain.Entities
{
    public class CategoriaMateriaPrima
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        // Relación con Materias Primas
        public ICollection<MateriaPrima> MateriasPrimas { get; set; }

    }
}
