using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistencia_Técnica
{
    public class Endereco
    {

        //dados de endereço
        private string logradouro;
        private string numero;
        private string bairro;
        private string estado;
        private string cidade;

        public Endereco obterEndereco(string endereco)
        {                       
            int posChar = 0;

            for (int i = 0; i < endereco.Length; i++) //obtendo rua/avenida
            {
                if (endereco[i] == '-')
                {
                    posChar = i;
                    break;

                }
                else
                    this.Logradouro += endereco[i];

            }

            for (int i = posChar + 9; i < endereco.Length; i++) //obtendo numero
            {
                if (endereco[i] == '\n')
                {
                    posChar = i;
                    break;
                }
                else if (endereco[i] != '\r')
                    this.Numero += endereco[i];
            }

            for (int i = posChar + 8; i < endereco.Length; i++) //obtendo bairro
            {
                if (endereco[i] == '-')
                {
                    posChar = i;
                    break;
                }
                else
                    this.Bairro += endereco[i];

            }
            for (int i = posChar + 2; i < endereco.Length; i++)
            {
                if (endereco[i] == '/')
                {
                    posChar = i;
                    break;
                }
                else
                    this.Cidade += endereco[i];

            }

            for (int i = posChar + 1; i < endereco.Length; i++)
            {
                this.Estado += endereco[i];

            }

            return this;
        }
        public string Logradouro { get { return logradouro; } set { logradouro = value; } }
        public string Numero { get { return numero; } set { numero = value; } }
        public string Bairro { get { return bairro; } set { bairro = value; } }
        public string Estado { get { return estado; } set { estado = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }

    }
}
