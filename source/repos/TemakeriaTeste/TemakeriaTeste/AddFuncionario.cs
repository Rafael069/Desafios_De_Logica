using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TemakeriaTeste
{
    public partial class AddFuncionario : Form
    {
        public AddFuncionario()
        {
            InitializeComponent();
            txt_nome.Enabled = false;
            txt_telefone.Enabled = false;
            txt_cpf.Enabled = false;
            txt_email.Enabled = false;
            txt_endereco.Enabled = false;
            txt_numero.Enabled = false;
            txt_bairro.Enabled = false;
            txt_rg.Enabled = false;
            txt_celular.Enabled = false;
            txt_pesquisar.Enabled = false;
        }

        /* conexão com o banco */

        SqlConnection sqlCon = null;
        private string strCon ="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=restaurante;Data Source=LAPTOP-QQVCHSSD-SQLEXPRESS";
        private string StrSql = string.Empty;



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {

             strCon = "insert into temakeria2 values(Nome,Telefone,Celular,Email,Endereco,Numero,Bairro,RG,CPF)values(@Nome,@Telefone,@Celular,@Email,@Endereco,@Numero,@Bairro,@RG,@CPF) ";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(StrSql,strCon);
        }
    
        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_nome.Enabled = true;
            txt_telefone.Enabled = true;
            txt_cpf.Enabled = true;
            txt_email.Enabled = true;
            txt_endereco.Enabled = true;
            txt_numero.Enabled = true;
            txt_bairro.Enabled = true;
            txt_rg.Enabled = true;
            txt_celular.Enabled = true;
            txt_pesquisar.Enabled = true;


        }
    }
}
