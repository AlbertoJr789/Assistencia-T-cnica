using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Assistencia_Técnica
{
    public partial class FormPrintNota : Form
    {
        private DadosNota dadosNota = new DadosNota();
        public DataSetNotaObjeto dataSetObj = new DataSetNotaObjeto();
        private DataTable tabelaDataSet = new DataTable();
        private bool salvou = false;
        private FormCadNota cadNota;

        public FormPrintNota(Pessoa cliente, Endereco endCli, Contato conCli,
            Funcionario funcionario, Endereco endFun, Contato conFun, DataTable
            tabelaNota, string data, string dRS,string dP,string aRS,string aP,
            string valor,string obs,FormCadNota cadNota)
        {
            InitializeComponent();
                   
            //obtendo todas as informações            
            this.dadosNota.ID = 1;
            this.dadosNota.Data = data;
        
            this.dadosNota.cliente = cliente;
            this.dadosNota.endCli = endCli;
            this.dadosNota.conCli = conCli;

            this.dadosNota.tabelaNota = tabelaNota;

            this.dadosNota.funcionario = funcionario;
            this.dadosNota.conFun = conFun;
               
            this.dadosNota.desconto = obterDesconto(dRS,dP);
            this.dadosNota.acrescimo = obterAcrescimo(aRS, aP);

            this.dadosNota.valorNota = valor;
            this.dadosNota.observacoes = obs;

            //montando a tabela de dados.

            this.tabelaDataSet.Columns.Add("ID");
            this.tabelaDataSet.Columns.Add("Descricao");
            this.tabelaDataSet.Columns.Add("Quantidade");
            this.tabelaDataSet.Columns.Add("PrecoUn");
            this.tabelaDataSet.Columns.Add("PrecoTotal");

            this.cadNota = cadNota;

        }

        private void FormPrintNota_Load(object sender, EventArgs e)
        {
            this.impressaoNota.RefreshReport();

            foreach(DataRow linha in this.dadosNota.tabelaNota.Rows)
            {
                DataRow novo = this.tabelaDataSet.NewRow();

                novo["ID"] = linha["ID"];
                novo["Descricao"] = linha["Descricao"];
                novo["Quantidade"] = linha["Quantidade"];
                novo["PrecoUn"] = linha["Preco"];
                novo["PrecoTotal"] = linha["PrecoTotal"];

                this.tabelaDataSet.Rows.Add(novo);

            }

            ReportDataSource source = new ReportDataSource("DataSet1", this.tabelaDataSet);
            this.impressaoNota.LocalReport.DataSources.Add(source);

            ReportParameter[] parametros = new ReportParameter[]
            {
                new ReportParameter("IDNota",dadosNota.ID.ToString()),
                new ReportParameter("dataEntrada",this.dadosNota.Data),
                new ReportParameter("nomeCli",this.dadosNota.cliente.Nome),
                new ReportParameter("ID_Cli",this.dadosNota.cliente.ID.ToString()),
                new ReportParameter("rgCli",this.dadosNota.cliente.RG),
                new ReportParameter("cpfCli",this.dadosNota.cliente.CPF),
                new ReportParameter("logCli",this.dadosNota.endCli.Logradouro),
                new ReportParameter("numEndCli",this.dadosNota.endCli.Numero),
                new ReportParameter("bairroCli",this.dadosNota.endCli.Bairro),
                new ReportParameter("munCli",this.dadosNota.endCli.Cidade),
                new ReportParameter("estCli",this.dadosNota.endCli.Estado),
                new ReportParameter("telCli",this.dadosNota.conCli.Contato1),
                new ReportParameter("telCli2",this.dadosNota.conCli.Contato2),
                new ReportParameter("ID_Fun",this.dadosNota.funcionario.ID.ToString()),
                new ReportParameter("nomeFun",this.dadosNota.funcionario.Nome),
                new ReportParameter("funcao",this.dadosNota.funcionario.Funcao),
                new ReportParameter("telFun",this.dadosNota.conFun.Contato1),
                new ReportParameter("telFun2",this.dadosNota.conFun.Contato2),
                new ReportParameter("desc",this.dadosNota.desconto),
                new ReportParameter("acres",this.dadosNota.acrescimo),
                new ReportParameter("valorNota",this.dadosNota.valorNota),
                new ReportParameter("obs",this.dadosNota.observacoes)

            };
                 
            this.impressaoNota.LocalReport.SetParameters(parametros);
            this.impressaoNota.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.impressaoNota.RefreshReport();

        }

        private void emitirESalvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConexao conexaoDB = new MySqlConexao();
            salvou = conexaoDB.salvarNota(dadosNota);

            if (salvou)
            {
                MessageBox.Show("Nota de Serviço Salva com Sucesso !", "Gravação de Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cadNota.Close();
            }
            else
                MessageBox.Show("Erro ao salvar nota !", "Gravação de Nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.salvou)
            {
                if (MessageBox.Show("Tem certeza de que deseja sair antes de salvar a nota ?", "Relatório Nota de Serviço", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                { 
                    Close();
                }
            }
            else
                Close();
        }

        private string obterDesconto(string dRS, string dP)
        {
            return (dP == "") ? dRS : dP;

        }
        
        private string obterAcrescimo(string aRS,string aP)
        {

            return (aP == "") ? aRS : aP;
        }

        private void FormPrintNota_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.salvou)
            {
                if (MessageBox.Show("Tem certeza de que deseja sair antes de salvar a nota ?", "Relatório Nota de Serviço", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                    e.Cancel = false;        
            }
         
        }
    }
}
