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
    public partial class FormGerenServicos : Form
    {
        private bool pesquisaOS;
        private FormCadNota cadOS = null;

        public FormGerenServicos(bool pesquisaOS,FormCadNota cadOS)
        {
            InitializeComponent();

            if (pesquisaOS)
            {
                this.pesquisaOS = pesquisaOS;
                this.cadOS = cadOS;
                labelOS.Visible = true;

            }

        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            FormCadServicos cadServico = new FormCadServicos(false,null,false,null);
            cadServico.ShowDialog();
        }

        private void MostrarServicos(string cmd)
        {
            MySqlConexao clientesDB = new MySqlConexao();
            clientesDB.mostrarServicos(cmd, dataGridServicos);
        }

        private void textBusca_Click(object sender, EventArgs e)
        {
            textBusca.Clear();
            textBusca.ForeColor = Color.Black;
        }

        private void textBusca_Leave(object sender, EventArgs e)
        {
            if (textBusca.Text == "")
            {
                textBusca.ForeColor = System.Drawing.SystemColors.ControlDark;
                textBusca.Text = "Digite o nome aqui para buscar...";
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            MostrarServicos("SELECT * FROM servico");
        }

        private void dataGridServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //verificando se a celula clicada é um botão
            if (dataGridServicos.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0)
            {

                if (e.ColumnIndex == dataGridServicos.Columns["Editar"].Index)
                {//clicou no botao de editar

                    DataGridViewRow linhaServico = dataGridServicos.Rows[e.RowIndex];
                    FormCadServicos editarCad = new FormCadServicos(true, linhaServico,false,null);
                    editarCad.ShowDialog();
                    MostrarServicos("SELECT * FROM servico");
                }

                if (e.ColumnIndex == dataGridServicos.Columns["Excluir"].Index)
                { //clicou no botao de excluir

                    if (MessageBox.Show("Tem certeza de que deseja excluir este serviço ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        MySqlConexao excluirDB = new MySqlConexao();
                        DataGridViewRow linhaServico = dataGridServicos.Rows[e.RowIndex];
                        excluirDB.excluirServico(linhaServico);
                        MostrarServicos("SELECT * FROM servico");
                    }

                }

            }
            else
            {
                if (pesquisaOS && e.RowIndex >= 0)
                {
                    cadOS.dadosNota(dataGridServicos.Rows[e.RowIndex], "servico");
                    Close();
                }


            }
        }

        private void FormGerenServicos_Load(object sender, EventArgs e)
        {
            MostrarServicos("SELECT * FROM servico");
        }

        private void textBusca_TextChanged(object sender, EventArgs e)
        {
           MostrarServicos("SELECT * FROM servico WHERE Nome_Servico LIKE '" + textBusca.Text + "%'");
        }

        private void FormGerenServicos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!pesquisaOS)
            {

                MenuAssistencia mostrarMenu = new MenuAssistencia(MenuAssistencia.User, MenuAssistencia.UserSenha);
                mostrarMenu.Show();

            }
        }
    }
}
