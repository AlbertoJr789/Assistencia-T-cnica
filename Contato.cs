using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistencia_Técnica
{
    public class Contato
    {

        //dados de contato
        private string contato1;
        private string contato2;

        public Contato obterContato(string contato)
        {          
            int posChar = 0;

            for (int i = 0; i < contato.Length; i++)
            {
                if (contato[i] == '\n')
                {
                    posChar = i;
                    break;
                }
                else
                    this.Contato1 += contato[i];

            }

            for (int i = posChar + 1; i < contato.Length; i++)
            {
                this.Contato2 += contato[i];

            }

            return this;
        }

        public string Contato1{ get { return contato1; } set { contato1 = value; } }
        public string Contato2{ get { return contato2; } set { contato2 = value; } }


    }
}
