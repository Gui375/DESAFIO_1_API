using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEP
{
    public class FORMATO_DADOS_CEP
    {
        //public string REGISTRA_CEP;
        //public string CEP { get; set; }
        //public string LOGRADOURO { get; set; }
        //public string COMPLEMENTO { get; set; }
        //public string BAIRRO { get; set; }
        //public string LOCALIDADE { get; set; }
        //public string ESTADO { get; set; }
        //public string IBGE { get; set; }
        //public string GIA { get; set; }
        //public string DDD { get; set; }
        //public string SIAFI { get; set; }
        public string cep { get; set; }

        public string address_type { get; set; }

        public string address_name { get; set; }

        public string address { get; set; }

        public string state { get; set; }

        public string district { get; set; }

        public string lat { get; set; }

        public string lng { get; set; }

        public string city { get; set; }

        public string city_ibge { get; set; }

        public string ddd { get; set; }
    }
}
