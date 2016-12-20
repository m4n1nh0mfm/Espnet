using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Usuario
{
    public class Usuario
    {
        private int cod_usu {get; set;}
        private string dsc_username {get; set;}
        private string passoword {get; set;}
        private int cod_sup {get; set;}
        private string dsc_nome_usu {get; set;}
        public Usuario() { }
        public Usuario(int cod_usu) 
        {
            this.cod_usu = cod_usu;
        }
    }
}