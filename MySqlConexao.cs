using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Assistencia_Técnica
{
    public class MySqlConexao
    {

        private static MySqlConnection conexao = null;

        public static MySqlConnection ConexaoDB(String URL)
        {
            if (conexao == null)
            {
                try
                {
                    conexao = new MySqlConnection(URL);
                    conexao.Open();
                    
                    MessageBox.Show("Conexão estabelecida com sucesso!", "Conexão com o Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex)
                {
                    conexao = null;
                    MessageBox.Show("Erro ao abrir conexão com o banco de dados: " + ex.Message,"Conexão com o banco de dados",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);                 
                }
            }
            return conexao;
        }
        public static void fecharConexao()
        {
            if(conexao != null)
            {
                try 
                { 
                    conexao.Close();             
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fechar conexão com o banco de dados: " + ex.Message,"Conexão com o banco de dados",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

        }
        public static void criarDB(string URL)
        {
            MySqlDataReader leitor = null;

            if (conexao != null) 
            {
                try 
                {
                    
                    MySqlCommand comando = new MySqlCommand("", conexao);
                  
                    comando.CommandText = @"
                          
                          CREATE DATABASE IF NOT EXISTS `assistenciatecnica`; 
                          USE `assistenciatecnica`;

                          CREATE TABLE IF NOT EXISTS `Endereco` (
                          `ID_Endereco` INT NOT NULL AUTO_INCREMENT,
                          `Logradouro` VARCHAR(45) NOT NULL,
                          `Número` VARCHAR(10) NOT NULL,
                          `Bairro` VARCHAR(45) NOT NULL,
                          `Estado` VARCHAR(45) NOT NULL,
                          `Cidade` VARCHAR(45) NOT NULL,
                          PRIMARY KEY (`ID_Endereco`));
  
                          CREATE TABLE IF NOT EXISTS `Contato` (
                          `ID_Contato` INT NOT NULL AUTO_INCREMENT,
                          `Telefone` VARCHAR(45) NOT NULL,
                          `Telefone2` VARCHAR(45) NULL,
                          PRIMARY KEY (`ID_Contato`));
  
                          CREATE TABLE IF NOT EXISTS `Cliente` (
                          `ID_Cliente` INT NOT NULL AUTO_INCREMENT,
                          `Nome_Cliente` VARCHAR(127) NOT NULL,
                          `RG_Cliente` VARCHAR(45) NULL,
                          `CPF_Cliente` VARCHAR(45) NULL,
                          `ID_Endereco` INT NOT NULL,
                          `ID_Contato` INT NOT NULL,
                          PRIMARY KEY (`ID_Cliente`, `ID_Endereco`, `ID_Contato`),
                          INDEX `fk_Cliente_Endereco1_idx` (`ID_Endereco` ASC) VISIBLE,
                          INDEX `fk_Cliente_Contato1_idx` (`ID_Contato` ASC) VISIBLE,
                          CONSTRAINT `fk_Cliente_Endereco1`
                            FOREIGN KEY (`ID_Endereco`)
                            REFERENCES `Endereco` (`ID_Endereco`)
                            ON DELETE CASCADE
                            ON UPDATE CASCADE,
                          CONSTRAINT `fk_Cliente_Contato1`
                            FOREIGN KEY (`ID_Contato`)
                            REFERENCES `Contato` (`ID_Contato`)
                            ON DELETE NO ACTION
                            ON UPDATE NO ACTION);
	
                        CREATE TABLE IF NOT EXISTS `Funcionario` (
                          `ID_Funcionario` INT NOT NULL AUTO_INCREMENT,
                          `Nome_Funcionario` VARCHAR(127) NOT NULL,
                          `Função` VARCHAR(45) NOT NULL,
                          `RG_Funcionario` VARCHAR(45) NULL,
                          `CPF_Funcionario` VARCHAR(45) NULL,
                          `ID_Contato` INT NOT NULL,
                          `ID_Endereco` INT NOT NULL,
                          PRIMARY KEY (`ID_Funcionario`, `ID_Contato`, `ID_Endereco`),
                          INDEX `fk_Cliente_Contato1_idx` (`ID_Contato` ASC) VISIBLE,
                          INDEX `fk_Cliente_Endereco1_idx` (`ID_Endereco` ASC) VISIBLE,
                          CONSTRAINT `fk_Cliente_Contato10`
                            FOREIGN KEY (`ID_Contato`)
                            REFERENCES `Contato` (`ID_Contato`)
                            ON DELETE CASCADE
                            ON UPDATE CASCADE,
                          CONSTRAINT `fk_Cliente_Endereco10`
                            FOREIGN KEY (`ID_Endereco`)
                            REFERENCES `Endereco` (`ID_Endereco`)
                            ON DELETE CASCADE
                            ON UPDATE CASCADE);
	
                        CREATE TABLE IF NOT EXISTS `LoginUsuario` (
                          `ID_Login` INT NOT NULL AUTO_INCREMENT,
                          `ID_Funcionario_Login` INT NOT NULL,
                          `Usuario` VARCHAR(45) NOT NULL,
                          `Senha` VARCHAR(45) NOT NULL,
                          `Tipo` VARCHAR(45) NOT NULL COMMENT 'Tipo de usuário, administrador,vendedor, gerente',
                          PRIMARY KEY (`ID_Login`, `ID_Funcionario_Login`),
                          INDEX `fk_LoginUsuario_Funcionario1_idx` (`ID_Funcionario_Login` ASC) VISIBLE,
                          CONSTRAINT `fk_LoginUsuario_Funcionario1`
                            FOREIGN KEY (`ID_Funcionario_Login`)
                            REFERENCES `Funcionario` (`ID_Funcionario`)
                            ON DELETE NO ACTION
                            ON UPDATE NO ACTION);	
	
                        CREATE TABLE IF NOT EXISTS `Produto` (
                          `ID` INT NOT NULL AUTO_INCREMENT,
                          `Nome_Produto` VARCHAR(45) NOT NULL,
                          `Preco_Produto` DECIMAL(10,2) NOT NULL,
                          `Estoque` INT NOT NULL,
                          PRIMARY KEY (`ID`)); 
  
                        CREATE TABLE IF NOT EXISTS `Servico` (
                          `ID` INT NOT NULL AUTO_INCREMENT,
                          `Nome_Servico` VARCHAR(45) NOT NULL,
                          `Preco_Servico` DECIMAL(10,2) NOT NULL,
                          PRIMARY KEY (`ID`));
    
                        CREATE TABLE IF NOT EXISTS `Nota_Servico` (
                          `ID_Nota_Servico` INT NOT NULL AUTO_INCREMENT,
                          `Data` DATE NOT NULL,
                          `ID_Cliente` INT NOT NULL,
                          `ID_Funcionario` INT NOT NULL,
                          `Valor_Nota` DECIMAL(10,2) NOT NULL,
                          `Acrescimo` VARCHAR(20) NULL DEFAULT NULL,
                          `Desconto` VARCHAR(20) NULL DEFAULT NULL,
                          `Observacoes` MEDIUMTEXT NULL DEFAULT NULL,
                          PRIMARY KEY (`ID_Nota_Servico`),
                          INDEX `fk_Ordem_Servico_Cliente1_idx` (`ID_Cliente` ASC) VISIBLE,
                          INDEX `fk_Ordem_Servico_Funcionario1_idx` (`ID_Funcionario` ASC) VISIBLE,
                          CONSTRAINT `fk_Ordem_Servico_Cliente1`
                            FOREIGN KEY (`ID_Cliente`)
                            REFERENCES `Cliente` (`ID_Cliente`)
                            ON UPDATE CASCADE,
                          CONSTRAINT `fk_Ordem_Servico_Funcionario1`
                            FOREIGN KEY (`ID_Funcionario`)
                            REFERENCES `Funcionario` (`ID_Funcionario`)
                            ON UPDATE CASCADE);
		
                        CREATE TABLE IF NOT EXISTS `Servicos_Nota` (
                          `ID_Nota_Servico` INT NOT NULL,
                          `ID_Servico` INT NOT NULL,
                          `Quantidade_Servico` INT NULL DEFAULT NULL,
                          `Preco_Unitario` DECIMAL(10,2) NULL DEFAULT NULL,
                          PRIMARY KEY (`ID_Nota_Servico`, `ID_Servico`),
                          INDEX `fk_Ordem_Servico_has_Servico_Servico1_idx` (`ID_Servico` ASC) VISIBLE,
                          INDEX `fk_Ordem_Servico_has_Servico_Ordem_Servico1_idx` (`ID_Nota_Servico` ASC) VISIBLE,
                          CONSTRAINT `fk_Ordem_Servico_has_Servico_Ordem_Servico1`
                            FOREIGN KEY (`ID_Nota_Servico`)
                            REFERENCES `Nota_Servico` (`ID_Nota_Servico`),
                          CONSTRAINT `fk_Ordem_Servico_has_Servico_Servico1`
                            FOREIGN KEY (`ID_Servico`)
                            REFERENCES `Servico` (`ID`));
		
                         CREATE TABLE IF NOT EXISTS `Produtos_Nota` (
                          `ID_Nota_Produto` INT NOT NULL,
                          `ID_Produto` INT NOT NULL,
                          `Quantidade_Produto` INT NULL DEFAULT NULL,
                          `Preco_Unitario` DECIMAL(10,2) NULL DEFAULT NULL,
                          PRIMARY KEY (`ID_Nota_Produto`, `ID_Produto`),
                          INDEX `fk_Ordem_Servico_has_Produto_Produto1_idx` (`ID_Produto` ASC) VISIBLE,
                          INDEX `fk_Ordem_Servico_has_Produto_Ordem_Servico1_idx` (`ID_Nota_Produto` ASC) VISIBLE,
                          CONSTRAINT `fk_Ordem_Servico_has_Produto_Ordem_Servico1`
                            FOREIGN KEY (`ID_Nota_Produto`)
                            REFERENCES `Nota_Servico` (`ID_Nota_Servico`),
                          CONSTRAINT `fk_Ordem_Servico_has_Produto_Produto1`
                            FOREIGN KEY (`ID_Produto`)
                            REFERENCES `Produto` (`ID`));

                    ";
                    comando.ExecuteNonQuery();

                    comando.CommandText = "SELECT * FROM loginusuario";
                    leitor = comando.ExecuteReader();

                    if (!leitor.HasRows) //cria user admin, se não tiver sido criado
                    {
                        leitor.Close();

                        comando.CommandText = @"

                            INSERT INTO Contato (Telefone,Telefone2) values ('(37)99140-9472','');
                            
                            INSERT INTO Endereco (Logradouro, Número, Bairro, Estado, Cidade) values ('', '', '', '', '');
                        
                            INSERT INTO funcionario (Nome_Funcionario, Função, RG_Funcionario, CPF_Funcionario, ID_Contato, ID_Endereco)
                            values ('Administrador', 'Administrador', '', '', 1, 1);
                            
                            INSERT INTO loginusuario (ID_Funcionario_Login, Usuario, Senha, Tipo) values (1, 'admin', 'admin', 'Administrador');
                            
                           ";

                        comando.ExecuteNonQuery();
                    }
                    
                    using(StreamWriter sw = File.CreateText("conexaoDB"))
                    {
                        sw.WriteLine(String.Format("{0};database=assistenciatecnica",URL));

                    }

                }
                catch(MySqlException ex) 
                {

                    MessageBox.Show("Erro ao criar o banco de dados: " + ex.StackTrace, "Criação do banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                leitor.Close();
            }

        }

 
        // Leituras do Banco de Dados
        public void mostrarClientes(string cmd,DataGridView dgCli)
        {

            try
            {
                
                MySqlCommand cmdCli = new MySqlCommand(cmd, conexao);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmdCli);
                DataTable tblCliSql = new DataTable();

                //preenchendo a primeira tabela de clientes e adicionando ao DataGrid
                adp.Fill(tblCliSql);

                //clonando a tabela de IDs e mudando o tipo de dados de Endereço e Contato
                DataTable tblCli = tblCliSql.Clone();
                tblCli.Columns.Add("ID_End",typeof(int));
                tblCli.Columns.Add("ID_Cont",typeof(int));
                
                tblCli.Columns[4].DataType = tblCli.Columns[5].DataType = typeof(string);
                 
                //Importando as informações
                foreach (DataRow linha in tblCliSql.Rows)
                {
                    tblCli.ImportRow(linha);

                }

                //obtendo os endereços do banco a partir do ID e atualizando
                foreach (DataRow linha in tblCli.Rows)
                {
                    int ID_Endereco = Convert.ToInt32((string)linha["ID_Endereco"]);
                    int ID_Contato = Convert.ToInt32((string)linha["ID_Contato"]);

                    linha[6] = ID_Endereco;
                    linha[7] = ID_Contato;
                    linha[5] = obterEndereco(ID_Endereco);
                    linha[4] = obterContato(ID_Contato);

                }
                            
                dgCli.DataSource = tblCli;

                //Coloca os botoes na posiçao adequada
                dgCli.Columns["Editar"].DisplayIndex = 9;
                dgCli.Columns["Excluir"].DisplayIndex = 9;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }
              

        }
        public void mostrarFuncionarios(string cmd,DataGridView dgFun)
        {
            try
            {                
                MySqlCommand cmdFun = new MySqlCommand(cmd, conexao);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmdFun);
                DataTable tblFunSql = new DataTable();

                //preenchendo a primeira tabela de funcionario e adicionando ao DataGrid
                adp.Fill(tblFunSql);

                //clonando a tabela de IDs e mudando o tipo de dados de Endereço e Contato
                DataTable tblFun = tblFunSql.Clone();
                tblFun.Columns.Add("ID_End",typeof(int));
                tblFun.Columns.Add("ID_Cont",typeof(int));

                tblFun.Columns[5].DataType = tblFun.Columns[6].DataType = typeof(string);
                 
                //Importando as informações
                foreach (DataRow linha in tblFunSql.Rows)
                {
                    tblFun.ImportRow(linha);

                }

                //obtendo os endereços do banco a partir do ID e atualizando
                foreach (DataRow linha in tblFun.Rows)
                {
                    int ID_Endereco = Convert.ToInt32((string)linha["ID_Endereco"]);
                    int ID_Contato = Convert.ToInt32((string)linha["ID_Contato"]);

                    linha[7] = ID_Endereco;
                    linha[8] = ID_Contato;
                    linha[6] = obterEndereco(ID_Endereco);
                    linha[5] = obterContato(ID_Contato);

                }

                dgFun.DataSource = tblFun;

                //Coloca os botoes na posiçao adequada
                dgFun.Columns["Editar"].DisplayIndex = 10;
                dgFun.Columns["Excluir"].DisplayIndex = 10;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }
              

        }
        public void mostrarProdutos(string cmd, DataGridView dgProd)
        {
            try
            {
                MySqlCommand cmdProd = new MySqlCommand(cmd, conexao);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmdProd);
                DataTable tblProdSql = new DataTable();

                //preenchendo a primeira tabela de clientes e adicionando ao DataGrid
                adp.Fill(tblProdSql);

                DataTable tblProd = tblProdSql.Clone();

                tblProd.Columns["Preco_Produto"].DataType = typeof(string);

                foreach(DataRow linha in tblProdSql.Rows)
                {
                    tblProd.ImportRow(linha);
                }

                foreach(DataRow linha in tblProd.Rows)
                {
                    //Converte para valor monetário
                    linha["Preco_Produto"] = Convert.ToDecimal(linha["Preco_Produto"]).ToString("C");
                    
                }

                dgProd.DataSource = tblProd;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }

        }
        public void mostrarServicos(string cmd, DataGridView dgServ)
        {
            try
            {
                MySqlCommand cmdServ = new MySqlCommand(cmd, conexao);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmdServ);
                DataTable tblServSql = new DataTable();

                //preenchendo a primeira tabela de clientes e adicionando ao DataGrid
                adp.Fill(tblServSql);

                DataTable tblServ = tblServSql.Clone();
                tblServ.Columns["Preco_Servico"].DataType = typeof(string);
                foreach(DataRow linha in tblServSql.Rows)
                {
                    tblServ.ImportRow(linha);
                }

                foreach(DataRow linha in tblServ.Rows)
                {
                    //Converte para valor monetário
                    linha["Preco_Servico"] = Convert.ToDecimal(linha["Preco_Servico"]).ToString("C");

                }

                dgServ.DataSource = tblServ;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }


        }
        public DataTable mostrarNotas(string cmd)
        {
            MySqlDataReader leitor = null;

            try
            {
                //montado tabela de dados
                DataTable tblNota = new DataTable();

                tblNota.Columns.Add("ID");
                tblNota.Columns.Add("Data");
                tblNota.Columns.Add("NomeCliente");
                tblNota.Columns.Add("ID_Cliente");
                tblNota.Columns.Add("NomeFuncionario");
                tblNota.Columns.Add("ID_Funcionario");
                tblNota.Columns.Add("Produtos");
                tblNota.Columns.Add("Servicos");
                tblNota.Columns.Add("Valor");
                tblNota.Columns.Add("Desconto");
                tblNota.Columns.Add("Acrescimo");
                tblNota.Columns.Add("Observacoes");

                // instanciando primeiro script SQL
                MySqlCommand cmdNota = new MySqlCommand(cmd, conexao);
                leitor = cmdNota.ExecuteReader();
            
                //lendo as notas de serviço
                while (leitor.Read())
                {
                    DataRow novo = tblNota.NewRow();

                    novo["ID"] = leitor["ID_Nota_Servico"].ToString();
                    novo["Data"] = leitor["Data"].ToString().Substring(0,leitor["Data"].ToString().IndexOf(" "));
                    novo["ID_Cliente"] = leitor["ID_Cliente"].ToString();
                    novo["ID_Funcionario"] = leitor["ID_Funcionario"].ToString();
                    decimal valorNota = Convert.ToDecimal(leitor["Valor_Nota"].ToString());
                    novo["Valor"] = valorNota.ToString("C");
                    novo["Desconto"] = leitor["Desconto"].ToString();
                    novo["Acrescimo"] = leitor["Acrescimo"].ToString();
                    novo["Observacoes"] = leitor["Observacoes"].ToString();

                    tblNota.Rows.Add(novo);

                }

                leitor.Dispose();

                cmd = "SELECT Nome_Cliente FROM cliente WHERE ID_Cliente = @idC;\n" +
                   "SELECT Nome_Funcionario FROM funcionario WHERE ID_Funcionario = @idF;\n" +
                   "SELECT Nome_Produto,Estoque,ID_Produto,Quantidade_Produto,Preco_Unitario" +
                   " FROM produtos_nota JOIN produto ON produto.ID = produtos_nota.ID_Produto" +
                   " WHERE ID_Nota_Produto = @idN;\n" +
                   "SELECT Nome_Servico,ID_Servico,Quantidade_Servico,Preco_Unitario" +
                   " FROM servicos_nota JOIN servico ON servico.ID = servicos_nota.ID_Servico" +
                   " WHERE ID_Nota_Servico = @idN;";
                cmdNota.CommandText = cmd;
                string nl = Environment.NewLine;

                //lendo o cliente,funcionario e produtos/ servicos de cada Nota
                foreach (DataRow linha in tblNota.Rows)
                {                  
                    cmdNota.Parameters.AddWithValue("@idC", Convert.ToInt32(linha["ID_Cliente"].ToString()));
                    cmdNota.Parameters.AddWithValue("@idF", Convert.ToInt32(linha["ID_Funcionario"].ToString()));
                    cmdNota.Parameters.AddWithValue("@idN", Convert.ToInt32(linha["ID"].ToString()));

                    leitor = cmdNota.ExecuteReader();

                    while(leitor.Read())
                        linha["NomeCliente"] = leitor["Nome_Cliente"].ToString();

                    leitor.NextResult();

                    while(leitor.Read())
                        linha["NomeFuncionario"] = leitor["Nome_Funcionario"].ToString();

                    leitor.NextResult();

                    while (leitor.Read())
                    {
                        decimal valorProd = Convert.ToDecimal(leitor["Preco_Unitario"].ToString());

                        linha["Produtos"] += leitor["Nome_Produto"] + " " + leitor["Quantidade_Produto"] + "un"
                          + " " + valorProd.ToString("C") + "cd" + nl;
                                                                  
                    }

                    leitor.NextResult();

                    while (leitor.Read())
                    {
                        decimal valorProd = Convert.ToDecimal(leitor["Preco_Unitario"].ToString());

                        linha["Servicos"] += leitor["Nome_Servico"] + " " + leitor["Quantidade_Servico"] + "un"
                          + " " + valorProd.ToString("C") + "cd" + nl;

                    }

                    cmdNota.Parameters.Clear();
                    leitor.Dispose();
                }
                               
                leitor.Close();
                return tblNota;
              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
                leitor.Close();
            }

            leitor.Dispose();
            leitor.Close();
            return null;
        }
        public List<string> obterNomesClientesDB()
        {
            List<string> nomes = new List<string>();
           
            try
            {
                string cmd = "SELECT Nome_Cliente FROM cliente";
                MySqlCommand cmdCli = new MySqlCommand(cmd, conexao);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmdCli);
                DataTable tblNomes = new DataTable();
                adp.Fill(tblNomes);
                
                foreach(DataRow linha in tblNomes.Rows)
                {
                    nomes.Add(linha["Nome_Cliente"].ToString());

                }                             

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }

            return nomes;

        }
        public List<string> obterNomesFuncionariosDB()
        {
            List<string> nomes = new List<string>();

            try
            {
                string cmd = "SELECT Nome_Funcionario FROM funcionario";
                MySqlCommand cmdFun = new MySqlCommand(cmd, conexao);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmdFun);
                DataTable tblNomes = new DataTable();
                adp.Fill(tblNomes);

                foreach (DataRow linha in tblNomes.Rows)
                {
                    nomes.Add(linha["Nome_Funcionario"].ToString());

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }

            return nomes;

        }
        public void ClienteNota(string nome,ref Pessoa cli,ref Endereco endCli,ref Contato conCli)
        {
            string cmd = "SELECT * from cliente WHERE Nome_Cliente ='" + nome + "'";
            MySqlDataReader leitor = null;

            try
            {                
                MySqlCommand cmdCli = new MySqlCommand(cmd, conexao);
                leitor = cmdCli.ExecuteReader();

                int IdEnd = 0;
                int IdCon = 0;

                while (leitor.Read())
                {
                    //obtendo pessoais dados do cliente
                    cli.ID = Convert.ToInt32(leitor["ID_Cliente"]);
                    cli.Nome = leitor["Nome_Cliente"].ToString();
                    cli.CPF = leitor["CPF_Cliente"].ToString();
                    cli.RG = leitor["RG_Cliente"].ToString();

                    //resguardando os IDs
                     IdEnd = Convert.ToInt32(leitor["ID_Endereco"]);
                     IdCon = Convert.ToInt32(leitor["ID_Contato"]);

                }
                
                leitor.Dispose();
                leitor.Close();
                //obtendo o endereço do banco de dados
                cmd = "SELECT * FROM endereco WHERE ID_Endereco=" + IdEnd;
                cmdCli.CommandText = cmd;
                leitor = cmdCli.ExecuteReader();
                
                while (leitor.Read())
                {
                    //atribuindo ao objeto
                    endCli.Logradouro = leitor["Logradouro"].ToString();
                    endCli.Numero = leitor["Número"].ToString();
                    endCli.Bairro = leitor["Bairro"].ToString();
                    endCli.Estado = leitor["Estado"].ToString();
                    endCli.Cidade = leitor["Cidade"].ToString();

                }

                leitor.Dispose();
                leitor.Close();
                //obtendo o contato do banco de dados
                cmd = "SELECT * FROM contato WHERE ID_Contato=" + IdCon;
                cmdCli.CommandText = cmd;
                leitor = cmdCli.ExecuteReader();
                
                while (leitor.Read())
                {
                    //atribuindo ao objeto
                    conCli.Contato1 = leitor["Telefone"].ToString();
                    conCli.Contato2 = leitor["Telefone2"].ToString();

                }
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }

            leitor.Dispose();
            leitor.Close();
        }
        public void FuncionariosNota(string nome, ref Funcionario fun, ref Endereco endFun, ref Contato conFun)
        {
            string cmd = "SELECT * from funcionario WHERE Nome_Funcionario='" + nome + "'";
            MySqlDataReader leitor = null;

            try
            {
                MySqlCommand cmdCli = new MySqlCommand(cmd, conexao);
                leitor = cmdCli.ExecuteReader();

                int IdEnd = 0;
                int IdCon = 0;

                while (leitor.Read())
                {
                    //obtendo pessoais dados do cliente
                    fun.ID = Convert.ToInt32(leitor["ID_Funcionario"]);
                    fun.Nome = leitor["Nome_Funcionario"].ToString();
                    fun.CPF = leitor["CPF_Funcionario"].ToString();
                    fun.RG = leitor["RG_Funcionario"].ToString();
                    fun.Funcao = leitor["Função"].ToString();

                    //resguardando os IDs
                    IdEnd = Convert.ToInt32(leitor["ID_Endereco"]);
                    IdCon = Convert.ToInt32(leitor["ID_Contato"]);

                }

                leitor.Dispose();
                leitor.Close();
                //obtendo o endereço do banco de dados
                cmd = "SELECT * FROM endereco WHERE ID_Endereco=" + IdEnd;
                cmdCli.CommandText = cmd;
                leitor = cmdCli.ExecuteReader();

                while (leitor.Read())
                {
                    //atribuindo ao objeto
                    endFun.Logradouro = leitor["Logradouro"].ToString();
                    endFun.Numero = leitor["Número"].ToString();
                    endFun.Bairro = leitor["Bairro"].ToString();
                    endFun.Estado = leitor["Estado"].ToString();
                    endFun.Cidade = leitor["Cidade"].ToString();

                }

                leitor.Dispose();
                leitor.Close();
                //obtendo o contato do banco de dados
                cmd = "SELECT * FROM contato WHERE ID_Contato=" + IdCon;
                cmdCli.CommandText = cmd;
                leitor = cmdCli.ExecuteReader();

                while (leitor.Read())
                {
                    //atribuindo ao objeto
                    conFun.Contato1 = leitor["Telefone"].ToString();
                    conFun.Contato2 = leitor["Telefone2"].ToString();

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados: " + ex);
            }

            leitor.Dispose();
            leitor.Close();
        }
        public void tabelaNota(ref DataTable tblNota,int ID_Nota)
        {

            MySqlDataReader leitor = null;

            try
            {
                string cmd = 
                   "SELECT Nome_Produto,Estoque,ID_Produto,Quantidade_Produto,Preco_Unitario" +
                   " FROM produtos_nota JOIN produto ON produto.ID = produtos_nota.ID_Produto" +
                   " WHERE ID_Nota_Produto = @idN;\n" +
                   "SELECT Nome_Servico,ID_Servico,Quantidade_Servico,Preco_Unitario" +
                   " FROM servicos_nota JOIN servico ON servico.ID = servicos_nota.ID_Servico" +
                   " WHERE ID_Nota_Servico = @idN;";

                    MySqlCommand cmdNota = new MySqlCommand(cmd, conexao);
                                
                    //lendo o cliente,funcionario e produtos/servicos de cada Nota
               
                    cmdNota.Parameters.AddWithValue("@idN", ID_Nota);

                    leitor = cmdNota.ExecuteReader();
                                               
                    while (leitor.Read())
                    {
                        DataRow novo = tblNota.NewRow();

                        novo["Tipo"] = "P";
                        novo["ID"] = leitor["ID_Produto"].ToString();
                        novo["Descricao"] = leitor["Nome_Produto"].ToString();
                        novo["Quantidade"] = leitor["Quantidade_Produto"].ToString();
                        int qtd = Convert.ToInt32(leitor["Quantidade_Produto"].ToString());
                        novo["Estoque"] = leitor["Estoque"].ToString();                    
                        decimal valorProd = Convert.ToDecimal(leitor["Preco_Unitario"].ToString());
                        novo["Preco"] = valorProd.ToString("C");
                        novo["PrecoTotal"] = (valorProd * qtd).ToString("C");

                        tblNota.Rows.Add(novo);
                    }

                    leitor.NextResult();

                    while (leitor.Read())
                    {
                        DataRow novo = tblNota.NewRow();

                        novo["Tipo"] = "S";
                        novo["ID"] = leitor["ID_Servico"].ToString();
                        novo["Descricao"] = leitor["Nome_Servico"].ToString();
                        novo["Quantidade"] = leitor["Quantidade_Servico"].ToString();
                        int qtd = Convert.ToInt32(leitor["Quantidade_Servico"].ToString());
                        novo["Estoque"] = "∞";
                        decimal valorProd = Convert.ToDecimal(leitor["Preco_Unitario"].ToString());
                        novo["Preco"] = valorProd.ToString("C");
                        novo["PrecoTotal"] = (valorProd * qtd).ToString("C");

                        tblNota.Rows.Add(novo);
                    }

                leitor.Dispose();
                leitor.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Tabela Nota): " + ex);
                leitor.Dispose();
                leitor.Close();
            }

            leitor.Dispose();
            leitor.Close();

        }

        public string obterEndereco(int ID_Endereco)
        {

            try
            {
                string cmd = "SELECT Logradouro FROM endereco WHERE ID_Endereco = @id";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.Parameters.AddWithValue("@id", ID_Endereco);

                string log = (string)comando.ExecuteScalar();

                cmd = "SELECT Número FROM endereco WHERE ID_Endereco = @id";
                comando.CommandText = cmd;
                string num = (string)comando.ExecuteScalar();

                cmd = "SELECT Bairro FROM endereco WHERE ID_Endereco = @id";
                comando.CommandText = cmd;
                string bairro = (string)comando.ExecuteScalar();

                cmd = "SELECT Estado FROM endereco WHERE ID_Endereco = @id";
                comando.CommandText = cmd;
                string estado = (string)comando.ExecuteScalar();

                cmd = "SELECT Cidade FROM endereco WHERE ID_Endereco = @id";
                comando.CommandText = cmd;
                string cidade = (string)comando.ExecuteScalar();

                string nl = Environment.NewLine;

                return log + " - Número " + num + nl + "Bairro " + bairro + " - " + cidade + "/" + estado;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados : " + ex.Message);

            }

            return null;
        }
        public string obterContato(int ID_Contato)
        {

            try
            {
                string cmd = "SELECT Telefone from contato where ID_Contato = @id";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.Parameters.AddWithValue("@id", ID_Contato);

                string telefone1 = (string)comando.ExecuteScalar();

                cmd = "SELECT Telefone2 from contato WHERE ID_Contato = @id";
                comando.CommandText = cmd;
                string telefone2 = (string)comando.ExecuteScalar();

                string nl = Environment.NewLine;

                return (telefone2 == string.Empty) ? telefone1 + nl : telefone1 + nl + telefone2;

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Erro de banco de dados : " + ex.Message);
            }

            return null;

        }
        public string ObterUsuario(string user, string userSenha)
        {

            try
            {
                string cmd = @"SELECT Nome_Funcionario FROM funcionario 
	                           WHERE ID_Funcionario = (SELECT ID_Funcionario_Login FROM loginusuario 
                               WHERE Usuario = @user AND Senha = @userSenha) 
                              ";
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.Parameters.AddWithValue("@user", user);
                comando.Parameters.AddWithValue("@userSenha", userSenha);
             
                return (string)comando.ExecuteScalar();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados : " + ex.Message);

            }

            return null;
        }
        public bool ChecarLogin(string user,string userSenha)
        {
            MySqlDataReader leitor = null;
            try
            {               
                String cmd = "SELECT * FROM loginusuario WHERE Usuario = @user AND Senha= @senha";
                MySqlCommand comando = new MySqlCommand(cmd,conexao);
                comando.Parameters.AddWithValue("@user", user);
                comando.Parameters.AddWithValue("@senha", userSenha);
                leitor = comando.ExecuteReader();

                if (leitor.HasRows) //se tiver encontrado algum registro
                {
                    leitor.Close();
                    return true;

                } 
               
            }
            catch (MySqlException ex)
            {
                
                MessageBox.Show("Erro de banco de dados : " + ex.Message);

            }

            leitor.Close();
            return false;
        }

        //Operações de INSERT
        public void addCliente(Pessoa cliente,Endereco endereco,Contato contato)
        {          

            try
            {
                int ID_Endereco_Cliente = addEndereco(endereco);
                int ID_Contato_Cliente = addContato(contato);
                        
            string cmd = "INSERT INTO cliente (Nome_Cliente,RG_Cliente,CPF_Cliente,ID_Contato,ID_Endereco) " +
                    " values (@nome,@rg,@cpf,@contato,@endereco)";
                
                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@rg", cliente.RG);
                comando.Parameters.AddWithValue("@cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@contato", ID_Contato_Cliente);
                comando.Parameters.AddWithValue("@endereco", ID_Endereco_Cliente);

                comando.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso !","Novo Cliente",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Cliente): " + ex.Message);
                   
            }
                    

        }
        public void addFuncionario(Funcionario funcionario, Endereco endereco, Contato contato)
        {
            try
            {
                int ID_Endereco_Cliente = addEndereco(endereco);
                int ID_Contato_Cliente = addContato(contato);

                string cmd = "INSERT INTO funcionario (Nome_Funcionario,Função,RG_Funcionario,CPF_Funcionario,ID_Contato,ID_Endereco) " +
                        " values (@nome,@funcao,@rg,@cpf,@contato,@endereco)";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@funcao", funcionario.Funcao);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
                comando.Parameters.AddWithValue("@contato", ID_Contato_Cliente);
                comando.Parameters.AddWithValue("@endereco", ID_Endereco_Cliente);

                comando.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso !","Novo Funcionário",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Funcionário) : " + ex.Message);

            }


        }
        public void addProduto(Produto produto)
        {
            try
            {
                string cmd = "INSERT INTO produto (Nome_Produto,Preco_Produto,Estoque) VALUES (@nome,@preco,@estoque)";
                       
                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@nome", produto.Descricao);
                comando.Parameters.AddWithValue("@preco", produto.Preco);
                comando.Parameters.AddWithValue("@Estoque", produto.Estoque);

                comando.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso !", "Novo Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Produto): " + ex.Message);

            }

        }
        public void addServico(Servico servico)
        {
            try
            {
                string cmd = "INSERT INTO servico (Nome_Servico,Preco_Servico) VALUES (@nome,@preco)";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@nome", servico.Descricao);
                comando.Parameters.AddWithValue("@preco", servico.Preco);
                
                comando.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso !", "Novo Serviço", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Serviço): " + ex.Message);

            }

        }
        private int addEndereco(Endereco endereco)
        {
         
            try
            {
                string cmd = "INSERT INTO endereco (Logradouro,Número,Bairro,Estado,Cidade)" +
                    "values (@logradouro,@numero,@bairro,@estado,@cidade)";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                
                //adicionando os parametros
                comando.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                comando.Parameters.AddWithValue("@numero", endereco.Numero);
                comando.Parameters.AddWithValue("@bairro", endereco.Bairro);
                comando.Parameters.AddWithValue("@estado", endereco.Estado);
                comando.Parameters.AddWithValue("@cidade", endereco.Cidade);

                comando.ExecuteNonQuery();

                //retorna o ID do endereco criado no banco
                return (int)comando.LastInsertedId;


            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Erro de banco de dados : " + ex.Message);

            }
                     
            return -1;
        }
        private int addContato(Contato contato)
        {

            try
            {
                string cmd = "INSERT INTO contato values (NULL,@telefone1,@telefone2)";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                //adicionando os parametros
                comando.Parameters.AddWithValue("@telefone1", contato.Contato1);
                comando.Parameters.AddWithValue("@telefone2", contato.Contato2);

                comando.ExecuteNonQuery();

                //retorna o ID do endereco criado no banco
                return (int)comando.LastInsertedId;

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Erro de banco de dados : " + ex.Message);

            }

            return -1;
        }
        public bool salvarNota(DadosNota dadosNota)
        {
            try
            {
                string cmd = "INSERT INTO nota_servico (Data,ID_Cliente,ID_Funcionario,Valor_Nota" +
                    ",Acrescimo,Desconto,Observacoes) VALUES (@dt,@IDCli,@IDFun,@valor,@acres,@desc,@obs)";
                                      
                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                DateTime dt = DateTime.Parse(dadosNota.Data);

                comando.Parameters.AddWithValue("@dt", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                comando.Parameters.AddWithValue("@IDCli", dadosNota.cliente.ID);
                comando.Parameters.AddWithValue("@IDFun", dadosNota.funcionario.ID);
                comando.Parameters.AddWithValue("@valor", Convert.ToDecimal(dadosNota.valorNota.Replace("R$ ","")));
                comando.Parameters.AddWithValue("@acres", dadosNota.acrescimo);
                comando.Parameters.AddWithValue("@desc", dadosNota.desconto);
                comando.Parameters.AddWithValue("@obs", dadosNota.observacoes);
                              
                comando.ExecuteNonQuery();
                int ID_Nota = Convert.ToInt32(comando.LastInsertedId);

                //inserindo produtos e serviços no BD
                foreach (DataRow linha in dadosNota.tabelaNota.Rows) 
                {

                    if(linha["Tipo"].ToString() == "P")
                    { //se for um produto

                        inserirProdutoNota(linha, ID_Nota);

                    }
                    else
                    {// se for um serviço

                        inserirServicoNota(linha, ID_Nota);

                    }

                }

              MessageBox.Show("Nota de Serviço Salva com Sucesso !", "Gravação de Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Nota): " + ex.Message);
                
                return false;
            }
            
           
            return true;
        }
        private void inserirProdutoNota(DataRow produto,int ID_nota)
        {

            try
            {
                string cmd = "INSERT INTO produtos_nota (ID_Nota_Produto,ID_Produto,Quantidade_Produto,Preco_Unitario)" +
                    " VALUES (@IDNota,@IDProd,@Qtde,@PrecoUn)";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@IDNota", ID_nota);
                comando.Parameters.AddWithValue("@IDProd", Convert.ToInt32(produto["ID"].ToString()));
                comando.Parameters.AddWithValue("@Qtde", Convert.ToInt32(produto["Quantidade"].ToString()));
                comando.Parameters.AddWithValue("@PrecoUn", Convert.ToDecimal(produto["Preco"].ToString().Replace("R$ ","")));

                comando.ExecuteNonQuery();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Produto Nota): " + ex.Message);
                               
            }


        }
        private void inserirServicoNota(DataRow servico, int ID_nota)
        {
            try
            {
                string cmd = "INSERT INTO servicos_nota (ID_Nota_Servico,ID_Servico,Quantidade_Servico,Preco_Unitario)" +
               " VALUES (@IDNota,@IDServ,@Qtde,@PrecoUn)";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@IDNota", ID_nota);
                comando.Parameters.AddWithValue("@IDServ", Convert.ToInt32(servico["ID"].ToString()));
                comando.Parameters.AddWithValue("@Qtde", Convert.ToInt32(servico["Quantidade"].ToString()));
                comando.Parameters.AddWithValue("@PrecoUn", Convert.ToDecimal(servico["Preco"].ToString().Replace("R$ ", "")));

                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Serviço Nota): " + ex.Message);
                              
            }

        }
        
        //Operações de Edição
        public void attCliente(int ID,int ID_End,int ID_Cont,Pessoa cliente, Endereco endereco, Contato contato)
        {
            try
            {
                 attEndereco(ID_End,endereco);
                 attContato(ID_Cont,contato);

                string cmd = "UPDATE cliente SET Nome_Cliente = @nome,RG_Cliente = @rg,CPF_Cliente = @cpf" +
                        " WHERE ID_Cliente="+ID;

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
 
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@rg", cliente.RG);
                comando.Parameters.AddWithValue("@cpf", cliente.CPF);
              
                comando.ExecuteNonQuery();

                MessageBox.Show("Cliente Atualizado com sucesso !", "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Cliente): " + ex.Message);

            }

        }  
        public void attFuncionario(int ID,int ID_End,int ID_Cont,Funcionario funcionario, Endereco endereco, Contato contato)
        {
            try
            {
                 attEndereco(ID_End,endereco);
                 attContato(ID_Cont,contato);

                string cmd = "UPDATE funcionario SET Nome_Funcionario = @nome,Função = @funcao,RG_Funcionario = @rg,CPF_Funcionario = @cpf" +
                        " WHERE ID_Funcionario="+ID;

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
 
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@funcao", funcionario.Funcao);
                comando.Parameters.AddWithValue("@rg", funcionario.RG);
                comando.Parameters.AddWithValue("@cpf", funcionario.CPF);
              
                comando.ExecuteNonQuery();

                MessageBox.Show("Funcionario Atualizado com sucesso !", "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Funcionário): " + ex.Message);

            }

        }
        public void attProduto(int ID,Produto produto)
        {
            try
            {            
                string cmd = "UPDATE produto SET Nome_Produto = @nome,Preco_Produto = @preco,Estoque = @estoque" +
                        " WHERE ID_Produto=" + ID;

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                 
                comando.Parameters.AddWithValue("@nome", produto.Descricao);
                comando.Parameters.AddWithValue("@preco", produto.Preco);
                comando.Parameters.AddWithValue("@Estoque", produto.Estoque);
     

                comando.ExecuteNonQuery();

                MessageBox.Show("Produto Atualizado com sucesso !", "Edição de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Produto): " + ex.Message);

            }

        }
        public void attServico(int ID, Servico servico)
        {
            try
            {
                string cmd = "UPDATE servico SET Nome_Servico = @nome,Preco_Servico = @preco" +
                        " WHERE ID_Servico=" + ID;

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@nome", servico.Descricao);
                comando.Parameters.AddWithValue("@preco", servico.Preco);
                
                comando.ExecuteNonQuery();

                MessageBox.Show("Serviço Atualizado com sucesso !", "Edição de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Serviço): " + ex.Message);

            }

        }
        public void attEndereco(int ID,Endereco endereco)
        {

            try
            {
                string cmd = "UPDATE endereco SET Logradouro = @log,Número = @num," +
                    "Bairro = @bairro,Estado = @est,Cidade = @cid WHERE ID_Endereco=" + ID;
                   

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@log", endereco.Logradouro);
                comando.Parameters.AddWithValue("@num", endereco.Numero);
                comando.Parameters.AddWithValue("@bairro", endereco.Bairro);
                comando.Parameters.AddWithValue("@est", endereco.Estado);
                comando.Parameters.AddWithValue("@cid", endereco.Cidade);

                comando.ExecuteNonQuery();
                           

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Endereço) : " + ex.Message);

            }

        }
        public void attContato(int ID,Contato contato)
        {
            try
            {

                string cmd = "UPDATE contato SET Telefone = @tel,Telefone2 = @tel2 " +
                    "WHERE ID_Contato=" + ID;
                        

                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@tel", contato.Contato1);
                comando.Parameters.AddWithValue("@tel2", contato.Contato2);
 
                comando.ExecuteNonQuery();
                             

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Contato): " + ex.Message);

            }

        }
        public void attNota(int ID_Nota, Pessoa cliente, Endereco endCli, Contato conCli, Funcionario funcionario,
            Endereco endFun, Contato conFun, DataTable tabelaNota, string data,
            string desconto, string acrescimo, string valorNota, string observacoes)
        {

            try
            {
                string cmd = "UPDATE nota_servico SET Data = @dt,ID_Cliente = @IDCli,ID_Funcionario = @IDFun," +
                    "Valor_Nota = @valor,Acrescimo = @acres,Desconto = @desc,Observacoes = @obs " +
                    "WHERE ID_Nota_Servico = @IDNota";


                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                DateTime dt = DateTime.Parse(data);

                comando.Parameters.AddWithValue("@IDNota", ID_Nota);
                comando.Parameters.AddWithValue("@dt", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                comando.Parameters.AddWithValue("@IDCli", cliente.ID);
                comando.Parameters.AddWithValue("@IDFun", funcionario.ID);
                comando.Parameters.AddWithValue("@valor", Convert.ToDecimal(valorNota.Replace("R$ ", "")));
                comando.Parameters.AddWithValue("@acres", acrescimo);
                comando.Parameters.AddWithValue("@desc", desconto);
                comando.Parameters.AddWithValue("@obs", observacoes);

                comando.ExecuteNonQuery();

                //excluindo os produtos e serviços antigos
                excluirProdutoNota(ID_Nota);
                excluirServicoNota(ID_Nota);

                //inserindo produtos e serviços novos no BD
                foreach (DataRow linha in tabelaNota.Rows)
                {

                    if (linha["Tipo"].ToString() == "P")
                    { //se for um produto

                       inserirProdutoNota(linha, ID_Nota);

                    }
                    else
                    {// se for um serviço

                        inserirServicoNota(linha, ID_Nota);

                    }

                }

                MessageBox.Show("Nota de Serviço Atualizada com Sucesso", "Atualização de Nota de Serviço",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Nota): " + ex.Message);

            }

        }

        //Operações de Exclusão
        public void excluirCliente(DataGridViewRow dadosCliente)
        {
            try
            {
                excluirEndereco(Convert.ToInt32(dadosCliente.Cells["ID_End"].Value.ToString()));
                excluirContato(Convert.ToInt32(dadosCliente.Cells["ID_Cont"].Value.ToString()));
                    
                int ID = Convert.ToInt32(dadosCliente.Cells["ID"].Value.ToString());

                string cmd = "DELETE FROM cliente WHERE ID_Cliente=" + ID;
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();

                MessageBox.Show("Cliente excluído com sucesso !", "Remoção de Cliente", MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Cliente): " + ex.Message);

            }
        }
        public void excluirFuncionario(DataGridViewRow dadosFuncionario)
        {
            try
            {
                excluirEndereco(Convert.ToInt32(dadosFuncionario.Cells["ID_End"].Value.ToString()));
                excluirContato(Convert.ToInt32(dadosFuncionario.Cells["ID_Cont"].Value.ToString()));

                int ID = Convert.ToInt32(dadosFuncionario.Cells["ID"].Value.ToString());

                string cmd = "DELETE FROM funcionario WHERE ID_Funcionario=" + ID;
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();

                MessageBox.Show("Funcionário excluído com sucesso !", "Remoção de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Funcionário): " + ex.Message);

            }
        }
        public void excluirProduto(DataGridViewRow dadosProduto)
        {
            try
            {               

                int ID = Convert.ToInt32(dadosProduto.Cells["ID"].Value.ToString());

                string cmd = "DELETE FROM produto WHERE ID=" + ID;
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();

                MessageBox.Show("Produto excluído com sucesso !", "Remoção de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Produto): " + ex.Message);

            }
        }
        public void excluirServico(DataGridViewRow dadosServico)
        {
            try
            {
                int ID = Convert.ToInt32(dadosServico.Cells["ID"].Value.ToString());

                string cmd = "DELETE FROM servico WHERE ID=" + ID;
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();

                MessageBox.Show("Produto excluído com sucesso !", "Remoção de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Produto): " + ex.Message);

            }
        }
        public void excluirEndereco(int ID)
        {
            try
            {

                string cmd = "DELETE FROM endereco WHERE ID_Endereco=" + ID;
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();
                           
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Endereço): " + ex.Message);

            }
        }
        public void excluirContato(int ID)
        {

            try
            {
                string cmd = "DELETE FROM contato WHERE ID_Contato=" + ID;
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();
                              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Contato): " + ex.Message);

            }

        }
        public void excluirNota(int ID_Nota)
        {
            try
            {
                string cmd = "DELETE FROM nota_servico WHERE ID_Nota_Servico = @IDNota";

                excluirProdutoNota(ID_Nota);
                excluirServicoNota(ID_Nota);

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.Parameters.AddWithValue("@IDNota", ID_Nota);

                comando.ExecuteNonQuery();

                MessageBox.Show("Nota de Serviço Excluída com Sucesso", "Remoção de Nota de Serviço",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Produto Nota): " + ex.Message);

            }

        }
        public void excluirProdutoNota(int ID_Nota)
        {
            try
            {
                string cmd = "DELETE FROM produtos_nota WHERE ID_Nota_Produto = @IDNota";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.Parameters.AddWithValue("@IDNota", ID_Nota);

                comando.ExecuteNonQuery();
                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Produto Nota): " + ex.Message);

            }

        }
        public void excluirServicoNota(int ID_Nota)
        {
            try
            {
                string cmd = "DELETE FROM servicos_nota WHERE ID_Nota_Servico = @IDNota";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.Parameters.AddWithValue("@IDNota", ID_Nota);

                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Serviço Nota): " + ex.Message);

            }


        }

    }
}
