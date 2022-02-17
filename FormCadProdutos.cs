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
    public partial class FormCadProdutos : Form
    {

        private int ID = -1;
        private bool Edicao = false;
        private Produto produto = new Produto();

        public FormCadProdutos(bool Edicao,DataGridViewRow dgProd) 
        {
            InitializeComponent();

            if (Edicao) //significa que é um formulário de edição de produtos
            { // logo, os dados antigos serão coletados e exibidos

                label1.Text = "Atualização de Produto";
                botaoAdd.Text = "Atualizar Dados";

                this.Edicao = true;
                this.ID = Convert.ToInt32(dgProd.Cells["ID"].Value.ToString());
                descricao.Text = dgProd.Cells["Descrição"].Value.ToString();
                preco.Text = dgProd.Cells["Preco"].Value.ToString();
                estoque.Value = Convert.ToDecimal(dgProd.Cells["Estoque"].Value.ToString());              
            }

        }
        private void LimparForm()
        {
            //esvaziando o form
            descricao.Clear();
            preco.Clear();
            estoque.Value = 0;

            //repintando os labels
            labelDescricao.ForeColor = Color.Black;
            labelPreco.ForeColor = Color.Black;
            labelEstoque.ForeColor = Color.Black;
            
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

                produto.Descricao = descricao.Text;
                produto.Preco = Convert.ToDecimal(preco.Text);
                produto.Estoque = (int)estoque.Value;


                if (this.Edicao)
                    produtoDB.attProduto(this.ID, produto);
                else
                    produtoDB.addProduto(produto);

                LimparForm();


            }
            else
                if (this.Edicao)
                MessageBox.Show("Erro ao atualizar produto !\nVerifique se algum campo não foi devidamente preenchido !", "Erro de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Erro ao adicionar produto !\nVerifique se algum campo não foi devidamente preenchido !", "Erro de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Error);


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

        private string valor;
        private void preco_Leave(object sender, EventArgs e)
        {
            valor = preco.Text.Replace("R$", "");
            preco.Text = string.Format("{0:C}", Convert.ToDouble(valor));
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
    }
}
