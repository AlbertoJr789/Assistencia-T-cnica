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

        private DataTable tabelaNotas = null;

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

        private void FormGerenNota_Load(object sender, EventArgs e)
        {
            MostrarNotas("SELECT * FROM nota_servico");
        }

        private void MostrarNotas(string cmd)
        {

            MySqlConexao conexaoDB = new MySqlConexao();
            this.tabelaNotas = conexaoDB.mostrarNotas(cmd);
            
            dataGridNotas.Columns["Valor"].DisplayIndex = 6;
            dataGridNotas.DataSource = this.tabelaNotas;
        }

        private void dataGridNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridNotas.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                if (e.ColumnIndex == dataGridNotas.Columns["Visualizar"].Index)
                {                

                    Pessoa cliente = new Pessoa();
                    Funcionario funcionario = new Funcionario();
                    Endereco endCli = new Endereco(), endFun = new Endereco();
                    Contato conCli = new Contato(), conFun = new Contato();
                                        
                    DataTable tblNota = new DataTable();
                    //inicializando colunas tabela de dados
                    tblNota.Columns.Add("Tipo");
                    tblNota.Columns.Add("ID");
                    tblNota.Columns.Add("Descricao");
                    tblNota.Columns.Add("Quantidade");
                    tblNota.Columns.Add("Estoque");
                    tblNota.Columns.Add("Preco");
                    tblNota.Columns.Add("PrecoTotal");

                    DataGridViewRow linha = dataGridNotas.Rows[e.RowIndex];

                    string dRS = null, dP = null, aRS = null, aP = null;
                    obterDescontosOuAcrescimos(linha, ref dRS, ref dP, ref aRS, ref aP);

                    //obtendo os dados do cliente e do funcionario do banco de dados
                    MySqlConexao conexaoDB = new MySqlConexao();

                    conexaoDB.tabelaNota(ref tblNota,Convert.ToInt32(linha.Cells["ID"].Value.ToString()));
                    conexaoDB.ClienteNota(linha.Cells["NomeCliente"].Value.ToString(), ref cliente, ref endCli, ref conCli);
                    conexaoDB.FuncionariosNota(linha.Cells["NomeFuncionario"].Value.ToString(), ref funcionario, ref endFun, ref conFun);
                   
                    FormPrintNota notaPrint = new FormPrintNota(cliente,endCli,conCli,funcionario,endFun
                        , conFun, tblNota,linha.Cells["Data"].Value.ToString(),dRS,dP,aRS,aP,
                        linha.Cells["Valor"].Value.ToString(), linha.Cells["Observacoes"].Value.ToString(),
                        null,true);

                    notaPrint.ShowDialog();
                }   
               
                if (e.ColumnIndex == dataGridNotas.Columns["Editar"].Index)
                {
                    FormCadNota formEdicao = new FormCadNota(true, dataGridNotas.Rows[e.RowIndex]);
                    formEdicao.ShowDialog();

                }   
                
                if (e.ColumnIndex == dataGridNotas.Columns["Excluir"].Index)
                {
                    if (MessageBox.Show("Tem certeza de que deseja excluir esta nota ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        MySqlConexao conexaoDB = new MySqlConexao();
                        DataGridViewRow linha = dataGridNotas.Rows[e.RowIndex];
                        conexaoDB.excluirNota(Convert.ToInt32(linha.Cells["ID"].Value.ToString())); 

                    }

                }

            }
        }

        private void obterDescontosOuAcrescimos(DataGridViewRow linha, ref string dRS, ref string dP
              , ref string aRS, ref string aP)
        {

            //verificando descontos e acrescimos (em % ou R$)
            if (linha.Cells["Desconto"].Value.ToString().Contains("%"))
            {
                dRS = "";
                dP = linha.Cells["Desconto"].Value.ToString();

            }
            else
            {
                dRS = linha.Cells["Desconto"].Value.ToString(); ;
                dP = "";

            }

            if (linha.Cells["Acrescimo"].Value.ToString().Contains("%"))
            {
                aRS = "";
                aP = linha.Cells["Acrescimo"].Value.ToString();

            }
            else
            {
                aRS = linha.Cells["Acrescimo"].Value.ToString(); ;
                aP = "";

            }

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            MostrarNotas("SELECT * FROM nota_servico");
        }

        private void textBusca_TextChanged(object sender, EventArgs e)
        {
           if(textBusca.ForeColor == Color.Black)
            {

                this.tabelaNotas.DefaultView.RowFilter = string.Format("NomeCliente LIKE '{0}%'", textBusca.Text);

            }


        }

        private void textBusca_Enter(object sender, EventArgs e)
        {

            if (textBusca.Text == "Digite o nome do cliente aqui para buscar...")
            {
                textBusca.Clear();
                textBusca.ForeColor = Color.Black;

            }

        }

        private void textBusca_Leave(object sender, EventArgs e)
        {
            if(textBusca.Text == "")
            {
                textBusca.Text = "Digite o nome do cliente aqui para buscar...";
                textBusca.ForeColor = Color.Gray;
                this.tabelaNotas.DefaultView.RowFilter = "";

            }
        }
    }
}
