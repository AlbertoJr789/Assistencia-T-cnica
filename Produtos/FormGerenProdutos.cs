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
    public partial class FormGerenProdutos : Form
    {

        private bool pesquisaOS = false;
        private FormCadNota cadOS = null;
        public FormGerenProdutos(bool pesquisaOS,FormCadNota cadOS)
        {
            InitializeComponent();

            if (pesquisaOS)
            {
                this.pesquisaOS = true;
                this.cadOS = cadOS;
                labelOS.Visible = true;
            }

        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            FormCadProdutos cadProdutos = new FormCadProdutos(false,null,false,null);
            cadProdutos.ShowDialog();
        }
        private void MostrarProdutos(string cmd)
        {
            MySqlConexao clientesDB = new MySqlConexao();
            clientesDB.mostrarProdutos(cmd, dataGridProdutos);
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
            MostrarProdutos("SELECT * FROM produto");
        }

        private void dataGridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verificando se a celula clicada é um botão
            if (dataGridProdutos.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0)
            {

                if (e.ColumnIndex == dataGridProdutos.Columns["Editar"].Index)
                {//clicou no botao de editar

                    DataGridViewRow linhaProduto = dataGridProdutos.Rows[e.RowIndex];
                    FormCadProdutos editarCad = new FormCadProdutos(true, linhaProduto,false,null);
                    editarCad.ShowDialog();
                    MostrarProdutos("SELECT * FROM produto");
                }

                if (e.ColumnIndex == dataGridProdutos.Columns["Excluir"].Index)
                { //clicou no botao de excluir

                    if (MessageBox.Show("Tem certeza de que deseja excluir este produto ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        MySqlConexao excluirDB = new MySqlConexao();
                        DataGridViewRow linhaProduto = dataGridProdutos.Rows[e.RowIndex];
                        excluirDB.excluirProduto(linhaProduto);
                        MostrarProdutos("SELECT * FROM produto");
                    }

                }

            }
            else
            {
                if (pesquisaOS && e.RowIndex >= 0)
                {
                    DataGridViewRow linha = dataGridProdutos.Rows[e.RowIndex];
                    if(Convert.ToInt32(linha.Cells["Estoque"].Value.ToString()) > 0)
                    {
                        cadOS.dadosNota(dataGridProdutos.Rows[e.RowIndex], "produto");
                        Close();

                    }
                    else
                    {
                        MessageBox.Show("Erro ! Produto sem estoque\n" +
                        "Edite o produto e renove a quantidade", "Novo Produto Ordem de Serviço"
                        ,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }

            }
        }

        private void FormGerenProdutos_Load(object sender, EventArgs e)
        {
            MostrarProdutos("SELECT * FROM produto");
        }

        private void textBusca_TextChanged(object sender, EventArgs e)
        {
            MostrarProdutos("SELECT * FROM produto WHERE Nome_Produto LIKE '" + textBusca.Text + "%'");

        }

        private void FormGerenProdutos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!pesquisaOS)
            {

                MenuAssistencia mostrarMenu = new MenuAssistencia(MenuAssistencia.User, MenuAssistencia.UserSenha);
                mostrarMenu.Show();

            }
        }
    }
}
