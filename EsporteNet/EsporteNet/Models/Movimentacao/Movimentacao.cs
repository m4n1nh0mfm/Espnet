using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Movimentacao
{
    public class Movimentacao
    {
        private DateTime dt_anomes;

        public DateTime Dt_anomes
        {
            get { return dt_anomes; }
            set { dt_anomes = value; }
        }
        private int fk_cod_usu;

        public int Fk_cod_usu
        {
            get { return fk_cod_usu; }
            set { fk_cod_usu = value; }
        }
        private int sequencia;

        public int Sequencia
        {
            get { return sequencia; }
            set { sequencia = value; }
        }
        private string dsc_tipo;

        public string Dsc_tipo
        {
            get { return dsc_tipo; }
            set { dsc_tipo = value; }
        }
        private int num_apostas;

        public int Num_apostas
        {
            get { return num_apostas; }
            set { num_apostas = value; }
        }
        private double vlt_bruto;

        public double Vlt_bruto
        {
            get { return vlt_bruto; }
            set { vlt_bruto = value; }
        }
        private double vlt_pago;

        public double Vlt_pago
        {
            get { return vlt_pago; }
            set { vlt_pago = value; }
        }
        private double vlt_comis;

        public double Vlt_comis
        {
            get { return vlt_comis; }
            set { vlt_comis = value; }
        }
        private double vlt_liquid;

        public double Vlt_liquid
        {
            get { return vlt_liquid; }
            set { vlt_liquid = value; }
        }

        public Movimentacao() { }
        public Movimentacao(DateTime dt_anomes, int fk_cod_usu, int sequencia)
        {
            this.dt_anomes = dt_anomes;
            this.fk_cod_usu = fk_cod_usu;
            this.sequencia = sequencia;
        }
    }
}