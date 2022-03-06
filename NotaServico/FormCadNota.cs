using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistencia_Técnica
{
    public partial class FormCadNota : Form
    {

        private bool Edicao = false;
        private DataGridViewRow OS = null;

        //instanciando as classes
        Pessoa cliente = new Pessoa();
        Endereco endCli = new Endereco();
        Contato conCli = new Contato();

        Funcionario funcionario = new Funcionario();
        Endereco endFun = new Endereco();
        Contato conFun = new Contato();

        DataTable tabelaNota = new DataTable();

        List<Produto> produtos = new List<Produto>();
        List<Servico> servicos = new List<Servico>();

        public FormCadNota(bool Edicao, DataGridViewRow OS)
        {
            InitializeComponent();

            if (Edicao)
            {
                this.Edicao = true;
                this.OS = OS;
            }

        }

        private void FormCadOS_Load(object sender, EventArgs e)
        {
            //inicializando a DataTable
            tabelaNota.Columns.Add("Tipo");
            tabelaNota.Columns.Add("ID");
            tabelaNota.Columns.Add("Descricao");
            tabelaNota.Columns.Add("Quantidade");
            tabelaNota.Columns.Add("Estoque");
            tabelaNota.Columns.Add("Preco");
            tabelaNota.Columns.Add("PrecoTotal");

            dataGridOS.DataSource = tabelaNota;

            if (Edicao)
            {





            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataEntrada.Text = DateTime.Now.ToString();
            }
            else
            {
                dataEntrada.Clear();
            }
        }

        private void nomeCliente_Enter(object sender, EventArgs e)
        {
            //carregando os nomes dos clientes da base de dados

            if (nomeCliente.Items.Count <= 0)
            {
                MySqlConexao conexaoDB = new MySqlConexao();
                List<string> nomes = conexaoDB.obterNomesClientesDB();

                foreach (string nome in nomes)
                {
                    nomeCliente.Items.Add(nome);
                }

            }

        }

        private void nomeCliente_TextChanged(object sender, EventArgs e)
        {
            if (nomeCliente.Text == "")
                LimparCliente();
        }
        private void nomeCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nomeCliente.SelectedItem.ToString() != string.Empty)
            {
                LimparCliente();
                //obtendo os dados do cliente do banco de dados
                MySqlConexao conexaoDB = new MySqlConexao();

                conexaoDB.ClienteNota(nomeCliente.SelectedItem.ToString(), ref cliente, ref endCli, ref conCli);
                nomeCliente.Text = cliente.Nome;
                labelNomeCli.ForeColor= Color.Black;
                
                rgCliente.Text = cliente.RG;
                rgCliente.BackColor = Color.LightGray;

                cpfCliente.Text = cliente.CPF;
                cpfCliente.BackColor = Color.LightGray;

                //inicializando os valores das text boxes com os dados do cliente selecionado
                logCli.Text = endCli.Logradouro;
                logCli.BackColor = Color.LightGray;

                numCli.Text = endCli.Numero;
                numCli.BackColor = Color.LightGray;

                bairroCli.Text = endCli.Bairro;
                bairroCli.BackColor = Color.LightGray;

                cidCli.Text = endCli.Cidade;
                cidCli.BackColor = Color.LightGray;

                estadoCli.Text = endCli.Estado;
                estadoCli.BackColor = Color.LightGray;
            }
            else
            {
                MessageBox.Show("Erro ! Cliente não selecionado", "Erro de seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void nomeFun_Enter(object sender, EventArgs e)
        {
            if (nomeFun.Items.Count <= 0)
            {
                //carregando os nomes dos clientes da base de dados
                MySqlConexao conexaoDB = new MySqlConexao();
                List<string> nomes = conexaoDB.obterNomesFuncionariosDB();

                foreach (string nome in nomes)
                {
                    nomeFun.Items.Add(nome);
                }

            }
        }

        private void nomeFun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nomeFun.SelectedItem.ToString() != string.Empty)
            {
                
                LimparFuncionario();
                
                //obtendo os dados do cliente do banco de dados
                MySqlConexao conexaoDB = new MySqlConexao();
                conexaoDB.FuncionariosNota(nomeFun.SelectedItem.ToString(), ref funcionario, ref endFun, ref conFun);
                
                labelNomeFun.ForeColor = Color.Black;
                
                nomeFun.Text = funcionario.Nome;
                rgFun.Text = funcionario.RG;
                rgFun.BackColor = Color.LightGray;

                cpfFun.Text = funcionario.CPF;
                cpfFun.BackColor = Color.LightGray;

                funcao.Text = funcionario.Funcao;
                funcao.BackColor = Color.LightGray;

                //inicializando os valores das text boxes com os dados do cliente selecionado
                logFun.Text = endFun.Logradouro;
                logFun.BackColor = Color.LightGray;

                numFun.Text = endFun.Numero;
                numFun.BackColor = Color.LightGray;

                bairroFun.Text = endFun.Bairro;
                bairroFun.BackColor = Color.LightGray;

                cidFun.Text = endFun.Cidade;
                cidFun.BackColor = Color.LightGray;

                estFun.Text = endFun.Estado;
                estFun.BackColor = Color.LightGray;
            }
            else
            {
                MessageBox.Show("Erro ! Funcionário não selecionado", "Erro de seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormGerenClientes menuClientes = new FormGerenClientes(true, this);
            menuClientes.ShowDialog();

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormGerenFuncionarios menuFuncionarios = new FormGerenFuncionarios(true, this);
            menuFuncionarios.ShowDialog();
        }

        public void dadosOS(DataGridViewRow dados, string tipo)
        {
            switch (tipo)
            {
                case "cliente":
                    {
                        LimparCliente();

                        cliente.ID = (int)dados.Cells["ID"].Value;
                        //atribuindo dados nas text box
                        
                        MySqlConexao conexaoDB = new MySqlConexao();

                        conexaoDB.ClienteNota(dados.Cells["Nome"].Value.ToString(), ref cliente, ref endCli, ref conCli);
                        nomeCliente.Text = cliente.Nome;
                        rgCliente.Text = cliente.RG;
                        rgCliente.BackColor = Color.LightGray;

                        cpfCliente.Text = cliente.CPF;
                        cpfCliente.BackColor = Color.LightGray;

                        //inicializando os valores das text boxes com os dados do cliente selecionado
                        logCli.Text = endCli.Logradouro;
                        logCli.BackColor = Color.LightGray;

                        numCli.Text = endCli.Numero;
                        numCli.BackColor = Color.LightGray;

                        bairroCli.Text = endCli.Bairro;
                        bairroCli.BackColor = Color.LightGray;

                        cidCli.Text = endCli.Cidade;
                        cidCli.BackColor = Color.LightGray;

                        estadoCli.Text = endCli.Estado;
                        estadoCli.BackColor = Color.LightGray;

                        break;
                    }

                case "funcionario":
                    {
                        funcionario.ID = (int)dados.Cells["ID"].Value;
                                            
                        //obtendo os dados do funcionario do banco de dados
                        MySqlConexao conexaoDB = new MySqlConexao();
                        conexaoDB.FuncionariosNota(dados.Cells["Nome"].Value.ToString(), ref funcionario, ref endFun, ref conFun);

                        nomeFun.Text = funcionario.Nome;
                        rgFun.Text = funcionario.RG;
                        rgFun.BackColor = Color.LightGray;

                        cpfFun.Text = funcionario.CPF;
                        cpfFun.BackColor = Color.LightGray;

                        funcao.Text = funcionario.Funcao;
                        funcao.BackColor = Color.LightGray;

                        //inicializando os valores das text boxes com os dados do funcionario selecionado
                        logFun.Text = endFun.Logradouro;
                        logFun.BackColor = Color.LightGray;

                        numFun.Text = endFun.Numero;
                        numFun.BackColor = Color.LightGray;

                        bairroFun.Text = endFun.Bairro;
                        bairroFun.BackColor = Color.LightGray;

                        cidFun.Text = endFun.Cidade;
                        cidFun.BackColor = Color.LightGray;

                        estFun.Text = endFun.Estado;
                        estFun.BackColor = Color.LightGray;
                        break;
                    }

                case "produto":
                    {
                        Produto novo = new Produto();
                        novo.ID = Convert.ToInt32(dados.Cells["ID"].Value.ToString());
                        novo.Estoque = Convert.ToInt32(dados.Cells["Estoque"].Value.ToString());
                        novo.Quantidade = 1;
                        novo.Descricao = dados.Cells["Descrição"].Value.ToString();
                        novo.Preco = Convert.ToDecimal(dados.Cells["Preco"].Value.ToString().Replace("R$ ", ""));

                        foreach (Produto produto in produtos)
                        {
                            if (produto.ID == novo.ID) //produto ja foi add
                            {
                                MessageBox.Show("Produto já adicionado !", "Novo Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                        }

                        //adiciona na lista
                        produtos.Add(novo);
                        DataRow linhaProduto = tabelaNota.NewRow();

                        linhaProduto["Tipo"] = "P";
                        linhaProduto["ID"] = novo.ID;
                        linhaProduto["Descricao"] = novo.Descricao;
                        linhaProduto["Quantidade"] = novo.Quantidade;
                        linhaProduto["Estoque"] = novo.Estoque;
                        linhaProduto["Preco"] = dados.Cells["Preco"].Value.ToString();
                        linhaProduto["PrecoTotal"] = (novo.Preco * novo.Quantidade).ToString("C");

                        tabelaNota.Rows.Add(linhaProduto);
                        attPrecoOS();
                        break;
                    }

                case "servico":
                    {
                        Servico novo = new Servico();
                        novo.ID = Convert.ToInt32(dados.Cells["ID"].Value.ToString());
                        novo.Quantidade = 1;
                        novo.Descricao = dados.Cells["Descrição"].Value.ToString();
                        novo.Preco = Convert.ToDecimal(dados.Cells["Preco"].Value.ToString().Replace("R$ ", ""));

                        foreach (Servico servico in servicos)
                        {
                            if (servico.ID == novo.ID) //serviço ja foi add
                            {
                                MessageBox.Show("Serviço já adicionado !", "Novo Serviço", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                        }

                        //adiciona na lista
                        servicos.Add(novo);
                        DataRow linhaServico = tabelaNota.NewRow();

                        linhaServico["Tipo"] = "S";
                        linhaServico["ID"] = novo.ID;
                        linhaServico["Descricao"] = novo.Descricao;
                        linhaServico["Quantidade"] = novo.Quantidade;
                        linhaServico["Estoque"] = "∞";
                        linhaServico["Preco"] = dados.Cells["Preco"].Value.ToString();
                        linhaServico["PrecoTotal"] = (novo.Preco * novo.Quantidade).ToString("C");

                        tabelaNota.Rows.Add(linhaServico);
                        attPrecoOS();
                        break;
                    }

            }

        }

        private void LimparCliente()
        {
            labelNomeCli.ForeColor = Color.Black;
            //limpando o objeto funcionario
            cliente.ID = 0;
            cliente.Nome = cliente.CPF = cliente.RG = "";

            //limpando os dados pessoais
            nomeCliente.Text = "";
            rgCliente.Clear();
            cpfCliente.Clear();

            //limpando o objeto de endereço
            endCli.Logradouro = endCli.Numero = endCli.Bairro = endCli.Cidade = endCli.Estado = "";

            //limpando os formularios de endereço
            logCli.Clear();
            numCli.Clear();
            bairroCli.Clear();
            estadoCli.Clear();
            cidCli.Clear();

            //limpando o objeto de contato
            conCli.Contato1 = conCli.Contato2 = "";

        }

        private void LimparFuncionario()
        {
            labelNomeFun.ForeColor = Color.Black;
            //limpando o objeto funcionario
            funcionario.ID = 0;
            funcionario.Nome = funcionario.CPF = funcionario.RG = funcionario.Funcao = "";

            //limpando os dados pessoais
            nomeFun.Text = "";
            rgFun.Clear();
            cpfFun.Clear();
            funcao.Clear();

            //limpando o objeto de endereço
            endFun.Logradouro = endFun.Numero = endFun.Bairro = endFun.Cidade = endFun.Estado = "";

            //limpando os formularios de endereço
            logFun.Clear();
            rgFun.Clear();
            numFun.Clear();
            bairroFun.Clear();
            estFun.Clear();
            cidFun.Clear();

            //limpando o objeto de contato
            conFun.Contato1 = conFun.Contato2 = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormGerenProdutos menuProdutos = new FormGerenProdutos(true, this);
            menuProdutos.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormGerenServicos menuProdutos = new FormGerenServicos(true, this);
            menuProdutos.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimparCliente();
        }

        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            LimparFuncionario();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FormsOk())
            {
                FormPrintNota impressaoNota = new FormPrintNota(cliente,endCli,conCli,funcionario,
                    endFun,conFun, tabelaNota, dataEntrada.Text,dataSaida.Text,descontoRS.Text,
                    descontoPorc.Text,acrescimoRS.Text,acrescimoPorc.Text,valorOS.Text,observacoes.Text,this);
                impressaoNota.ShowDialog();
               
            }
            else
            {
                MessageBox.Show("Erro ! Verifique se todos os campos foram preenchidos !", "Erro de Formulário", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridOS.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0)
            {

                if (e.ColumnIndex == dataGridOS.Columns["Editar"].Index)
                {//clicou no botao de editar

                    DataGridViewRow linha = dataGridOS.Rows[e.RowIndex];
                    string tipo = linha.Cells["Tipo"].Value.ToString();

                    if(tipo == "P")
                    { //é um produto
                        FormCadProdutos editarOS = new FormCadProdutos(false, linha, true, this);
                        editarOS.ShowDialog();
                    }
                    else
                    { // é um serviço
                        FormCadServicos editarOS = new FormCadServicos(false, linha, true, this);
                        editarOS.ShowDialog();

                    }
                    attPrecoOS();
                }

                if (e.ColumnIndex == dataGridOS.Columns["Excluir"].Index)
                { //clicou no botao de excluir

                    if (MessageBox.Show("Tem certeza de que deseja excluir ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //pega o indice da linha a ser removida
                        DataRow linha = tabelaNota.Rows[e.RowIndex];

                        //resguarda os dados para verificações posteriores
                        string tipo = linha["Tipo"].ToString();
                        int ID = Convert.ToInt32(linha["ID"].ToString());

                        //remove do DataTable
                        tabelaNota.Rows.Remove(linha);
                        
                        if(tipo == "P") //é um produto
                        {                          
                            int i = 0;
                            foreach(Produto produto in produtos) //procura o produto na lista
                            {
                                if(produto.ID == ID) //remover quando
                                {                    //os IDs coincidirem
                                    produtos.RemoveAt(i);
                                    attPrecoOS();
                                    return;
                                }
                                i++;
                            }
                        }
                        else // é um serviço
                        {
                            int i = 0;
                            foreach (Servico servico in servicos) //procura o serviço na lista
                            {
                                if (servico.ID == ID) //remover quando
                                {                     //os IDs coincidirem
                                    servicos.RemoveAt(i);
                                    attPrecoOS();
                                    return;
                                }
                                i++;
                            }
                        }

                        
                    }

                }

            }

        }

        public void attProduto(int ID,Produto novo)
        {
            //atualiza a tabela
            foreach(DataRow linha in tabelaNota.Rows)
            {
                if(Convert.ToInt32(linha["ID"].ToString()) == ID)
                {
                    linha["Preco"] = novo.Preco.ToString("C");
                    linha["Quantidade"] = novo.Quantidade;
                    linha["PrecoTotal"] = (novo.Preco * novo.Quantidade).ToString("C");
                    break;
                }

            }
            //atualiza o objeto na lista
            foreach(Produto produto in produtos)
            {
                if(produto.ID == ID)
                {
                    produto.Preco = novo.Preco;
                    produto.Quantidade = novo.Quantidade;
                    return;
                }

            }

            attPrecoOS();
            
        }    
        public void attServico(int ID,Servico novo)
        {
            //atualiza a tabela
            foreach(DataRow linha in tabelaNota.Rows)
            {
                if(Convert.ToInt32(linha["ID"].ToString()) == ID)
                {
                    linha["Preco"] = novo.Preco.ToString("C");
                    linha["Quantidade"] = novo.Quantidade;
                    linha["PrecoTotal"] = (novo.Preco * novo.Quantidade).ToString("C");
                    break;
                }

            }
            //atualiza o objeto na lista
            foreach(Servico servico in servicos)
            {
                if(servico.ID == ID)
                {
                    servico.Preco = novo.Preco;
                    servico.Quantidade = novo.Quantidade;
                    return;
                }

            }

            attPrecoOS();
        }
        private void attPrecoOS()
        {
            decimal PrecoTotal = 0;

            foreach (DataRow linha in tabelaNota.Rows)
            {
                PrecoTotal += Convert.ToDecimal(linha["PrecoTotal"].ToString().Replace("R$ ", "")); 

            }

            if(descontoRS.BackColor == Color.White)
            {
                if(descontoRS.Text != "R$ 0,00")
                {
                    PrecoTotal -= Convert.ToDecimal(descontoRS.Text.Replace("R$ ", ""));
                }

            }

            if (descontoPorc.BackColor == Color.White)
            {               
                if (descontoPorc.Text != "")
                {
                    decimal desconto = 0;
                    desconto = (Convert.ToInt32(descontoPorc.Text.Replace("%", "")) * PrecoTotal) / 100;
                    PrecoTotal -= desconto;
                }
                
            }

            if (acrescimoRS.BackColor == Color.White)
            {
                if (acrescimoRS.Text != "R$ 0,00")
                {
                    PrecoTotal += Convert.ToDecimal(acrescimoRS.Text.Replace("R$ ",""));
                }

            }

            if (acrescimoPorc.BackColor == Color.White)
            {
                if (acrescimoPorc.Text != "")
                {
                    decimal acrescimo = 0;
                    acrescimo = (Convert.ToInt32(acrescimoPorc.Text.Replace("%", "")) * PrecoTotal) / 100;
                    PrecoTotal += acrescimo;
                }

            }

            valorOS.Text = PrecoTotal.ToString("C");

        }
        string valor;
     
        private void verificarDigito(KeyPressEventArgs e, TextBox preco)
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

        private void formatarPreco(TextBox preco)
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

        private void descontoRS_Leave(object sender, EventArgs e)
        {
            if(descontoRS.BackColor != Color.LightGray)
            {
                if (descontoRS.Text == "R$ 0,00")
                {
                    descontoRS.ReadOnly = true;
                    descontoPorc.BackColor = Color.White;
                    acrescimoRS.BackColor = Color.White;
                    acrescimoPorc.BackColor = Color.White;
                  
                }
                else
                {
                    valor = descontoRS.Text.Replace("R$", "");
                    descontoRS.Text = string.Format("{0:C}", Convert.ToDouble(valor));
                   
                }

            }
            attPrecoOS();
        }

        private void descontoRS_KeyPress(object sender, KeyPressEventArgs e)
        {
            verificarDigito(e,descontoRS);
        }

        private void descontoRS_KeyUp(object sender, KeyEventArgs e)
        {
            formatarPreco(descontoRS);
        }

        private void descontoRS_Click(object sender, EventArgs e)
        {
            if (descontoRS.BackColor != Color.LightGray)
            {
                if (descontoRS.Text == "R$ 0,00")
                {
                    descontoRS.ReadOnly = false;

                    descontoPorc.BackColor = Color.LightGray;
                    acrescimoRS.BackColor = Color.LightGray;
                    acrescimoPorc.BackColor = Color.LightGray;
                    
                }

            }
                        
        }

        private void descontoPorc_Leave(object sender, EventArgs e)
        {
            if(descontoPorc.BackColor != Color.LightGray)
            {
                if (descontoPorc.Text == "")
                {
                    descontoPorc.ReadOnly = true;
                    descontoRS.BackColor = Color.White;
                    acrescimoRS.BackColor = Color.White;
                    acrescimoPorc.BackColor = Color.White;
                   
                }
                else
                {
                    if (!descontoPorc.Text.Contains("%"))
                    {
                        descontoPorc.Text += "%";

                    }
                 
                   
                }

            }
            attPrecoOS();
        }

        private void descontoPorc_Click(object sender, EventArgs e)
        {
            if(descontoPorc.BackColor != Color.LightGray)
            {
                if (descontoPorc.Text == "")
                {
                    descontoPorc.ReadOnly = false;
                    
                    descontoRS.BackColor = Color.LightGray;
                    acrescimoRS.BackColor = Color.LightGray;
                    acrescimoPorc.BackColor = Color.LightGray;
                   
                }

            }
        }

        private void descontoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
                e.Handled = true;
           
        }

        private void acrescimoRS_Click(object sender, EventArgs e)
        {
            
            if (acrescimoRS.BackColor != Color.LightGray)
            {
                if (acrescimoRS.Text == "R$ 0,00")
                {
                    acrescimoRS.ReadOnly = false;
                    
                    descontoRS.BackColor = Color.LightGray;
                    descontoPorc.BackColor = Color.LightGray;
                    acrescimoPorc.BackColor = Color.LightGray;
                    
                }

            }
        }

        private void acrescimoRS_KeyPress(object sender, KeyPressEventArgs e)
        {
            verificarDigito(e,acrescimoRS);
        }

        private void acrescimoRS_KeyUp(object sender, KeyEventArgs e)
        {
            formatarPreco(acrescimoRS);
        }

        private void acrescimoRS_Leave(object sender, EventArgs e)
        {
            if(acrescimoRS.BackColor != Color.LightGray)
            {
                if (acrescimoRS.Text == "R$ 0,00")
                {
                    acrescimoRS.ReadOnly = true;

                    descontoRS.BackColor = Color.White;
                    descontoPorc.BackColor = Color.White;
                    acrescimoPorc.BackColor = Color.White;
                    
                }
                else
                {
                    valor = descontoRS.Text.Replace("R$", "");
                    descontoRS.Text = string.Format("{0:C}", Convert.ToDouble(valor));
                    
                }

            }
            attPrecoOS();
        }

        private void acrescimoPorc_Click(object sender, EventArgs e)
        {
            if (acrescimoPorc.BackColor != Color.LightGray)
            {
                if (acrescimoPorc.Text == "")
                {
                    acrescimoPorc.ReadOnly = false;
                    descontoRS.BackColor = Color.LightGray;
                    acrescimoRS.BackColor = Color.LightGray;
                    descontoPorc.BackColor = Color.LightGray;
                    
                }

            }
        }

        private void acrescimoPorc_Leave(object sender, EventArgs e)
        {
            if(acrescimoPorc.BackColor != Color.LightGray)
            {
                if (acrescimoPorc.Text == "")
                {
                    acrescimoPorc.ReadOnly = true;
                    descontoRS.BackColor = Color.White;
                    acrescimoRS.BackColor = Color.White;
                    descontoPorc.BackColor = Color.White;
                    
                }
                else
                {
                    if (!acrescimoPorc.Text.Contains("%"))
                    {
                        acrescimoPorc.Text += "%";
                    }

                    
                }

            }
            attPrecoOS();
        }

        private void acrescimoPorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
                e.Handled = true;
        }

        private void descontoPorc_KeyUp(object sender, KeyEventArgs e)
        {
            if (descontoPorc.Text.Contains("%"))
            {
                if (Convert.ToInt32(descontoPorc.Text.Replace("%", "")) > 100) //nao é possível ter um desconto maior que 100%
                    descontoPorc.Text = "100%";

            }
            else
            {
                if(descontoPorc.Text != "")
                {
                    if (Convert.ToInt32(descontoPorc.Text) > 100) //nao é possível ter um desconto maior que 100%
                        descontoPorc.Text = "100";

                }

            }

        }

        private bool FormsOk()
        {
            bool FormFaltando = false;

            //verificação das datas
            DateTime DataEntrada;
            if (!DateTime.TryParseExact(dataEntrada.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DataEntrada))
            { 
                MessageBox.Show("Data de entrada inválida !\n Insira uma data válida", "Verificação Data de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelDataEntrada.ForeColor = Color.Red;
                FormFaltando = true;
            }
                   

            if(nomeCliente.Text == "")
            {
                labelNomeCli.ForeColor = Color.Red;
                FormFaltando = true;
            } 
            
            if(nomeFun.Text == "")
            {
                labelNomeFun.ForeColor = Color.Red;
                FormFaltando = true;
            }

            if(tabelaNota.Rows.Count == 0)
            {
                MessageBox.Show("Insira pelo menos um produto !", "Tabela Vazia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormFaltando = true;
            }



            return (FormFaltando) ? false : true;
        }

        private void dataEntrada_Validated(object sender, EventArgs e)
        {
            DateTime DataEntrada;
            
            if(dataEntrada.MaskCompleted)
            {
                if (!DateTime.TryParseExact(dataEntrada.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DataEntrada))
                {
                    labelDataEntrada.ForeColor = Color.Red;
                    MessageBox.Show("Data de entrada inválida !\n Insira uma data válida", "Verificação Data de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                labelDataEntrada.ForeColor = Color.Black;
            }
            
        }
        
        /*
        private void dataSaida_Validated(object sender, EventArgs e)
        {
            //verificação das datas
            DateTime DataEntrada, DataSaida;

            if (dataEntrada.MaskCompleted)
            {
                if (!DateTime.TryParseExact(dataEntrada.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DataEntrada))
                {
                    labelDataEntrada.ForeColor = Color.Red;
                    MessageBox.Show("Data de entrada inválida !\n Insira uma data válida", "Verificação Data de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }else
                    labelDataEntrada.ForeColor = Color.Black;

                if (dataSaida.MaskCompleted)
                {
                    if (!DateTime.TryParseExact(dataSaida.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DataSaida))
                    {
                        labelDataSaida.ForeColor = Color.Red;
                        MessageBox.Show("Data de saída inválida !\n Insira uma data válida", "Verificação Data de Saída", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }                    
                    else
                    {
                        if (DataSaida < DataEntrada)
                        {
                            labelDataSaida.ForeColor = Color.Red;
                            MessageBox.Show("Data de saída menor que a data de entrada !\n Insira uma data de saída válida", "Verificação Data de Saída", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }else
                            labelDataSaida.ForeColor = Color.Black;
                    }
                    labelDataEntrada.ForeColor = Color.Black;

                }
                              

            }
           
        }
        */

    }

}
