using EsporteNet.Models.AcessoAoBanco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Contato
{
    public class ContatoDAO : DBHelper
    {
        #region Atributos
        #endregion

        #region Contrutor
        public ContatoDAO()
        {
        }
        #endregion

        public Contato ObterContato(Int64 chave)
        {
            try
            {
                /*private int fk_cod_usu {get; set;}
                private int email {get; set;}
                private int telefone {get; set;}
                private int celular {get; set;}*/
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [CONTATO_USU] WHERE [FK_COD_USU] = @FK_COD_USU", con, tran);
                cmd.Parameters.AddWithValue("@FK_COD_USU", chave);
                Contato cont = new Contato();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cont.Fk_cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    cont.Email = Convert.ToString((dr["EMAIL"]));
                    cont.Telefone = Convert.ToString((dr["TELEFONE"]));
                    cont.Celular = Convert.ToString((dr["CELULAR"]));
                    
                }
                return cont;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter dados do Contato: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        public void Insert(Contato cont)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [CONTATO_USU] 
                                            ([FK_COD_USU],
                                             [EMAIL],
                                             [TELEFONE],
                                             [CELULAR]) 
                                    VALUES (@FK_COD_USU,
                                            @EMAIL,
                                            @TELEFONE,
                                            @CELULAR) ", con, tran);
                
                cmd.Parameters.AddWithValue("@FK_COD_USU", cont.Fk_cod_usu);
                cmd.Parameters.AddWithValue("@EMAIL", cont.Email);
                cmd.Parameters.AddWithValue("@TELEFONE", cont.Telefone);
                cmd.Parameters.AddWithValue("@CELULAR", cont.Celular);
               
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();


            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao cadastrar Contato: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        
        public List<Contato> ListarContato(int cod)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [CONTATO_USU] WHERE @FK_COD_USU = 0 OR [FK_COD_USU] = @FK_COD_USU", con, tran);
                if (cod == 0)
                {
                    cmd.Parameters.AddWithValue("@FK_COD_USU", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FK_COD_USU", cod);
                }


                List<Contato> lista = new List<Contato>();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Contato cont = new Contato(Convert.ToInt16((dr["FK_COD_USU"])));
                    cont.Fk_cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    cont.Email = Convert.ToString((dr["EMAIL"]));
                    cont.Telefone = Convert.ToString((dr["TELEFONE"]));
                    cont.Celular = Convert.ToString((dr["CELULAR"]));
                    lista.Add(cont);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os Contatos: " + ex.Message);
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
                cmd = new SqlCommand(@"DELETE FROM [CONTATO_USU] WHERE [FK_COD_USU] = @FK_COD_USU", con);
                cmd.Parameters.AddWithValue("@FK_COD_USU", chave);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao excluir o contato." + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

      
        public void Update(Contato cont)
        {
            try
            {
                this.AbrirConexao();

                cmd = new SqlCommand(@"UPDATE [CONTATO_USU] SET 
                                                        [EMAIL]         = @EMAIL,
                                                        [TELEFONE]      = @TELEFONE, 
                                                        [CELULAR]      = @CELULAR
                                                 WHERE [FK_COD_USU] = @FK_COD_USU", con);

                cmd.Parameters.AddWithValue("@FK_COD_USU", cont.Fk_cod_usu);
                cmd.Parameters.AddWithValue("@EMAIL", cont.Email);
                cmd.Parameters.AddWithValue("@TELEFONE", cont.Telefone);
                cmd.Parameters.AddWithValue("@CELULAR", cont.Celular);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao autalizar os dados do contato" + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }
    }
}