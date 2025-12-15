using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //Gravar no banco de dados

            usuario.DataCadastro = DateTime.UtcNow;

            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }


        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            //Busca o dados

            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            //valida 
            if (usuarioDb == null) 
            {
                throw new Exception($"Houve um erro na atualização do contato: {usuario.Name}");
            
            }
            //altera 
            usuarioDb.Name = usuario.Name;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.UtcNow;

            //atualiza 
            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();


            //retorna 
            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);


            if (usuarioDb == null)
            {
                throw new Exception($"Houve um erro na exclusão do contato: {usuarioDb.Name}");
            }

            _bancoContext.Usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
