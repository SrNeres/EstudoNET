using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;

namespace LoginMVC.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult CadastroView()
        {
            ModelState.AddModelError("", "");
            Usuario usuario = new Usuario();

            string pes = null;
            UsuarioBLL _usuarioBLL = new UsuarioBLL();
            var usu = _usuarioBLL.Datagrid(pes);
            System.Web.UI.WebControls.GridView gView = new System.Web.UI.WebControls.GridView();
            gView.DataSource = usu;
            gView.DataBind();
            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                using (System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw))
                {
                    gView.RenderControl(htw);
                    ViewBag.GridViewString = sw.ToString();
                }
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Cadastrar(FormCollection form)
        {
            string login = form["Login"];
            string senha = form["Senha"];
            string email = form["Email"];
            string telefone = form["Telefone"];

            UsuarioBLL _usuarioBLL = new UsuarioBLL();
            _usuarioBLL.Cadastrar(login, senha, email, telefone);

            ModelState.AddModelError("Qualquer", "Usuario Cadastrado Com Sucesso");
            return View("CadastroView");

        }
    }
}