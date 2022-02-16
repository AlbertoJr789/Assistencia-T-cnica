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
    public partial class FormCadFuncionario : Form
    {

        private bool Edicao = false;
        private int IdEdit = -1;
        private int IdEnd = -1;
        private int IdCont = -1;
        private Funcionario funcionario = new Funcionario();
        private Endereco endereco = new Endereco();
        private Contato contato = new Contato();

        public FormCadFuncionario(bool Edicao, DataGridViewRow cliente)
        {
            InitializeComponent();

            if (Edicao) //significa que é um formulário de edição de clientes
            { // logo, os dados antigos serão coletados e exibidos
                
                this.Edicao = true;

                //editando alguns labels e botoes
                label1.Text = "Atualização de Cliente";
                botaoAdd.Text = "Atualizar Dados";

                //obtendo os IDs 
                this.IdEdit = (int)cliente.Cells["ID"].Value;
                this.IdEnd = (int)cliente.Cells["ID_End"].Value;
                this.IdCont = (int)cliente.Cells["ID_Cont"].Value;

                //obtendo os dados pessoais do cliente a ser editado
                nomeFuncionario.Text = cliente.Cells["Nome"].Value.ToString();
                funcaoFuncionario.Text = cliente.Cells["Função"].Value.ToString();
                rgFuncionario.Text = cliente.Cells["RG"].Value.ToString();
                cpfFuncionario.Text = cliente.Cells["CPF"].Value.ToString();                   

                //obtendo o endereço              
                endereco.obterEndereco(cliente.Cells["Endereço"].Value.ToString());
                logradouroFuncionario.Text = endereco.Logradouro;
                numeroEndFuncionario.Text = endereco.Numero;
                bairroFuncionario.Text = endereco.Bairro;
                cidadeFuncionario.Text = endereco.Cidade;
                estadoFuncionario.Text = endereco.Estado;

                //obtendo os telefones
                contato.obterContato(cliente.Cells["Contato"].Value.ToString());
                telefone1Funcionario.Text = contato.Contato1;
                telefone2Funcionario.Text = contato.Contato2;

            }

        }

        private void botaoAdd_Click(object sender, EventArgs e)
        {
            if (FormsOk())
            {
                MySqlConexao funcionarioDB = new MySqlConexao();

                //obtendo dados pessoais do cliente
                funcionario.Nome = nomeFuncionario.Text;
                funcionario.RG = rgFuncionario.Text;
                funcionario.Funcao = funcaoFuncionario.Text;
                //obtendo endereço
                endereco.Logradouro = logradouroFuncionario.Text;
                endereco.Numero = numeroEndFuncionario.Text;
                endereco.Bairro = bairroFuncionario.Text;
                endereco.Cidade = cidadeFuncionario.Text;
                endereco.Estado = estadoFuncionario.Text;

                //obtendo contato principal
                telefone1Funcionario.TextMaskFormat = MaskFormat.IncludeLiterals;
                contato.Contato1 = telefone1Funcionario.Text;

                //Verificação do CPF
                //caso o CPF nao tenha sido preenchido
                cpfFuncionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (cpfFuncionario.Text == string.Empty)
                    funcionario.CPF = "";
                else
                {
                    cpfFuncionario.Mask = "000,000,000-00";
                    cpfFuncionario.TextMaskFormat = MaskFormat.IncludeLiterals;
                    funcionario.CPF = cpfFuncionario.Text;
                }

                //caso o contato2 nao tenha sido preenchido
                telefone2Funcionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (telefone2Funcionario.Text == string.Empty)
                    contato.Contato2 = "";
                else
                {
                    telefone2Funcionario.Mask = "(00)0000-0000";
                    telefone2Funcionario.TextMaskFormat = MaskFormat.IncludeLiterals;
                    contato.Contato2 = telefone2Funcionario.Text;
                }

                if (this.Edicao)
                    funcionarioDB.attFuncionario(this.IdEdit, this.IdEnd, this.IdCont, funcionario, endereco, contato);
                else
                    funcionarioDB.addFuncionario(funcionario, endereco, contato);

                LimparForm();

            }
            else
            {
                if (this.Edicao)
                    MessageBox.Show("Erro ao atualizar cliente !\nVerifique se algum campo não foi devidamente preenchido !", "Erro de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Erro ao adicionar cliente !\nVerifique se algum campo não foi devidamente preenchido !", "Erro de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void botCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
               
        private void botLimpar_Click_1(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void LimparForm()
        {
            //esvaziando os forms
            nomeFuncionario.Clear();
            funcaoFuncionario.Text = "";
            rgFuncionario.Clear();
            cpfFuncionario.Clear();
            logradouroFuncionario.Clear();
            numeroEndFuncionario.Clear();
            bairroFuncionario.Clear();
            cidadeFuncionario.Clear();
            estadoFuncionario.Clear();
            telefone1Funcionario.Clear();
            telefone2Funcionario.Clear();

            //repintando os labels
            labelNome.ForeColor = Color.Black;
            labelCPF.ForeColor = Color.Black;
            labelLog.ForeColor = Color.Black;
            labelBairro.ForeColor = Color.Black;
            labelNum.ForeColor = Color.Black;
            labelCidade.ForeColor = Color.Black;
            labelEstado.ForeColor = Color.Black;
            labelTel1.ForeColor = Color.Black;
            labelTel2.ForeColor = Color.Black;
        }

        private bool FormsOk()
        {
            bool FormFaltando = false;

            //conferindo se os formularios obrigatorios foram preenchidos

            if (nomeFuncionario.Text == "")
            {
                labelNome.ForeColor = Color.Red;
                FormFaltando = true;

            }

            switch (funcaoFuncionario.Text)
            {               
                case "Administrador": break;
                case "Gerente": break;
                case "Técnico": break;
                case "Vendedor": break;
                default:
                {
                    labelFuncao.ForeColor = Color.Red;
                    FormFaltando = true;
                    break;
                } 

            }

            if (logradouroFuncionario.Text == "")
            {
                labelLog.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (bairroFuncionario.Text == "")
            {
                labelBairro.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (numeroEndFuncionario.Text == "")
            {
                labelNum.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (cidadeFuncionario.Text == "")
            {
                labelCidade.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (estadoFuncionario.Text == "")
            {
                labelEstado.ForeColor = Color.Red;
                FormFaltando = true;

            }

            //confirmando se os formularios não obrigatorios foram devidamente preenchidos

            if (!cpfFuncionario.MaskCompleted) // caso a mascara nao esteja completamente preenchida
            {
                cpfFuncionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (cpfFuncionario.Text != string.Empty) //caso haja caracteres
                {   //significa que o CPF esta incompleto

                    labelCPF.ForeColor = Color.Red;
                    FormFaltando = true;

                }

                //devolve a mascara
                cpfFuncionario.Mask = "000,000,000-00";

            }

            if (!telefone1Funcionario.MaskCompleted)
            {
                labelTel1.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (!telefone2Funcionario.MaskCompleted)
            {
                telefone2Funcionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (telefone2Funcionario.Text != string.Empty)
                {

                    labelTel2.ForeColor = Color.Red;
                    FormFaltando = true;

                }

                telefone2Funcionario.Mask = "(00)0000-0000";

            }

            return (FormFaltando) ? false : true;

        }
             
        private void nomeFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelNome.ForeColor == Color.Red)
                labelNome.ForeColor = Color.Black;
        }

        private void funcaoFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelFuncao.ForeColor == Color.Red)
                labelFuncao.ForeColor = Color.Black;
        }

        private void logradouroFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelLog.ForeColor == Color.Red)
                labelLog.ForeColor = Color.Black;
        }

        private void bairroFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelBairro.ForeColor == Color.Red)
                labelBairro.ForeColor = Color.Black;
        }

        private void numeroEndFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelNum.ForeColor == Color.Red)
                labelNum.ForeColor = Color.Black;
        }

        private void cidadeFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelCidade.ForeColor == Color.Red)
                labelCidade.ForeColor = Color.Black;
        }

        private void estadoFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelEstado.ForeColor == Color.Red)
                labelEstado.ForeColor = Color.Black;
        }


        private void cpfFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (labelCPF.ForeColor == Color.Red)
            {
                if (cpfFuncionario.MaskCompleted)
                    labelCPF.ForeColor = Color.Black;

                cpfFuncionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (cpfFuncionario.Text == string.Empty)
                {
                    labelCPF.ForeColor = Color.Black;
                }

                telefone1Funcionario.Mask = "(00)0000-0000";

            }
        }

        private void telefone1Funcionario_TextChanged(object sender, EventArgs e)
        {
            if (labelTel1.ForeColor == Color.Red)
            {
                if (telefone1Funcionario.MaskCompleted)
                    labelTel1.ForeColor = Color.Black;

                telefone1Funcionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (telefone1Funcionario.Text == string.Empty)
                {
                    labelTel1.ForeColor = Color.Black;
                }

                telefone1Funcionario.Mask = "(00)0000-0000";

            }
        }

        private void telefone2Funcionario_TextChanged(object sender, EventArgs e)
        {
            if (labelTel2.ForeColor == Color.Red)
            {
                if (telefone2Funcionario.MaskCompleted)
                    labelTel2.ForeColor = Color.Black;

                telefone2Funcionario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (telefone2Funcionario.Text == string.Empty)
                {
                    labelTel2.ForeColor = Color.Black;
                }

                telefone2Funcionario.Mask = "(00)0000-0000";

            }
        }


    }
}
