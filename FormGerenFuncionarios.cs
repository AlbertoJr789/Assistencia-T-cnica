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
    public partial class FormGerenFuncionarios : Form
    {
        public FormGerenFuncionarios()
        {
            InitializeComponent();
        }

        private void MostrarFuncionarios(string cmd)
        {
            MySqlConexao funcionariosDB = new MySqlConexao();
            funcionariosDB.mostrarFuncionarios(cmd, dataGridFuncionarios);

        }

        private void botaoCadastro_Click_1(object sender, EventArgs e)
        {
            FormCadFuncionarios cadastroFuncionario = new FormCadFuncionarios(false, null);
            cadastroFuncionario.ShowDialog();
        }

        private void FormGerenFuncionarios_Load(object sender, EventArgs e)
        {
            MostrarFuncionarios("SELECT * FROM funcionario");
        }
        private void textBusca_MouseClick(object sender, MouseEventArgs e)
        {
            textBusca.Clear();
            textBusca.ForeColor = Color.Black;
        }

        private void textBusca_Leave_1(object sender, EventArgs e)
        {

            if (textBusca.Text == "")
            {
                textBusca.ForeColor = System.Drawing.SystemColors.ControlDark;
                textBusca.Text = "Digite o nome aqui para buscar...";
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (textBusca.Text != "")
            {
                MostrarFuncionarios("SELECT * FROM funcionario WHERE Nome LIKE '" + textBusca.Text + "%'");

            }
            else
            {
                MessageBox.Show("Digite algum nome para que a pesquisa seja efetuada !");
            }
        }

        private void refresh_Click_1(object sender, EventArgs e)
        {
            MostrarFuncionarios("SELECT * FROM funcionario");
        }
             
        private void dataGridFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //verificando se a celula clicada é um botão
            if (dataGridFuncionarios.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0)
            {

                if (e.ColumnIndex == dataGridFuncionarios.Columns["Editar"].Index)
                {//clicou no botao de editar

                    DataGridViewRow linhaFuncionario = dataGridFuncionarios.Rows[e.RowIndex];
                    FormCadFuncionarios editarCad = new FormCadFuncionarios(true, linhaFuncionario);
                    editarCad.ShowDialog();
                    MostrarFuncionarios("SELECT * FROM funcionario");
                }

                if (e.ColumnIndex == dataGridFuncionarios.Columns["Excluir"].Index)
                { //clicou no botao de excluir

                    if (MessageBox.Show("Tem certeza de que deseja excluir este cliente ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        MySqlConexao excluirDB = new MySqlConexao();
                        DataGridViewRow linhaFuncionario = dataGridFuncionarios.Rows[e.RowIndex];
                        excluirDB.excluirFuncionario(linhaFuncionario);
                        MostrarFuncionarios("SELECT * FROM funcionario");
                    }

                }

            }
        }
               
    }


}

