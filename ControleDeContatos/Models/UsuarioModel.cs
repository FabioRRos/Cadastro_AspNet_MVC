using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do usuário")]
        public string Email { get; set; }
        public PefilEnum Perfil { get;set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
         [Required(ErrorMessage = "Digite a senha do usuário")]
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
