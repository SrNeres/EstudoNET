using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using DAL;
using System.Windows.Forms;

namespace BLL
{


    public class UsuarioBLL : IUsuario
    {
        
        public Usuario Login(string usu, string sen)
        {
            try
            {
                string sql = "SELECT usuario, senha, tipo from usuarios where usuario= '"+usu+"' AND senha= '"+sen+"'  ";
                DataTable tabela = new DataTable();
                tabela = AcessoBD.GetDataTable(sql);
                return GetUsuario(tabela);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Usuario GetUsuario(DataTable tabela)
        {
            try
            {
                Usuario _usuario = new Usuario();
                if ( tabela.Rows.Count > 0)
                {
                    _usuario.login = tabela.Rows[0][0].ToString();
                    _usuario.senha = tabela.Rows[0][1].ToString();
                    
                    return _usuario;
                } else
                {
                    _usuario = null;
                    return _usuario;


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public  void Cadastrar(string usu, string sen, string email, string telefone)
        { 
            try
            {
                string sql = "INSERT into usuarios (usuario, senha, email, telefone) Values ('"+usu+ "', '" + sen + "', '" + email + "', '" + telefone + "')";

                AcessoBD acesso = new AcessoBD();
                acesso.Alterar(sql);
               



            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: "+ ex + "Ao Cadastrar o Usuario");
               
               
                
            }
            
        }

       


        public List<Usuario> Datagrid(string pesquisa)
        {
            try
            {
                string sql;
                if (pesquisa == null) { 
                 sql = "SELECT * from usuarios";
                }else
                {
                    sql = "SELECT * from usuarios where usuario = '" + pesquisa + "'";
                }
                DataTable tabela = new DataTable();
                tabela = AcessoBD.GetDataTable(sql);
                return GetVarios(tabela);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Usuario> GetVarios(DataTable tabela)
        {

            try
            {
                List<Usuario> _usuario = new List<Usuario>();
                
               
                    for(int i = 0; i < tabela.Rows.Count;  i++)
                    {
                       
                        Usuario usuario = new Usuario();

                        usuario.usuarioId = tabela.Rows[i][0].ToString();
                        usuario.login = tabela.Rows[i][2].ToString();
                        usuario.senha = tabela.Rows[i][3].ToString();
                        usuario.email = tabela.Rows[i][4].ToString();
                        usuario.telefone = tabela.Rows[i][5].ToString();
                    
                    _usuario.Add(usuario);
                    
                    }
                   
                    return _usuario;
                
               

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public int Excluir(int id)
        {
            int ret = 0;
            try
            {
                string sql = "DELETE * from usuarios where id = "+id.ToString()+" ";
                AcessoBD acesso = new AcessoBD();
                ret = acesso.Alterar(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex + "Ao Cadastrar o Usuario");

           }
           return ret;
        }

        public int Atualiza(int id, string usuario, string senha, string email, string telefone)
        {
            int ret = 0;
            try
            {
                 string sql = "Update usuarios set usuario = '" + usuario.ToString() + "', senha = '" + senha.ToString() + "', email = '" + email.ToString() + "', telefone = '" + telefone.ToString() + "'  where id = " +id.ToString()+ " ";
                AcessoBD acesso = new AcessoBD();
                ret = acesso.Alterar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }




            return ret;
        }
    }
}
