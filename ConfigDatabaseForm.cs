using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistencia_Técnica
{
    public partial class ConfigDatabaseForm : Form
    {
        private LoginForm loginForm = null;

        public ConfigDatabaseForm(LoginForm loginForm)
        {
            this.loginForm = loginForm;
            InitializeComponent();
        }

        private bool validado()
        {
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validado())
            {
                String URL = String.Format("server={0};uid={1};pwd={2};port={3}",
                    dbServer.Text,dbUID.Text,dbPWD.Text,dbPort.Value);                         

                MySqlConexao.ConexaoDB(URL);
                MySqlConexao.criarDB(URL);
                loginForm.labelStatusBD.Text = "Conectado !";
                loginForm.labelStatusBD.ForeColor = Color.Green;
                Close();

            }

        }
    }
}
