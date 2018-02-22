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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }


        private void btnCadastra_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            usuario.login = txtLogin.Text;
            usuario.senha = txtSenha.Text;
            usuario.email = txtEmail.Text;
            usuario.telefone = txtTelefone.Text;

            UsuarioBLL cad = new UsuarioBLL();
            cad.Cadastrar(usuario.login, usuario.senha, usuario.email, usuario.telefone);
            MessageBox.Show("Cadastro Efetuado Com Sucesso");
            LimpaCampos();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            Pesquisa pes = new Pesquisa();
            pes.Show();
        }


        private void LimpaCampos()
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
        }
    }
}
