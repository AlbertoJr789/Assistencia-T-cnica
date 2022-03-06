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
    public partial class FormCadServicos : Form
    {
        private int ID = -1;
        private bool Edicao = false,EdicaoOS = false;
        private DataGridViewRow dgServ = null;
        private FormCadNota edOS = null;
        private Servico servico = new Servico();

        public FormCadServicos(bool Edicao,DataGridViewRow dgServ,bool EdicaoOS,FormCadNota edOS)
        {
            InitializeComponent();

            if (Edicao) 
            {
                //atribuindo os argumentos às variáveis globais da classe                
                this.Edicao = true;
                this.ID = Convert.ToInt32(dgServ.Cells["ID"].Value.ToString());
                this.dgServ = dgServ;
                
            }
            if (EdicaoOS) 
            {
                //atribuindo os argumentos às variáveis globais da classe
                this.EdicaoOS = true;
                this.ID = Convert.ToInt32(dgServ.Cells["ID"].Value.ToString());
                this.dgServ = dgServ;
                this.edOS = edOS;
                
            }
        }

        private void FormCadServicos_Load(object sender, EventArgs e)
        {

            if (Edicao)
            {
                label1.Text = "Atualização de Serviço";
                botaoAdd.Text = "Atualizar Dados";
                descricao.Text = dgServ.Cells["Descrição"].Value.ToString();
                preco.Text = dgServ.Cells["Preco"].Value.ToString();

            }
            
            if (EdicaoOS)
            {
                label1.Text = "Atualização de Serviço";
                botaoAdd.Text = "Atualizar Dados";
                descricao.Text = dgServ.Cells["Descricao"].Value.ToString();
                preco.Text = dgServ.Cells["Preco"].Value.ToString();
                
                labelQtd.Visible = true;
                qtdServ.Value = Convert.ToInt32(dgServ.Cells["Quantidade"].Value.ToString());   
                qtdServ.Visible = true;

            }

        }


        private void LimparForm()
        {
            //esvaziando o form
            descricao.Clear();
            preco.Clear();
                
            //repintando os labels
            labelDescricao.ForeColor = Color.Black;
            labelPreco.ForeColor = Color.Black;
               
        }

        private bool FormsOk()
        {

            bool FormFaltando = false;

            //conferindo se os formularios obrigatorios foram preenchidos

            if (descricao.Text == "")
            {
                labelDescricao.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (preco.Text == "")
            {
                labelPreco.ForeColor = Color.Red;
                FormFaltando = true;

            }


            return (FormFaltando) ? false : true;

        }

        private void botaoAdd_Click(object sender, EventArgs e)
        {
            if (FormsOk())
            {

                MySqlConexao produtoDB = new MySqlConexao();

                servico.Descricao = descricao.Text;
                servico.Preco = Convert.ToDecimal(preco.Text.Replace("R$ ",""));
                if (EdicaoOS)
                    servico.Quantidade = Convert.ToInt32(qtdServ.Value);


                if (this.Edicao)
                {
                    produtoDB.attServico(this.ID, servico);
                    Close();
                }
                else if (this.EdicaoOS)
                {
                    edOS.attServico(this.ID, servico);
                    Close();

                }
                else
                    produtoDB.addServico(servico);

                LimparForm();


            }
            else
                if (this.Edicao)
                MessageBox.Show("Erro ao atualizar serviço !\nVerifique se algum campo não foi devidamente preenchido !", "Erro de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Erro ao adicionar serviço !\nVerifique se algum campo não foi devidamente preenchido !", "Erro de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void botLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void descricao_TextChanged(object sender, EventArgs e)
        {
            if (labelDescricao.ForeColor == Color.Red)
                labelDescricao.ForeColor = Color.Black;
        }

        private void preco_TextChanged(object sender, EventArgs e)
        {
            if (labelPreco.ForeColor == Color.Red)
                labelPreco.ForeColor = Color.Black;
        }

        private void preco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (preco.Text.Contains(","));
                }
                else
                    e.Handled = true;
            }
        }

        private string valor;
        private void preco_KeyUp(object sender, KeyEventArgs e)
        {
            valor = preco.Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");
            if (valor.Length == 0)
            {
                preco.Text = "0,00" + valor;
            }
            if (valor.Length == 1)
            {
                preco.Text = "0,0" + valor;
            }
            if (valor.Length == 2)
            {
                preco.Text = "0," + valor;
            }
            else if (valor.Length >= 3)
            {
                if (preco.Text.StartsWith("0,"))
                {
                    preco.Text = valor.Insert(valor.Length - 2, ",").Replace("0,", "");
                }
                else if (preco.Text.Contains("00,"))
                {
                    preco.Text = valor.Insert(valor.Length - 2, ",").Replace("00,", "");
                }
                else
                {
                    preco.Text = valor.Insert(valor.Length - 2, ",");
                }
            }
            valor = preco.Text;
            preco.Text = string.Format("{0:C}", Convert.ToDecimal(valor));
            preco.Select(preco.Text.Length, 0);
        }

        private void preco_Leave(object sender, EventArgs e)
        {
            valor = preco.Text.Replace("R$", "");
            preco.Text = string.Format("{0:C}", Convert.ToDouble(valor));
        }

        
    }
}
