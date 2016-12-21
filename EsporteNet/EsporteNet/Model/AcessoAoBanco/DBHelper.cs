﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsporteNet.Model.AcessoAoBanco
{
    public class DBHelper
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        public string StringConexao;
        protected SqlDataReader dr;
        protected SqlTransaction tran;
        protected void AbrirConexao()
        {
            try
            {
                //this.StringConexao = "Data Source=SQL5018.Smarterasp.net;Initial Catalog=DB_A0CFD7_unit;User Id=DB_A0CFD7_unit_admin;Password=unit2016";
                //this.StringConexao = ConfigurationManager.ConnectionStrings["Smarterasp"].ConnectionString;
                //this.StringConexao = ConfigurationManager.ConnectionStrings["Amazon"].ConnectionString;
                this.StringConexao = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

                con = new SqlConnection(StringConexao);
                con.Open();
                tran = con.BeginTransaction();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao conectar: " + ex.Message);
            }
        }

        protected void FecharConexao()
        {
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao desconectar: " + ex.Message);
            }
        }
    }
}