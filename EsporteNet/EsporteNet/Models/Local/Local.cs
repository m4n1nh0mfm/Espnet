using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Local
{
    public class Local
    {
        private int fk_cod_usu {get; set;}
        private int cep {get; set;}
        private string endereco {get; set;}
        private int numero {get; set;}
        private string bairro {get; set;}
        private string cidade {get; set;}
        private string uf {get; set;}

        public Local() { }
        public Local(int fk_cod_usu) 
        {
            this.fk_cod_usu = fk_cod_usu;
        }
    }
}