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
    public partial class CadastroCliente : Form
    {
        private bool Edicao = false;
        private int IdEdit = -1;
        private int IdEnd = -1;
        private int IdCont = -1;
        private Pessoa cliente = new Pessoa();
        private Endereco endereco = new Endereco();
        private Contato contato = new Contato();

        public CadastroCliente(bool Edicao, DataGridViewRow cliente)
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
                nomeCliente.Text = cliente.Cells["Nome"].Value.ToString();
                rgCliente.Text = cliente.Cells["RG"].Value.ToString();
                cpfCliente.Text = cliente.Cells["CPF"].Value.ToString();

                //obtendo o endereço              
                endereco = obterEndereco(cliente.Cells["Endereço"].Value.ToString());
                logradouroCliente.Text = endereco.Logradouro;
                numeroEndCliente.Text = endereco.Numero;
                bairroCliente.Text = endereco.Bairro;
                cidadeCliente.Text = endereco.Cidade;
                estadoCliente.Text = endereco.Estado;

                //obtendo os telefones

                contato = obterContato(cliente.Cells["Contato"].Value.ToString());
                telefone1Cliente.Text = contato.Contato1;
                telefone2Cliente.Text = contato.Contato2;

            }

        }
        private void botaoAdd_Click_1(object sender, EventArgs e)
        {

            if (FormsOk())
            {
                MySqlConexao clienteDB = new MySqlConexao();

                //obtendo dados pessoais do cliente
                cliente.Nome = nomeCliente.Text;
                cliente.RG = rgCliente.Text;
                           
                //obtendo endereço
                endereco.Logradouro = logradouroCliente.Text;
                endereco.Numero = numeroEndCliente.Text;
                endereco.Bairro = bairroCliente.Text;
                endereco.Cidade = cidadeCliente.Text;
                endereco.Estado = estadoCliente.Text;

                //obtendo contato principal
                telefone1Cliente.TextMaskFormat = MaskFormat.IncludeLiterals;
                contato.Contato1 = telefone1Cliente.Text;

                //Verificação do CPF
                //caso o CPF nao tenha sido preenchido
                cpfCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (cpfCliente.Text == string.Empty)
                    cliente.CPF = "";
                else
                {
                    cpfCliente.Mask = "000,000,000-00";
                    cpfCliente.TextMaskFormat = MaskFormat.IncludeLiterals;
                    cliente.CPF = cpfCliente.Text;
                }

                //caso o contato2 nao tenha sido preenchido
                telefone2Cliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (telefone2Cliente.Text == string.Empty)
                    contato.Contato2 = "";
                else
                {
                    telefone2Cliente.Mask = "(00)0000-0000";
                    telefone2Cliente.TextMaskFormat = MaskFormat.IncludeLiterals;
                    contato.Contato2 = telefone2Cliente.Text;
                }
                            

                if (this.Edicao)
                    clienteDB.attCliente(this.IdEdit, this.IdEnd, this.IdCont, cliente, endereco, contato);
                else
                    clienteDB.addCliente(cliente, endereco, contato);

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

        private void botLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LimparForm()
        {
            //esvaziando o form
            nomeCliente.Clear();
            rgCliente.Clear();
            cpfCliente.Clear();
            logradouroCliente.Clear();
            numeroEndCliente.Clear();
            bairroCliente.Clear();
            cidadeCliente.Clear();
            estadoCliente.Clear();
            telefone1Cliente.Clear();
            telefone2Cliente.Clear();

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

            if (nomeCliente.Text == "")
            {
                labelNome.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (logradouroCliente.Text == "")
            {
                labelLog.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (bairroCliente.Text == "")
            {
                labelBairro.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (numeroEndCliente.Text == "")
            {
                labelNum.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (cidadeCliente.Text == "")
            {
                labelCidade.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (estadoCliente.Text == "")
            {
                labelEstado.ForeColor = Color.Red;
                FormFaltando = true;

            }

            //confirmando se os formularios não obrigatorios foram devidamente preenchidos

            if (!cpfCliente.MaskCompleted) // caso a mascara nao esteja completamente preenchida
            {
                cpfCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (cpfCliente.Text != string.Empty) //caso haja caracteres
                {   //significa que o CPF esta incompleto

                    labelCPF.ForeColor = Color.Red;
                    FormFaltando = true;

                }

                //devolve a mascara
                cpfCliente.Mask = "000,000,000-00";

            }

            if (!telefone1Cliente.MaskCompleted)
            {
                labelTel1.ForeColor = Color.Red;
                FormFaltando = true;

            }

            if (!telefone2Cliente.MaskCompleted)
            {
                telefone2Cliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (telefone2Cliente.Text != string.Empty)
                {

                    labelTel2.ForeColor = Color.Red;
                    FormFaltando = true;

                }

                telefone2Cliente.Mask = "(00)0000-0000";

            }

            return (FormFaltando) ? false : true;

        }

        public Endereco obterEndereco(string endereco)
        {

            Endereco end = new Endereco();
            int posChar = 0;


            for (int i = 0; i < endereco.Length; i++) //obtendo rua/avenida
            {
                if (endereco[i] == '-')
                {
                    posChar = i;
                    break;

                }
                else
                    end.Logradouro += endereco[i];

            }

            for (int i = posChar + 9; i < endereco.Length; i++) //obtendo numero
            {
                if (endereco[i] == '\n')
                {
                    posChar = i;
                    break;
                }
                else if (endereco[i] != '\r')
                    end.Numero += endereco[i];
            }

            for (int i = posChar + 8; i < endereco.Length; i++) //obtendo bairro
            {
                if (endereco[i] == '-')
                {
                    posChar = i;
                    break;
                }
                else
                    end.Bairro += endereco[i];

            }
            for (int i = posChar + 2; i < endereco.Length; i++)
            {
                if (endereco[i] == '/')
                {
                    posChar = i;
                    break;
                }
                else
                    end.Cidade += endereco[i];

            }

            for (int i = posChar + 1; i < endereco.Length; i++)
            {
                end.Estado += endereco[i];

            }

            return end;
        }

        public Contato obterContato(string contato)
        {
            Contato contatoCliente = new Contato();
            int posChar = 0;

            for (int i = 0; i < contato.Length; i++)
            {
                if (contato[i] == '\n')
                {
                    posChar = i;
                    break;
                }
                else
                    contatoCliente.Contato1 += contato[i];

            }

            for (int i = posChar + 1; i < contato.Length; i++)
            {
                contatoCliente.Contato2 += contato[i];

            }

            return contatoCliente;
        }

        private void nomeCliente_TextChanged(object sender, EventArgs e)
        {
            if (labelNome.ForeColor == Color.Red)
                labelNome.ForeColor = Color.Black;
        }
        private void logradouroCliente_TextChanged(object sender, EventArgs e)
        {

            if (labelLog.ForeColor == Color.Red)
                labelLog.ForeColor = Color.Black;

        }

        private void numeroEndCliente_TextChanged(object sender, EventArgs e)
        {
            if (labelNum.ForeColor == Color.Red)
                labelNum.ForeColor = Color.Black;
        }

        private void bairroCliente_TextChanged(object sender, EventArgs e)
        {
            if (labelBairro.ForeColor == Color.Red)
                labelBairro.ForeColor = Color.Black;

        }

        private void cidadeCliente_TextChanged(object sender, EventArgs e)
        {
            if (labelCidade.ForeColor == Color.Red)
                labelCidade.ForeColor = Color.Black;
        }

        private void estadoCliente_TextChanged(object sender, EventArgs e)
        {
            if (labelEstado.ForeColor == Color.Red)
                labelEstado.ForeColor = Color.Black;
        }

        private void cpfCliente_TextChanged(object sender, EventArgs e)
        {
            if (labelCPF.ForeColor == Color.Red)
            {
                if (cpfCliente.MaskCompleted)
                    labelCPF.ForeColor = Color.Black;

                cpfCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (cpfCliente.Text == string.Empty)
                {
                    labelCPF.ForeColor = Color.Black;
                }

                telefone1Cliente.Mask = "(00)0000-0000";


            }
        }

        private void telefone1Cliente_TextChanged(object sender, EventArgs e)
        {
            if (labelTel1.ForeColor == Color.Red)
            {
                if (telefone1Cliente.MaskCompleted)
                    labelTel1.ForeColor = Color.Black;
                
                telefone1Cliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (telefone1Cliente.Text == string.Empty)
                {
                    labelTel1.ForeColor = Color.Black;
                }

                telefone1Cliente.Mask = "(00)0000-0000";


            }
        }

        private void telefone2Cliente_TextChanged(object sender, EventArgs e)
        {

            if (labelTel2.ForeColor == Color.Red)
            {
                if (telefone2Cliente.MaskCompleted)
                    labelTel2.ForeColor = Color.Black;

                telefone2Cliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (telefone2Cliente.Text == string.Empty)
                {
                    labelTel2.ForeColor = Color.Black;
                }

                telefone2Cliente.Mask = "(00)0000-0000";
               
            }
        }

    }

}
