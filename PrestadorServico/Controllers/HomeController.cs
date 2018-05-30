using System.Web.Mvc;
using PrestadorServico.Repositories;

namespace PrestadorServico.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var clienteMaisGastouRepo = new ClienteMaisGastouRepository();
            ViewData["ClienteMaisGastou"] = clienteMaisGastouRepo.GetMaisGastou();

            var fornecedorMediaValorRepo = new FornecedorMediaValorRepository();
            ViewData["FornecedorMediaValor"] = fornecedorMediaValorRepo.GetMediaValorByTipo();

            var fornecedorSemServicoRepo = new FornecedorSemServicoRepository();
            ViewData["FornecedorSemServico"] = fornecedorSemServicoRepo.GetSemServico();

            var fornecedorRepo = new FornecedorRepository();
            ViewData["Fornecedor"] = fornecedorRepo.Get();

            return View();
        }
    }
}