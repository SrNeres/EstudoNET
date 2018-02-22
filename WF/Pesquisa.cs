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
    public partial class Pesquisa : Form
    {


        public Pesquisa()
        {
            InitializeComponent();
        }

        private void Pesquisa_Load(object sender, EventArgs e)
        {
            AddData();

        }

        private void AddData()
        {
            string pes = null;
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            var usuario = usuarioBLL.Datagrid(pes);
            dgvUsuarios.DataSource = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pes = txtPesquisa.Text;
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            var usuario = usuarioBLL.Datagrid(pes);

            dgvUsuarios.DataSource = usuario;
        }


        private void LimpaCampos()
        {
            txtNome.Text = "";
            txtSenha.Text = "";
            txtId.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            string user = txtNome.Text;
            string senha = txtSenha.Text;
            string email = txtEmail.Text;
            string tel = txtTel.Text;

            if (user != "" && senha != "" && email != "" && tel != "")
            {

                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Usuario usuario = new Usuario();

                usuario = usuarioBLL.Login(user, senha);
                if (usuario != null)
                {
                    MessageBox.Show("Usuario Ja Cadastrado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    Usuario usu = new Usuario();
                    usu.login = user;
                    usu.senha = senha;
                    usu.email = email;
                    usu.telefone = tel;

                    UsuarioBLL cad = new UsuarioBLL();
                    cad.Cadastrar(usu.login, usu.senha, usu.email, usu.telefone);
                    MessageBox.Show("Cadastro Efetuado Com Sucesso");
                    LimpaCampos();
                }
            }
            else
            {
                MessageBox.Show("Por Favor Prencha todos os campos");
            }
        }

        private void dtgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvUsuarios.Rows[e.RowIndex];
                txtId.Text = row.Cells["usuarioid"].Value.ToString();
                txtNome.Text = row.Cells["login"].Value.ToString();
                txtSenha.Text = row.Cells["senha"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtTel.Text = row.Cells["telefone"].Value.ToString();

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;


            if (id != "")
            {
                int id2 = Convert.ToInt32(txtId.Text);
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {

                    UsuarioBLL usuario = new UsuarioBLL();
                    int ret = usuario.Excluir(id2);

                    if (ret != 0)
                    {
                        MessageBox.Show("Usuario Deletado Com Sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Erro Inesperado");
                    }
                }
                AddData();
                LimpaCampos();

            }
            else
            {
                MessageBox.Show("Por Favor Selecione Um Usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;

            if (id != "")
            {
                int id2 = Convert.ToInt32(txtId.Text);

                string usu = txtNome.Text;
                string senha = txtSenha.Text;
                string email = txtEmail.Text;
                string tel = txtTel.Text;
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja atualizar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    UsuarioBLL usuario = new UsuarioBLL();
                    int ret = usuario.Atualiza(id2, usu, senha, email, tel);

                    if (ret != 0)
                    {
                        MessageBox.Show("Usuario Atualizado Com Sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MessageBox.Show("Erro Inesperado");
                    }
                }
                AddData();
                LimpaCampos();
            }
            else
            {
                MessageBox.Show("Por Favor Selecione Um Usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            AddData();
        }
    }
}
