using EsporteNet.Models.AcessoAoBanco;
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

        public Local ObterLocal(Int64 chave)
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
                    loc.Cep = Convert.ToString((dr["CEP"]));
                    loc.Endereco = Convert.ToString((dr["ENDEREÇO"]));
                    loc.Numero = Convert.ToString((dr["NUMERO"]));
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
                                            @UF) ", con, tran);

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


        public List<Local> ListarLocal(int cep, string bairro, string cidade, string uf)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"SELECT * 
                                        FROM [LOCAL_USU] 
                                            WHERE (@CEP = 0 OR [CEP] = @CEP) AND
                                                    (@BAIRRO IS NULL OR [BAIRRO] = @BAIRRO) AND
                                                        (@CIDADE IS NULL OR [CIDADE] = @CIDADE) AND
                                                            (@UF IS NULL OR [UF] = @UF)", con, tran);
                if (cep == 0)
                {
                    cmd.Parameters.AddWithValue("@CEP", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CEP", cep);
                }


                if (String.IsNullOrEmpty(bairro))
                {
                    cmd.Parameters.AddWithValue("@BAIRRO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@BAIRRO", bairro);
                }
                
                
                if (String.IsNullOrEmpty(cidade))
                {
                    cmd.Parameters.AddWithValue("@CIDADE", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CIDADE", cidade);
                }


                if (String.IsNullOrEmpty(uf))
                {
                    cmd.Parameters.AddWithValue("@UF", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UF", uf);
                }
                List<Local> lista = new List<Local>();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Local loc = new Local(Convert.ToInt16((dr["FK_COD_USU"])));
                    loc.Fk_cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    loc.Cep = Convert.ToString((dr["CEP"]));
                    loc.Endereco = Convert.ToString((dr["ENDEREÇO"]));
                    loc.Numero = Convert.ToString((dr["NUMERO"]));
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