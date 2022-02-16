using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistencia_Técnica
{
    public class Funcionario : Pessoa
    {

        private string funcao;

        public string Funcao { get { return funcao; } set { funcao = value; } }


    }
}
