using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Usuario
{
    public class Usuario
    {
        private int cod_usu;

        public int Cod_usu
        {
            get { return cod_usu; }
            set { cod_usu = value; }
        }
        private string dsc_username;

        public string Dsc_username
        {
            get { return dsc_username; }
            set { dsc_username = value; }
        }
        private string passoword;

        public string Passoword
        {
            get { return passoword; }
            set { passoword = value; }
        }
        private int cod_sup;

        public int Cod_sup
        {
            get { return cod_sup; }
            set { cod_sup = value; }
        }
        private string dsc_nome_usu;

        public string Dsc_nome_usu
        {
            get { return dsc_nome_usu; }
            set { dsc_nome_usu = value; }
        }

        public Usuario() { }
        public Usuario(int cod_usu) 
        {
            this.cod_usu = cod_usu;
        }
    }
}