using UsuarioApi.Models;

namespace UsuarioApi.Data
{
    public class BancoDeDados
    {
        private readonly List<Usuario> usuarios; // O readonly vai obrigar  a não poder alterar o usuario?

        public BancoDeDados()
        {
            usuarios = new List<Usuario>();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario); 
        }

        public List<Usuario> ObterUsuarios()
        {
            return usuarios;
        }

        public Usuario? ObterUsuarioPorId(int id) 
        {
            Usuario? usuario = usuarios.Where(u => u.Id == id).SingleOrDefault();

            return usuario;
        }

        public Usuario? DeletarUsuarioPorId(int id)
        {
            Usuario? usuario = usuarios.Where(u => u.Id == id).SingleOrDefault();

            if (usuario == null)
            {
                return null;
            }

            usuarios.Remove(usuario);

            return usuario;
        }
    }
}
