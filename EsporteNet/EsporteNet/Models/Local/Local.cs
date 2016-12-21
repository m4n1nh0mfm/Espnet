using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Local
{
    public class Local
    {
        private Int64 fk_cod_usu;

        public Int64 Fk_cod_usu
        {
            get { return fk_cod_usu; }
            set { fk_cod_usu = value; }
        }
        private String cep;

        public String Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private string bairro;

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        private string cidade;

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        private string uf;

        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }

        public Local() { }
        public Local(int fk_cod_usu) 
        {
            this.fk_cod_usu = fk_cod_usu;
        }
    }
}