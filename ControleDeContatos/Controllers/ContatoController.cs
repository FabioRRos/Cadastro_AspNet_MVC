using ControleDeContatos.Models;
using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            var contato = _contatoRepository.BuscarTodos();
            return View(contato);
        }
        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            var contato = _contatoRepository.ListarPorId(id);

            return View(contato);
        }


       

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {

            _contatoRepository.Adicionar(contato);

            return RedirectToAction("Index");
            }

            return View(contato);

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
           if (ModelState.IsValid)
            {
                _contatoRepository.Atualizar(contato);

                return RedirectToAction("Index");
            }

           return View("Editar",contato);
        }



    
        public IActionResult Apagar(int id)
        {
            _contatoRepository.Apagar(id);

            return RedirectToAction("Index");
        }
    }
}
