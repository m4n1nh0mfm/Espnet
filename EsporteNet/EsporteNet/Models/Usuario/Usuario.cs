using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Usuario
{
    public class Usuario
    {
        private Int64 cod_usu;

        public Int64 Cod_usu
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

        //localizacao do usuario
     
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

        //contato do usuario
       
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

        public Usuario() { }
        public Usuario(int cod_usu) 
        {
            this.cod_usu = cod_usu;
        }
    }
}