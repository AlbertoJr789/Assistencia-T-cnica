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
    public partial class FormGerenClientes : Form
    {
        private bool pesquisaOS = false;
        private FormCadNota cadOS = null;

        public FormGerenClientes(bool pesquisaOS,FormCadNota cadOS)
        {
            InitializeComponent();

            if (pesquisaOS)
            {
                this.pesquisaOS = true;
                this.cadOS = cadOS;
            }


        }

        private void MostrarClientes(string cmd)
        {
            MySqlConexao clientesDB = new MySqlConexao();
            clientesDB.mostrarClientes(cmd,dataGridClientes);

        } 

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            CadastroCliente cadastroCliente = new CadastroCliente(false,null);
            cadastroCliente.ShowDialog();
            
        }

        private void FormGerenClientes_Load(object sender, EventArgs e)
        {
            MostrarClientes("SELECT * FROM cliente");
        }

        private void textBusca_Click(object sender, EventArgs e)
        {
            textBusca.Clear();
            textBusca.ForeColor = Color.Black;

        }

        private void textBusca_Leave(object sender, EventArgs e)
        {
            if (textBusca.Text == "") {

                textBusca.ForeColor = System.Drawing.SystemColors.ControlDark;
                textBusca.Text = "Digite o nome aqui para buscar...";
                
            }
            
        }
        private void textBusca_TextChanged(object sender, EventArgs e)
        {           
            MostrarClientes("SELECT * FROM cliente WHERE Nome_Cliente LIKE '" + textBusca.Text + "%'");
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            MostrarClientes("SELECT * FROM cliente");
        }

        private void dataGridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {               

            //verificando se a celula clicada é um botão
            if (dataGridClientes.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0)
            {
                
                if (e.ColumnIndex == dataGridClientes.Columns["Editar"].Index)
                {//clicou no botao de editar

                    DataGridViewRow linhaCliente = dataGridClientes.Rows[e.RowIndex];
                    CadastroCliente editarCad = new CadastroCliente(true,linhaCliente);
                    editarCad.ShowDialog();
                    MostrarClientes("SELECT * FROM cliente");
                }
                
                if (e.ColumnIndex == dataGridClientes.Columns["Excluir"].Index)
                { //clicou no botao de excluir

                    if (MessageBox.Show("Tem certeza de que deseja excluir este cliente ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        MySqlConexao excluirDB = new MySqlConexao();
                        DataGridViewRow linhaCliente = dataGridClientes.Rows[e.RowIndex];
                        excluirDB.excluirCliente(linhaCliente);
                        MostrarClientes("SELECT * FROM cliente");
                    }

                }


            }
            else
            {
                if (pesquisaOS)
                {                    
                    cadOS.dadosOS(dataGridClientes.Rows[e.RowIndex], "cliente");
                    Close();
                }
                else //abre o perfil do cliente
                {



                }

            }
         

        }

        private void FormGerenClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!pesquisaOS)
            {
                MenuAssistencia mostrarMenu = new MenuAssistencia(MenuAssistencia.User, MenuAssistencia.UserSenha);
                mostrarMenu.Show();

            }
        }
    }
}
