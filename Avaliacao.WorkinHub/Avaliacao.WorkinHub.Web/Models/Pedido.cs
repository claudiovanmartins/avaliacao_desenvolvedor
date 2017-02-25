using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avaliacao.WorkinHub.Web.Models
{
    [Table("Pedido", Schema = "dbo")]
    public class Pedido
    {
        [Column("PedidoID")]
        public int PedidoID { get; set; }

        [Column("Cliente")]
        [Required(ErrorMessage = "Nome não pode ser em branco")]
        [MaxLength(255)]
        public string Cliente { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Descricao não pode ser em branco")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [Column("PrecoUnitario")]
        public decimal PrecoUnitario { get; set; }

        [Column("Quantidade")]
        public int Quantidade { get; set; }

        [Column("Endereco")]
        [MaxLength(255)]
        public string Endereco { get; set; }

        [Column("Fornecedor")]
        [MaxLength(255)]
        public string Fornecedor { get; set; }
    }
}