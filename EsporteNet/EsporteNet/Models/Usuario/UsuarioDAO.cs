using EsporteNet.Models.AcessoAoBanco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Usuario
{
    public class UsuarioDAO: DBHelper
    {
        #region Atributos
        #endregion

        #region Contrutor
        public UsuarioDAO()
        {
        }
        #endregion

        public Usuario ObterUsuario(int chave)
        {
            try
            {
               
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [USUARIO] WHERE [COD_USU] = @COD_USU", con, tran);
                cmd.Parameters.AddWithValue("@COD_USU", chave);
                Usuario usu = new Usuario();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usu.Cod_usu = Convert.ToInt16((dr["COD_USU"]));
                    usu.Dsc_username = Convert.ToString((dr["DSC_USERNAME"]));
                    usu.Passoword = Convert.ToString((dr["PASSWORD"]));
                    usu.Cod_sup = Convert.ToInt16((dr["COD_SUP"]));
                    usu.Dsc_nome_usu = Convert.ToString((dr["DSC_NOME_USU"]));
                    
                }
                return usu;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter dados do Usuario: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        public void Insert(Usuario usu)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand(@"INSERT INTO [USUARIO] 
                                            ([COD_USU],
                                             [DSC_USERNAME],
                                             [PASSWORD],
                                             [COD_SUP],
                                             [DSC_NOME_USU]) 
                                    VALUES (@COD_USU,
                                            @DSC_USERNAME,
                                            @PASSWORD,
                                            @COD_SUP,
                                            @DSC_NOME_USU) ", con);
                
                cmd.Parameters.AddWithValue("@COD_USU", usu.Cod_usu);
                cmd.Parameters.AddWithValue("@DSC_USERNAME", usu.Dsc_username);
                cmd.Parameters.AddWithValue("@PASSWORD", usu.Passoword);
                cmd.Parameters.AddWithValue("@COD_SUP", usu.Cod_sup);
                cmd.Parameters.AddWithValue("@DSC_NOME_USU", usu.Cod_sup);
               
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();


            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao cadastrar Usuario: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        
        public List<Usuario> ListarUsuario(int cod)
        {
            try
            {
                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [USUARIO] WHERE @COD_USU = 0 OR [COD_USU] = @COD_USU", con, tran);
                if (cod == 0)
                {
                    cmd.Parameters.AddWithValue("@COD_USU", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD_USU", cod);
                }


                List<Usuario> lista = new List<Usuario>();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Usuario usu = new Usuario(Convert.ToInt16((dr["COD_USU"])));
                    usu.Cod_usu = Convert.ToInt16((dr["COD_USU"]));
                    usu.Dsc_username = Convert.ToString((dr["DSC_USERNAME"]));
                    usu.Passoword = Convert.ToString((dr["PASSWORD"]));
                    usu.Cod_sup = Convert.ToInt16((dr["COD_SUP"]));
                    usu.Dsc_nome_usu = Convert.ToString((dr["DSC_NOME_USU"]));
                    lista.Add(usu);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os Usuarios: " + ex.Message);
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
                cmd = new SqlCommand(@"DELETE FROM [USUARIO] WHERE [COD_USU] = @COD_USU", con);
                cmd.Parameters.AddWithValue("@COD_USU", chave);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao excluir o usuario." + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

      
        public void Update(Usuario usu)
        {
            try
            {
                this.AbrirConexao();

                cmd = new SqlCommand(@"UPDATE [USUARIO] SET 
                                                        [DSC_USERNAME]         = @DSC_USERNAME,
                                                        [PASSWORD]      = @PASSWORD, 
                                                        [COD_SUP]      = @COD_SUP,
                                                        [DSC_NOME_USU]      = @DSC_NOME_USU
                                                 WHERE [COD_USU] = @COD_USU", con);

                cmd.Parameters.AddWithValue("@COD_USU", usu.Cod_usu);
                cmd.Parameters.AddWithValue("@DSC_USERNAME", usu.Dsc_username);
                cmd.Parameters.AddWithValue("@PASSWORD", usu.Passoword);
                cmd.Parameters.AddWithValue("@COD_SUP", usu.Cod_sup);
                cmd.Parameters.AddWithValue("@DSC_NOME_USU", usu.Cod_sup);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Erro ao autalizar os dados do usuario" + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }

        }
    }
}