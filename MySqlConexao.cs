using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Assistencia_Técnica
{
    public class MySqlConexao
    {

        public static string URL = "server=localhost;database=assistenciatecnica;uid=root;pwd=22021148;port=3306";

        private static MySqlConnection conexao = null;
        public static MySqlConnection ConexaoDB()
        {

            if (conexao == null)
            {
                try
                {
                    conexao = new MySqlConnection(URL);
                    conexao.Open();               
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }


            }

            return conexao;
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
                
                tblCli.Columns[4].DataType = typeof(string);
                tblCli.Columns[5].DataType = typeof(string);

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

        public bool ChecarLogin(string user,string userSenha)
        {
            MySqlDataReader leitor = null;
            try
            {               
                string cmd = "SELECT * FROM loginusuario WHERE Usuario ='"+ user +"' AND Senha='" + userSenha + "'";
                MySqlCommand comando = new MySqlCommand(cmd,conexao);
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

        public string ObterUsuario(string user, string userSenha)
        {
            string usuario = null;

            try
            {
                string cmd = "SELECT ID_Funcionario_Login FROM loginusuario WHERE Usuario ='" + user + "' AND Senha='" + userSenha + "'";
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                int ID_Funcionario = (int)comando.ExecuteScalar(); //pega o elemento da primeira coluna

                cmd = "SELECT Nome FROM funcionario WHERE ID_Funcionario = " + ID_Funcionario;
                comando.CommandText = cmd;

                return (string)comando.ExecuteScalar();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados : " + ex.Message);

            }

            return usuario;
        }

        public string obterEndereco(int ID_Endereco)
        {

            try
            {
                string cmd = "SELECT Logradouro FROM endereco WHERE ID_Endereço = @id";

                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.Parameters.AddWithValue("@id", ID_Endereco);

                string log = (string)comando.ExecuteScalar();

                cmd = "SELECT Número FROM endereco WHERE ID_Endereço = @id";
                comando.CommandText = cmd;
                string num = (string)comando.ExecuteScalar();

                cmd = "SELECT Bairro FROM endereco WHERE ID_Endereço = @id";
                comando.CommandText = cmd;
                string bairro = (string)comando.ExecuteScalar();

                cmd = "SELECT Estado FROM endereco WHERE ID_Endereço = @id";
                comando.CommandText = cmd;
                string estado = (string)comando.ExecuteScalar();

                cmd = "SELECT Cidade FROM endereco WHERE ID_Endereço = @id";
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

        //Operações de INSERT
        public void addCliente(Pessoa cliente,Endereco enderecoCliente,Contato contatoCliente)
        {          

            try
            {
                int ID_Endereco_Cliente = addEndereco(enderecoCliente);
                int ID_Contato_Cliente = addContato(contatoCliente);
                        
            string cmd = "INSERT INTO cliente (Nome,RG,CPF,ID_Contato,ID_Endereco) " +
                    " values (@nome,@rg,@cpf,@contato,@endereco)";
                
                MySqlCommand comando = new MySqlCommand(cmd, conexao);

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@rg", cliente.RG);
                comando.Parameters.AddWithValue("@cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@contato", ID_Contato_Cliente);
                comando.Parameters.AddWithValue("@endereco", ID_Endereco_Cliente);

                comando.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso !");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados : " + ex.Message);
                   
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

        //Operações de Edição

        public void attCliente(int ID,int ID_End,int ID_Cont,Pessoa cliente, Endereco enderecoCliente, Contato contatoCliente)
        {
            try
            {
                 attEndereco(ID_End,enderecoCliente);
                 attContato(ID_Cont,contatoCliente);

                string cmd = "UPDATE cliente SET Nome = @nome,RG = @rg,CPF = @cpf" +
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
        public void attEndereco(int ID,Endereco endereco)
        {

            try
            {
                string cmd = "UPDATE endereco SET Logradouro = @log,Número = @num," +
                    "Bairro = @bairro,Estado = @est,Cidade = @cid WHERE ID_Endereço=" + ID;
                   

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
                MessageBox.Show("Erro de banco de dados (Contato): " + ex.Message);

            }
        }
        public void excluirEndereco(int ID)
        {
            try
            {

                string cmd = "DELETE FROM endereco WHERE ID_Endereço=" + ID;
                MySqlCommand comando = new MySqlCommand(cmd, conexao);
                comando.ExecuteNonQuery();
                           
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de banco de dados (Contato): " + ex.Message);

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

    }
}
