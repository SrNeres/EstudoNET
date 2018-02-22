using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;



namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Acessar(DTO.Usuario user)
        {
            var login = user.login;
            var senha = user.senha;

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            Usuario usu = new Usuario();

            usu = usuarioBLL.Login(login, senha);


            if (usu == null)
            {
                ModelState.AddModelError("Qualquer", "Usuario ou Senha incorrentos ");
                return View("Index", user);
            }
            else
            {
                return View("Home");
            }
        }

        public ActionResult Home()
        {
            return View("Home");
        }
    }
}