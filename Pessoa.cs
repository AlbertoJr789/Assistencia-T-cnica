using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistencia_Técnica
{
    public class Pessoa
    {

        private int id;
        private string nome;
        private string rg;
        private string cpf;
        public int ID { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string RG { get { return rg; } set { rg = value; } } 
        public string CPF { get { return cpf; } set { cpf = value; } }
                                          
    }
}
