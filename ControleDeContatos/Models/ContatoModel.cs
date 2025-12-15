using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="Digite o e-mail!!")]
        [EmailAddress(ErrorMessage ="E-mail invlaido!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite o numero do telefone!")]
        [Phone(ErrorMessage ="O celular informado é invalido!")]
        public string Telefone { get; set; }

    }
}
