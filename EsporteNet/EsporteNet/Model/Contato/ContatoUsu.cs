using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Model.Contato
{
    public class ContatoUsu
    {
        private int cod_usu { get; set; }
        private string email { get; set; }
        private string telefone { get; set; }
        private string celular { get; set; }

        public ContatoUsu()
        {

        }
        public ContatoUsu(int cod_usu)
        {
            this.cod_usu = cod_usu;
        }
    }
}