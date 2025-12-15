using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuariooRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuariooRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            var usuario = _usuariooRepository.BuscarTodos();
            return View(usuario);
        }

        public IActionResult Criar()
        {
            return View();
        }















        ////////////////


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuariooRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }
                return View(usuario);

            }
            catch (SystemException e)
            {
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente!, erro: {e.Message}";

                    return RedirectToAction("Index");

                }
            }
        }
    }
}
