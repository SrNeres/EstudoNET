using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
namespace Web
{
    public partial class Login : System.Web.UI.Page
    {

        protected override void OnInit(EventArgs e)
        {
            btnAcessar.Click += BtnLogin_Click;
            btnCadastrar.Click += BtnCadastrar_Click;
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cadastrar.aspx");
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            string usu = txtNome.Text;
            string senha = txtSen.Text;
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            Usuario usuario = new Usuario();

            usuario = usuarioBLL.Login(usu, senha);

            if (usuario == null)
            {

                lt.Text = "O login e/ou a senha não conferem";
                txtNome.Focus();
            }
            else
            {

                Response.Redirect("Home.aspx");
                txtNome.Text = "";
                txtSen.Text = "";
                lt.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Reload(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtSen.Text = "";
            lt.Text = "";

        }


    }
}