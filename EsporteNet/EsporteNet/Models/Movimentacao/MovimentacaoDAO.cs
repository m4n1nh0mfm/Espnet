using EsporteNet.Models.AcessoAoBanco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Movimentacao
{
    public class MovimentacaoDAO: DBHelper
    {
        #region Atributos
        #endregion

        #region Contrutor
        public MovimentacaoDAO()
        {
        }
        #endregion

        public Movimentacao ObterMovimentacao(int chave)
        {
            try
            {

                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [MOVE_APOSTAS] WHERE [FK_COD_USU] = @FK_COD_USU", con, tran);
                cmd.Parameters.AddWithValue("@FK_COD_USU", chave);
                Movimentacao mov = new Movimentacao();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    mov.Dt_anomes = Convert.ToDateTime((dr["DT_ANOMES"]));
                    mov.Fk_cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    mov.Sequencia = Convert.ToInt16((dr["SEQUENCIA"]));
                    mov.Dsc_tipo = Convert.ToString((dr["DSC_TIPO"]));
                    mov.Num_apostas = Convert.ToInt16((dr["NUM_APOSTAS"]));
                    mov.Vlt_bruto = Convert.ToDouble((dr["VLT_BRUTO"]));
                    mov.Vlt_pago = Convert.ToDouble((dr["VLT_PAGO"]));
                    mov.Vlt_comis = Convert.ToDouble((dr["VLT_COMIS"]));
                    mov.Vlt_liquid = Convert.ToDouble((dr["VLT_LIQUID"]));
                }
                return mov;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter dados da Movimentacao: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        public void Insert(Movimentacao mov)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [MOVE_APOSTAS] 
                                            ([DT_ANOMES],
                                             [FK_COD_USU],
                                             [SEQUENCIA],
                                             [DSC_TIPO],
                                             [NUM_APOSTAS],
                                             [VLT_BRUTO],
                                             [VLT_PAGO],
                                             [VLT_COMIS],
                                             [VLT_LIQUID]) 
                                    VALUES (@DT_ANOMES,
                                            @FK_COD_USU,
                                            @SEQUENCIA,
                                            @DSC_TIPO,
                                            @NUM_APOSTAS,
                                            @VLT_BRUTO,
                                            @VLT_PAGO,
                                            @VLT_COMIS,
                                            @VLT_LIQUID) ", con);

                cmd.Parameters.AddWithValue("@DT_ANOMES", mov.Dt_anomes);
                cmd.Parameters.AddWithValue("@FK_COD_USU", mov.Fk_cod_usu);
                cmd.Parameters.AddWithValue("@SEQUENCIA", mov.Sequencia);
                cmd.Parameters.AddWithValue("@DSC_TIPO", mov.Dsc_tipo);
                cmd.Parameters.AddWithValue("@NUM_APOSTAS", mov.Num_apostas);
                cmd.Parameters.AddWithValue("@VLT_BRUTO", mov.Vlt_bruto);
                cmd.Parameters.AddWithValue("@VLT_PAGO", mov.Vlt_pago);
                cmd.Parameters.AddWithValue("@VLT_COMIS", mov.Vlt_comis);
                cmd.Parameters.AddWithValue("@VLT_LIQUID", mov.Vlt_liquid);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();


            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao cadastrar Movimentacao: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }


        public List<Movimentacao> ListarMovimentacao(int cod)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [MOVE_APOSTAS] WHERE @FK_COD_USU = 0 OR [FK_COD_USU] = @FK_COD_USU", con, tran);
                if (cod == 0)
                {
                    cmd.Parameters.AddWithValue("@FK_COD_USU", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FK_COD_USU", cod);
                }


                List<Movimentacao> lista = new List<Movimentacao>();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Movimentacao mov = new Movimentacao(Convert.ToDateTime((dr["DT_ANOMES"])), Convert.ToInt16((dr["FK_COD_USU"])), Convert.ToInt16((dr["SEQUENCIA"])));
                    mov.Dt_anomes = Convert.ToDateTime((dr["DT_ANOMES"]));
                    mov.Fk_cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    mov.Sequencia = Convert.ToInt16((dr["SEQUENCIA"]));
                    mov.Dsc_tipo = Convert.ToString((dr["DSC_TIPO"]));
                    mov.Num_apostas = Convert.ToInt16((dr["NUM_APOSTAS"]));
                    mov.Vlt_bruto = Convert.ToDouble((dr["VLT_BRUTO"]));
                    mov.Vlt_pago = Convert.ToDouble((dr["VLT_PAGO"]));
                    mov.Vlt_comis = Convert.ToDouble((dr["VLT_COMIS"]));
                    mov.Vlt_liquid = Convert.ToDouble((dr["VLT_LIQUID"]));
                    lista.Add(mov);
                }
                return lista;
            }            catch (Exception ex)
            {

                throw new Exception("Erro ao listar as Movimentacoes: " + ex.Message);
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
                cmd = new SqlCommand(@"DELETE FROM [MOVE_APOSTAS] WHERE [FK_COD_USU] = @FK_COD_USU", con);
                cmd.Parameters.AddWithValue("@FK_COD_USU", chave);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao excluir a Movimentacao." + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }


        public void Update(Movimentacao mov)
        {
            try
            {
                this.AbrirConexao();

                cmd = new SqlCommand(@"UPDATE [MOVE_APOSTAS] SET 
                                                        [DSC_TIPO]         = @DSC_TIPO,
                                                        [NUM_APOSTAS]    = @NUM_APOSTAS, 
                                                        [VLT_BRUTO]      = @VLT_BRUTO,
                                                        [VLT_PAGO]      = @VLT_PAGO,
                                                        [VLT_COMIS]      = @VLT_COMIS,
                                                        [VLT_LIQUID]          = @VLT_LIQUID
                                                 WHERE [DT_ANOMES] = @DT_ANOMES AND [FK_COD_USU] = @FK_COD_USU AND [SEQUENCIA] = @SEQUENCIA", con);

                cmd.Parameters.AddWithValue("@DT_ANOMES", mov.Dt_anomes);
                cmd.Parameters.AddWithValue("@FK_COD_USU", mov.Fk_cod_usu);
                cmd.Parameters.AddWithValue("@SEQUENCIA", mov.Sequencia);
                cmd.Parameters.AddWithValue("@DSC_TIPO", mov.Dsc_tipo);
                cmd.Parameters.AddWithValue("@NUM_APOSTAS", mov.Num_apostas);
                cmd.Parameters.AddWithValue("@VLT_BRUTO", mov.Vlt_bruto);
                cmd.Parameters.AddWithValue("@VLT_PAGO", mov.Vlt_pago);
                cmd.Parameters.AddWithValue("@VLT_COMIS", mov.Vlt_comis);
                cmd.Parameters.AddWithValue("@VLT_LIQUID", mov.Vlt_liquid);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao autalizar os dados da Movimentacao" + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }
    }
}