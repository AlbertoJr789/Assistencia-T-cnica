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
        public FormGerenServicos()
        {
            InitializeComponent();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            FormCadServicos cadServico = new FormCadServicos(false,null);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (textBusca.Text != "")
            {
                MostrarServicos("SELECT * FROM servico WHERE Nome LIKE '" + textBusca.Text + "%'");

            }
            else
            {
                MessageBox.Show("Digite algum nome para que a pesquisa seja efetuada !");
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
                    FormCadServicos editarCad = new FormCadServicos(true, linhaServico);
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
        }

        private void FormGerenServicos_Load(object sender, EventArgs e)
        {
            MostrarServicos("SELECT * FROM servico");
        }
    
    }
}
