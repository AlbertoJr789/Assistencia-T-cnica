using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistencia_Técnica
{
    public class DataSetNotaObjeto
    {

        private string id;
        private string descricao;
        private string quantidade;
        private string precoUn;
        private string precoTotal;

        public string ID { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Quantidade { get => quantidade; set => quantidade = value; }
        public string PrecoUn { get => precoUn; set => precoUn = value; }
        public string PrecoTotal { get => precoTotal; set => precoTotal = value; }
    }
}
