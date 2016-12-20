using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Contato
{
    public class Contato
    {
        private int fk_cod_usu;

        public int Fk_cod_usu
        {
            get { return fk_cod_usu; }
            set { fk_cod_usu = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public Contato() { }
        public Contato(int cod_usu)
        {
            this.fk_cod_usu = cod_usu;
        }
    }
}