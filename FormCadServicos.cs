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
        private bool Edicao = false;
        private Servico servico = new Servico();

        public FormCadServicos(bool Edicao,DataGridViewRow dgServ)
        {
            InitializeComponent();

            if (Edicao) //significa que é um formulário de edição de produtos
            { // logo, os dados antigos serão coletados e exibidos

                label1.Text = "Atualização de Produto";
                botaoAdd.Text = "Atualizar Dados";

                this.Edicao = true;
                this.ID = Convert.ToInt32(dgServ.Cells["ID"].Value.ToString());
                descricao.Text = dgServ.Cells["Descrição"].Value.ToString();
                preco.Text = dgServ.Cells["Preco"].Value.ToString();
               
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
                servico.Preco = Convert.ToDecimal(preco.Text);
            
                if (this.Edicao)
                    produtoDB.attServico(this.ID, servico);
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
    }
}
