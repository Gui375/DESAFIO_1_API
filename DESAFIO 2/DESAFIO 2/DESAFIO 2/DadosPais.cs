using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DESAFIO_2
{
    public class DADOS_DO_PAIS

    {
        public Name name { get; set; }
        public List<string> capital { get; set; }
        public Currencies currencies { get; set; }
        public string MOEDA { get; set; }
        public string REGIAO { get; set; }


    }
}
