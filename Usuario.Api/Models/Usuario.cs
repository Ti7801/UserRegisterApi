namespace UsuarioApi.Models
{
    public class Usuario
    {
        public int Id { get;  set; } //Se eu colocar private no set, ele não deixa nem eu modificar a primeira vez
        public string Nome { get; set; }
        public string Cpf { get;  set; } // ou seja vai está vazio e eu não posso botar valor algum
        public string  Email { get; set; }
        public string senha { get; set; }


    }
}
