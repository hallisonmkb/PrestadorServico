using System;
using System.Linq;
using System.Web.Mvc;
using PrestadorServico.Models;
using PrestadorServico.Repositories;

namespace PrestadorServico.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        public ActionResult Register()
        {
            if (Session["FornecedorId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var clienteRepo = new ClienteRepository();
            var clienteList = clienteRepo.Get();

            var clientes = clienteList.Select(c => new SelectListItem
            {
                Text = c.Nome.ToString(),
                Value = c.ClienteId.ToString()
            }).ToList();
            clientes.Insert(0, new SelectListItem
            {
                Text = string.Empty,
                Value = string.Empty
            });

            var model = new ServicoModels();
            model.Atendimento = DateTime.Today;

            ViewData["Clientes"] = clientes;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoModels model)
        {
            if (!ModelState.IsValid)
            {
                TempData["messageTemp"] = "Favor preencher corretamente os campos.";
                return RedirectToAction("Message");
            }

            model.FornecedorId = Convert.ToInt32(Session["FornecedorId"]);

            var servicoRepo = new ServicoRepository();
            servicoRepo.Add(model);

            TempData["messageTemp"] = "Seu serviço foi registrado.";
            return RedirectToAction("Message");
        }

        public ActionResult Message()
        {
            ViewBag.Message = TempData["messageTemp"];

            return View();
        }
    }
}