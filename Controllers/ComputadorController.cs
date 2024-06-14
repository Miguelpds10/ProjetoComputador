using Microsoft.AspNetCore.Mvc;
using ProjetoComputador.Models;
using ProjetoComputador.Repositorio;

namespace ProjetoComputador.Controllers
{
    public class ComputadorController : Controller
    {
        // ILogger permite retornar erros e avisos dos nossos sistemas de forma simples e fácil
        private readonly ILogger<ComputadorController> _logger;
        private IComputadorRepositorio? _computadorRepositorio;


        // criando um metodo para receber a interface do looger e do repositorio cliente

        public ComputadorController(ILogger<ComputadorController> logger, IComputadorRepositorio computadorRepositorio)
        {
            _logger = logger;
            _computadorRepositorio = computadorRepositorio;

        }

        public IActionResult Computador()
        {
            return View(_computadorRepositorio.TodosComputadores());
        }
        public IActionResult CadComputador()
        {

            //retorna a Página
            return View();
        }
        //Página Cadastro Computador que envia os dados(post)
        [HttpPost]
        public IActionResult CadComputador(Computador computador)
        {
            //metodo cadastra 
            _computadorRepositorio.Cadastrar(computador);

            //redireciona para index
            return RedirectToAction(nameof(Computador));
        }
    }
}

