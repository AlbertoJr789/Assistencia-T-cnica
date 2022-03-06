using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistencia_Técnica
{
    public class Produto
    {

        private string descricao;
        private decimal preco;
        private int quantidade;
        private int id;
        private int estoque;

        public string Descricao { get { return descricao; } set { descricao = value; } }
        public decimal Preco { get { return preco; } set { preco = value; } }
        public int Estoque { get { return estoque; } set { estoque = value; } }          
        public int Quantidade { get { return quantidade; } set { quantidade = value; } }          
        public int ID { get { return id; } set { id = value; } }          

    }
}
