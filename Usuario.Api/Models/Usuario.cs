using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.Models
{
    public class Usuario
    {
        public int Id { get;  set; } //Se eu colocar private no set, ele não deixa nem eu modificar a primeira vez
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]  // [Range(1, 11)]
        public string Cpf { get;  set; } // ou seja vai está vazio e eu não posso botar valor algum

        public string  Email { get; set; }

        [Required]
        [StringLength(5)]
        public string senha { get; set; }

    }
}
