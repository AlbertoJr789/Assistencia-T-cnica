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
    public partial class FormGerenNota : Form
    {
        public FormGerenNota()
        {
            InitializeComponent();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            FormCadNota menuCad = new FormCadNota(false,null);
            menuCad.ShowDialog();
        }

        private void FormGerenOS_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuAssistencia menu = new MenuAssistencia(MenuAssistencia.User, MenuAssistencia.UserSenha);
            menu.Show();
        }
    }
}
