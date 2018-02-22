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
    public partial class Cadastrar : System.Web.UI.Page
    {


        protected override void OnInit(EventArgs e)
        {

            btnCadastrar.Click += BtnCadastrar_Click;

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string log = txtLog.Text;
            string senha = txtSen.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBLL.Cadastrar(log, senha, email, telefone);
            lt.Text = "Usuario Cadastrado Com Sucesso";
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtLog.Text = "";
            txtSen.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                AddData();
        }


        private void AddData()
        {
            string pes = null;
            UsuarioBLL _usuarioBLL = new UsuarioBLL();
            var usuario = _usuarioBLL.Datagrid(pes);
            GridView1.DataSource = usuario;
            GridView1.DataBind();

        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            AddData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtid = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0];
            TextBox txtnome = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox txtsenha = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox txtemail = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox txttel = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];

            int id = 3;
            string nome = txtnome.Text;
            string senha = txtsenha.Text;
            string email = txtemail.Text;
            string tel = txttel.Text;

            UsuarioBLL usuario = new UsuarioBLL();
            usuario.Atualiza(id, nome, senha, email, tel);
            AddData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            AddData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.ID);
            UsuarioBLL usuario = new UsuarioBLL();
            usuario.Excluir(id);
            AddData();
        }
    }
}