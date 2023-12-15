using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace CadastroDeProdutos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public double preço { get; set; }
        [Required]
        public int quantidade { get; set; }

        public string imageFile {  get; set; }
        
        public string imageFileName { get; set; }

        [NotMapped]
        public IFormFile Upload {  get; set; }

        public DateTime dataInsercao { get; set; }
    }
}
