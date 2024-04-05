using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Models;

namespace UsuarioApi.Controllers
{
    [ApiController] // devido a esse atributo no parametro da Action eu posso passar um tipo complexo
    [Route("[controller]")] 
    public class UsuarioController : ControllerBase 
    {
        private readonly List<Usuario> usuarios; // O readonly vai obrigar  a não poder alterar o usuario?

        public UsuarioController() 
        {
            usuarios = new List<Usuario>();
        }

        [HttpPost]  //O FromBody não é obrigatório a partir do C# 3.1 para parametros complexos na Action!
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Usuario> CriarUsuario([FromBody] Usuario value) 
        {
            Usuario usuario = new Usuario();

            usuario.Id = value.Id;
            usuario.Nome = value.Nome;
            usuario.Cpf = value.Cpf;
            usuario.Email = value.Email;
            usuario.senha = value.senha;
            
            usuarios.Add(usuario);

            return CreatedAtAction(actionName:nameof(CriarUsuario), usuario);
        }

        [HttpGet]
        public ActionResult<List<Usuario>> ListagemUsuarios() 
        {
            return Ok(usuarios);
        }

        [HttpPut]
        public ActionResult<Usuario> AtualizaUsuario([FromBody] Usuario value) 
        {
            var usuario = usuarios.Where(usuario => usuario.Id.Equals(value.Id)).SingleOrDefault(); 

            if(usuario == null)
            {
                return NotFound();
            }

            usuario.Id = value.Id;
            usuario.Nome = value.Nome;
            usuario.Cpf = value.Cpf;
            usuario.Email = value.Email;
            usuario.senha = value.senha;
        
            return usuario;
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> BuscaUsuario([FromBody] int id)
        {
            var usuario = usuarios.Where(usuario => usuario.Id.Equals(id)).SingleOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Usuario>> DeletarUsuario([FromBody]int id) 
        {
            var usuario = usuarios.Where(usuario => usuario.Id.Equals(id)).SingleOrDefault();

            usuarios.Remove(usuario);

            return Ok(usuarios);
        }







    }
}
