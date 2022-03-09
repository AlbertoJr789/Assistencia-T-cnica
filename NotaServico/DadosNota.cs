using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistencia_Técnica
{
    public class DadosNota
    {
       
        public string Data { get; set; }    

        //cliente
        public Pessoa cliente { get; set; }
        public Endereco endCli { get; set; }
        public Contato conCli { get; set; }

        //funcionario
        public Funcionario funcionario { get; set; }
        public Contato conFun { get; set; }

        //preço
        public string valorNota { get; set; }
        public DataTable tabelaNota {get;set;}

        // possiveis descontos e acrescimos
        public string desconto { get; set; }
        public string acrescimo { get; set; }
        
        //extra
        public string observacoes{ get; set; }
             

    }
}
