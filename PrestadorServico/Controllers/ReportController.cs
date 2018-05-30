using System;
using System.Linq;
using System.Web.Mvc;
using PrestadorServico.Repositories;

namespace PrestadorServico.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        public ActionResult Filter()
        {
            if (Session["FornecedorId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var clienteRepo = new ClienteRepository();
            var clienteList = clienteRepo.Get();

            ViewData["Clientes"] = clienteList.Select(c => new SelectListItem
            {
                Text = c.Nome.ToString(),
                Value = c.ClienteId.ToString()
            }).ToList();

            var estadoRepo = new EstadoRepository();

            ViewData["Estados"] = estadoRepo.Estados.Select(c => new SelectListItem
            {
                Text = c.Nome.ToString(),
                Value = c.Sigla.ToString()
            }).ToList();

            ViewData["Cidades"] = clienteList.GroupBy(i => i.Cidade)
                .Select(group => group.First())
                .Select(c => new SelectListItem
            {
                Text = c.Cidade,
                Value = c.Cidade
            }).ToList();

            var servicoRepo = new ServicoRepository();
            ViewData["Servicos"] = servicoRepo.GetByFornecedor(Convert.ToInt32(Session["FornecedorId"]));

            return View();
        }

        public ActionResult List()
        {
            if (Session["FornecedorId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int.TryParse(Request.QueryString["cliente"], out var cliente);
            string estado = Request.QueryString["estado"];
            string cidade = Request.QueryString["cidade"];
            string bairro = Request.QueryString["bairro"];
            decimal.TryParse(Request.QueryString["valorMinimo"], out var valorMinimo);
            decimal.TryParse(Request.QueryString["valorMaximo"], out var valorMaximo);

            //enumServico tipo = (enumServico)Enum.Parse(typeof(enumServico), Request.QueryString["tipo"]);
            //Enum.TryParse(Request.QueryString["tipo"], out enumServico tipo);
            int parsedValue;
            int? tipo = (int.TryParse(Request.QueryString["tipo"], out parsedValue)) ? (int?)parsedValue : null;

            var servicoRepo = new ServicoRepository();
            
            return PartialView(servicoRepo.GetByReport(Convert.ToInt32(Session["FornecedorId"]), cliente, estado, cidade, bairro, tipo, valorMinimo, valorMaximo));
        }
    }
}