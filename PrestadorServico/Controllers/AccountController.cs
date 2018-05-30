using System.Linq;
using PrestadorServico.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace PrestadorServico.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new UsuarioModels());
        }

        /// <param name="login"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioModels model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (PrestadorServico.DataContexts.PrestadorServicoContext db = new DataContexts.PrestadorServicoContext())
                {
                    var usuario = db.Usuarios.Where(p => p.Email.Equals(model.Email)).FirstOrDefault();
                    if (usuario != null)
                    {
                        if (Equals(usuario.Senha, model.Senha))
                        {
                            FormsAuthentication.SetAuthCookie(usuario.Email, false);
                            Session["FornecedorId"] = usuario.FornecedorId;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Senha inválida");
                            return View(new UsuarioModels());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email inválido");
                        return View(new UsuarioModels());
                    }
                }
            }
            return View(model);
        } 
    }
}