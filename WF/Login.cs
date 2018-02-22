using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace WF
{
    public partial class Login : Form
    {
        public object Me { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtSenha.Text != "")
            {
                string login = txtUsuario.Text;
                string senha = txtSenha.Text;

                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Usuario usuario = new Usuario();

                usuario = usuarioBLL.Login(login, senha);
                if (usuario == null)
                {
                    MessageBox.Show("O login e/ou a senha não conferem", "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsuario.Focus();
                }
                else
                {

                    if (usuario.login == "adm")
                    {
                        Publico.usuarioAtual = usuario.login;
                        this.Hide();
                        Home home = new Home();
                        home.Show();
                    }
                    else if (usuario.login == "usu")
                    {
                        this.Hide();
                        TelaUsuario telaUsuario = new TelaUsuario();
                        telaUsuario.Show();
                    }

                }
            }
            else
            {
                MessageBox.Show("Informe o login do usuario e sua senha", "Dados Invalidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Focus();
            }
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadastro cad = new Cadastro();
            cad.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();

        }


    }
}
