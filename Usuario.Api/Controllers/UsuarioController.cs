using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Models;

namespace UsuarioApi.Controllers
{
    [ApiController] // devido a esse atributo no parametro da Action eu posso passar um tipo complexo
    [Route("[controller]")] //
    public class UsuarioController : ControllerBase 
    {
        private readonly List<Usuario> usuarios; // O readonly vai obrigar  a não poder alterar o usuario?

        public UsuarioController() 
        {
            usuarios = new List<Usuario>();
        }  

        [HttpPost]  //O FromBody não é obrigatório a partir do C# 3.1 para parametros complexos na Action!
        public ActionResult<Usuario> CriarUsuario([FromQuery] Usuario value) // Trocar pra [FromBody] depois
        {
            Usuario usuario = new Usuario();

            usuario.Id = value.Id;
            usuario.Nome = value.Nome;
            usuario.Cpf = value.Cpf;
            usuario.Email = value.Email;
            usuario.senha = value.senha;
            

            usuarios.Add(usuario);

            return Ok(usuario);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> ListagemUsuarios() 
        {
            return Ok(usuarios);
        }

        [HttpPut]
        public ActionResult<Usuario> AtualizaUsuario([FromQuery] Usuario value) // Trocar pra [FromBody] depois
        {
            var usuario = usuarios.Where(usuario => usuario.Id.Equals(value.Id)).SingleOrDefault(); 

            if(usuario == null)
            {
                return NotFound();
            }

            var usuarioNovo = new Usuario()
            {
                Id = value.Id,
                Nome = value.Nome,
                Cpf = value.Cpf,
                Email = value.Email,
                senha = value.senha
            };

            return usuarioNovo;
        }



    }
}
