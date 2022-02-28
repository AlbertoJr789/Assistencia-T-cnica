using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Assistencia_Técnica
{
    public partial class MenuAssistencia : Form
    {
        public static string User = null, UserSenha = null;
        public MenuAssistencia(string user, string userSenha)
        {
            User = user;
            UserSenha = userSenha;

            InitializeComponent();
            MySqlConexao usuario = new MySqlConexao();   
            //obtem o nome do usuario e pega o primeiro nome
            labelUsuario.Text = string.Format("Bem-vindo(a), {0}",
            usuario.ObterUsuario(user, userSenha).Substring(0,
            usuario.ObterUsuario(user, userSenha).IndexOf(' ')));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuAssistencia_Load(object sender, EventArgs e)
        {
             timer1.Start();
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Data.Text = DateTime.Now.ToLongTimeString();
            Hora.Text = DateTime.Now.ToLongDateString();

        }

        private void CadCliente_Click(object sender, EventArgs e)
        {
            FormGerenClientes menuClientes = new FormGerenClientes(false,null);
            menuClientes.Show();
            Close();
        }

        private void ordemServico_Click(object sender, EventArgs e)
        {
            FormGerenNota menuOS = new FormGerenNota();
            menuOS.Show();
            Close();
        }

        private void sair_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConexao = MySqlConexao.ConexaoDB();
            mySqlConexao.Close();
            Application.Exit();
        }

        private void CadFuncionario_Click(object sender, EventArgs e)
        {           
            FormGerenFuncionarios menuFuncionarios = new FormGerenFuncionarios(false,null);
            menuFuncionarios.Show();
            Close();
        }

        private void CadServico_Click(object sender, EventArgs e)
        {
            FormGerenServicos menuServicos = new FormGerenServicos(false,null);
            menuServicos.Show();
            Close();
        }

        private void notaServico_Click(object sender, EventArgs e)
        {
            FormGerenNota menuNota = new FormGerenNota();
            menuNota.Show();
            Close();

        }

        private void CadProduto_Click(object sender, EventArgs e)
        {
            FormGerenProdutos menuProdutos = new FormGerenProdutos(false,null);
            menuProdutos.Show();
            Close();
        }
    }
}
