using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Assistencia_Técnica
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConexao login = new MySqlConexao();
            try 
            {
                if (login.ChecarLogin(user.Text, userSenha.Text)) //se o login der certo
                {
                    //entrar no menu principal
                    MenuAssistencia menu = new MenuAssistencia(user.Text, userSenha.Text);
                    menu.Show();
                    Visible = false; //fecha o menu de login  
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado, cheque as credenciais !", "Checagem de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao verificar login: " + ex.Message, "Checagem de Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfigDatabaseForm formDB = new ConfigDatabaseForm(this);
            formDB.ShowDialog();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("conexaoDB"))
            { 
                //abre o arquivo de conexão do banco de dados, lê a primeira linha e conecta
                using(StreamReader sr = File.OpenText("conexaoDB")) 
                {

                    if ( (MySqlConexao.ConexaoDB(sr.ReadLine())) != null)
                    {
                        labelStatusBD.Text = "Conectado!";
                        labelStatusBD.ForeColor = Color.Green;
                    }
                    else
                    {
                        labelStatusBD.Text = "Erro ao conectar !";
                        labelStatusBD.ForeColor = Color.Red;
                    }

                }


            }
            else
            {
                labelStatusBD.Text = "Conexão não configurada";
                labelStatusBD.ForeColor = Color.Gray;
            }

        }

    }
}
