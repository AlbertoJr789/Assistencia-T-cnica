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
        
        public MenuAssistencia(string user, string userSenha)
        {
            
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
            FormGerenClientes menuClientes = new FormGerenClientes();
            menuClientes.ShowDialog();
            
        }

        private void ordemServico_Click(object sender, EventArgs e)
        {

        }

        private void sair_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConexao = MySqlConexao.ConexaoDB();
            mySqlConexao.Close();
            Application.Exit();
        }

        private void CadFuncionario_Click(object sender, EventArgs e)
        {           
            FormGerenFuncionarios menuFuncionarios = new FormGerenFuncionarios();
            menuFuncionarios.ShowDialog();
        }

        private void CadServico_Click(object sender, EventArgs e)
        {

        }
    }
}
