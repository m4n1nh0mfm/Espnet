using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Contato
{
    public class Contato
    {
        private int fk_cod_usu {get; set;}
        private int email {get; set;}
        private int telefone {get; set;}
        private int celular {get; set;}

        public Contato() { }
        public Contato(int cod_usu)
        {
            this.fk_cod_usu = cod_usu;
        }
    }
}