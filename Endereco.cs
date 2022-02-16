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

        public string Logradouro { get { return logradouro; } set { logradouro = value; } }
        public string Numero { get { return numero; } set { numero = value; } }
        public string Bairro { get { return bairro; } set { bairro = value; } }
        public string Estado { get { return estado; } set { estado = value; } }
        public string Cidade { get { return cidade; } set { cidade = value; } }

    }
}
