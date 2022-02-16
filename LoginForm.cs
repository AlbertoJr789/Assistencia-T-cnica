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
    public partial class LoginForm : Form
    {

        MySqlConnection conexao = MySqlConexao.ConexaoDB();

        public LoginForm()
        {
          
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConexao login = new MySqlConexao();
                    
            if (login.ChecarLogin(user.Text, userSenha.Text)) //se o login der certo
            { 
                //entrar no menu principal
                MenuAssistencia menu = new MenuAssistencia(user.Text,userSenha.Text);
                menu.Show();
                Visible = false; //fecha o menu de login
                
            } 
            else
            {
                MessageBox.Show("Usuario Não Encontrado, Cheque as Credenciais !");

            }
                      
                        
        }

       
    }
}
