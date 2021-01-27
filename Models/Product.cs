using System.ComponentModel.DataAnnotations;

namespace testeA.Models {

    public class Product {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 carateres")]

        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Esse campo deve conter no maximo 1000 caracteres")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "o preço deve ser maior que 0")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]

        public int CategoryId { get; set; } 

        public Category Category { get; set; }
    }
}