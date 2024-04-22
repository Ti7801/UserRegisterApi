using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Models;
using UsuarioApi.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.Controllers
{
    [ApiController] // devido a esse atributo no parametro da Action eu posso passar um tipo complexo
    [Route("[controller]")] 
    public class UsuarioController : ControllerBase 
    {
        private readonly BancoDeDados banco;

        public UsuarioController(BancoDeDados banco) 
        {
           this.banco = banco;  
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

            if (usuario.Id == 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) // Checando Flag Internamente // Herdada de ControllerBase // Retorna True ou False
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return BadRequest(erros);
            }
            
            banco.AdicionarUsuario(usuario);    
       
            return CreatedAtAction(actionName:nameof(CriarUsuario), usuario);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Usuario>> ListagemUsuarios() 
        {
            return Ok(banco.ObterUsuarios());
        }

        [HttpPut]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Usuario> AtualizaUsuario([FromBody] Usuario value) 
        {
            var usuario = banco.ObterUsuarioPorId(value.Id);
                   
            if(usuario == null)
            {
                return NotFound();
            }

            usuario.Id = value.Id;
            usuario.Nome = value.Nome;
            usuario.Cpf = value.Cpf;
            usuario.Email = value.Email;
            usuario.senha = value.senha;

            if (!ModelState.IsValid) // Checando Flag Internamente // Herdada de ControllerBase // Retorna True ou False
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return BadRequest(erros); // Values é uma lista de várias listas
            }
        
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Usuario> BuscaUsuario(int id)
        {
            var usuario = banco.ObterUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Usuario> DeletarUsuario(int id) 
        {
            Usuario? usuario = banco.DeletarUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return  usuario;
        }
    }
}
