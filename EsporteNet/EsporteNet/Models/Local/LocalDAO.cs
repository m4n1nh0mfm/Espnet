﻿using EsporteNet.Models.AcessoAoBanco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Local
{
    public class LocalDAO : DBHelper
    {
        #region Atributos
        #endregion

        #region Contrutor
        public LocalDAO()
        {
        }
        #endregion

        public Local ObterLocal(int chave)
        {
            try
            {

                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [LOCAL_USU] WHERE [FK_COD_USU] = @FK_COD_USU", con, tran);
                cmd.Parameters.AddWithValue("@FK_COD_USU", chave);
                Local loc = new Local();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    loc.Fk_cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    loc.Cep = Convert.ToInt16((dr["CEP"]));
                    loc.Endereco = Convert.ToString((dr["ENDEREÇO"]));
                    loc.Numero = Convert.ToInt16((dr["NUMERO"]));
                    loc.Bairro = Convert.ToString((dr["BAIRRO"]));
                    loc.Cidade = Convert.ToString((dr["CIDADE"]));
                    loc.Uf = Convert.ToString((dr["UF"]));
                }
                return loc;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter dados do Local: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        public void Insert(Local loc)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [LOCAL_USU] 
                                            ([FK_COD_USU],
                                             [CEP],
                                             [ENDERECO],
                                             [NUMERO],
                                             [BAIRRO],
                                             [CIDADE],
                                             [UF]) 
                                    VALUES (@FK_COD_USU,
                                            @CEP,
                                            @ENDERECO,
                                            @NUMERO,
                                            @BAIRRO,
                                            @CIDADE,
                                            @UF) ", con);

                cmd.Parameters.AddWithValue("@FK_COD_USU", loc.Fk_cod_usu);
                cmd.Parameters.AddWithValue("@CEP", loc.Cep);
                cmd.Parameters.AddWithValue("@ENDERECO", loc.Endereco);
                cmd.Parameters.AddWithValue("@NUMERO", loc.Numero);
                cmd.Parameters.AddWithValue("@BAIRRO", loc.Bairro);
                cmd.Parameters.AddWithValue("@CIDADE", loc.Cidade);
                cmd.Parameters.AddWithValue("@UF", loc.Uf);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();


            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao cadastrar Local: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }


        public List<Local> ListarLocal(int cod)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [LOCAL_USU] WHERE @FK_COD_USU = 0 OR [FK_COD_USU] = @FK_COD_USU", con, tran);
                if (cod == 0)
                {
                    cmd.Parameters.AddWithValue("@FK_COD_USU", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FK_COD_USU", cod);
                }


                List<Local> lista = new List<Local>();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Local loc = new Local(Convert.ToInt16((dr["FK_COD_USU"])));
                    loc.Fk_cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    loc.Cep = Convert.ToInt16((dr["CEP"]));
                    loc.Endereco = Convert.ToString((dr["ENDEREÇO"]));
                    loc.Numero = Convert.ToInt16((dr["NUMERO"]));
                    loc.Bairro = Convert.ToString((dr["BAIRRO"]));
                    loc.Cidade = Convert.ToString((dr["CIDADE"]));
                    loc.Uf = Convert.ToString((dr["UF"]));
                    lista.Add(loc);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os Locais: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }


        public void Delete(int chave)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"DELETE FROM [LOCAL_USU] WHERE [FK_COD_USU] = @FK_COD_USU", con);
                cmd.Parameters.AddWithValue("@FK_COD_USU", chave);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao excluir o Local." + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }


        public void Update(Local loc)
        {
            try
            {
                this.AbrirConexao();

                cmd = new SqlCommand(@"UPDATE [LOCAL_USU] SET 
                                                        [CEP]         = @CEP,
                                                        [ENDERECO]    = @ENDERECO, 
                                                        [NUMERO]      = @NUMERO,
                                                        [BAIRRO]      = @BAIRRO,
                                                        [CIDADE]      = @CIDADE,
                                                        [UF]          = @UF
                                                 WHERE [FK_COD_USU] = @FK_COD_USU", con);

                cmd.Parameters.AddWithValue("@FK_COD_USU", loc.Fk_cod_usu);
                cmd.Parameters.AddWithValue("@CEP", loc.Cep);
                cmd.Parameters.AddWithValue("@ENDERECO", loc.Endereco);
                cmd.Parameters.AddWithValue("@NUMERO", loc.Numero);
                cmd.Parameters.AddWithValue("@BAIRRO", loc.Bairro);
                cmd.Parameters.AddWithValue("@CIDADE", loc.Cidade);
                cmd.Parameters.AddWithValue("@UF", loc.Uf);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao autalizar os dados do local" + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }
    }
}