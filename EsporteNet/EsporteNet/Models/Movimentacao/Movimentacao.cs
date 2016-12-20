using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Movimentacao
{
    public class Movimentacao
    {
        private DateTime dt_anomes {get; set;}
        private int fk_cod_usu {get; set;}
        private int sequencia {get; set;}
        private string dsc_tipo{get; set;}
        private int num_apostas{get; set;}
        private float vlt_bruto {get; set;}
        private float vlt_pago {get; set;}
        private float vlt_comis {get; set;}
        private float vlt_liquid{get; set;}

        public Movimentacao() { }
        public Movimentacao(DateTime dt_anomes, int fk_cod_usu, int sequencia)
        {
            this.dt_anomes = dt_anomes;
            this.fk_cod_usu = fk_cod_usu;
            this.sequencia = sequencia;
        }
    }
}