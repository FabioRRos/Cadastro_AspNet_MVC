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
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }
                return View(contato);

            }
            catch (SystemException e)
            {
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente!, erro: {e.Message}";

                    return RedirectToAction("Index");

                }
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";

                    return RedirectToAction("Index");
                }
                return View(contato);

            }
            catch (SystemException e)
            {
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamente!, erro: {e.Message}";

                    return RedirectToAction("Index");

                }
            }
        }



    
        public IActionResult Apagar(int id)
        {

            try

            {
                var retorno =  _contatoRepository.Apagar(id);

                if (retorno)
                    {
                        TempData["MensagemSucesso"] = "Contato Apagado com sucesso!";
                    }
                else
                    {
                        TempData["MensagemErro"] = "Não conseguimos apagar o contato!, tente novamente.";
                    }

                    return RedirectToAction("Index");
            }
            catch (SystemException e)
            {
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar o contato!, tente novamente., erro: {e.Message}";

                    return RedirectToAction("Index");

                }
            }
        }
    }
}
