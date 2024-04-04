using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Models;

namespace UsuarioApi.Controllers
{
    [ApiController] // devido a esse atributo no parametro da Action eu posso passar um tipo complexo
    [Route("[controller]")] //
    public class UsuarioController : ControllerBase
    {

        [HttpPost]  //O FromBody não é obrigatório a partir do C# 3.1 para parametros complexos na Action!
        public ActionResult<Usuario> CriarUsuario([FromQuery] Usuario value)
        {
            List<Usuario> usuarios = new List<Usuario>();

            Usuario usuario = new Usuario();

            usuario.Id = value.Id;
            usuario.Nome = value.Nome;
            usuario.Cpf = value.Cpf;
            usuario.Email = value.Email;
            usuario.senha = value.senha;

            usuarios.Add(usuario);

            return Ok(usuario);
        }
    }
}
