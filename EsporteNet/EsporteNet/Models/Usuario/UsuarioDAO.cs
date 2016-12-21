using EsporteNet.Models.AcessoAoBanco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EsporteNet.Models.Usuario
{
    [DataObject(true)]
    public class UsuarioDAO: DBHelper
    {
       
        #region Atributos
        
        private Local.Local local;
        private Local.LocalDAO localDAO;
        private Contato.Contato cont;
        private Contato.ContatoDAO contDAO;

        #endregion

        #region Contrutor
        public UsuarioDAO()
        {
            this.cont     = new Contato.Contato();
            this.contDAO  = new Contato.ContatoDAO();
            this.local    = new Local.Local();
            this.localDAO = new Local.LocalDAO();
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
                Contato.Contato auxCont = new Contato.Contato();
                Local.Local auxLoc = new Local.Local();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usu.Cod_usu = Convert.ToInt16((dr["COD_USU"]));
                    usu.Dsc_username = Convert.ToString((dr["DSC_USERNAME"]));
                    usu.Passoword = Convert.ToString((dr["PASSWORD"]));
                    usu.Cod_sup = Convert.ToInt16((dr["COD_SUP"]));
                    usu.Dsc_nome_usu = Convert.ToString((dr["DSC_NOME_USU"]));
                    
                    auxLoc = this.localDAO.ObterLocal(usu.Cod_usu);
                    if (auxLoc != null)
                    {
                        usu.Cep = auxLoc.Cep;
                        usu.Endereco = auxLoc.Endereco;
                        usu.Numero = auxLoc.Numero;
                        usu.Cidade = auxLoc.Cidade;
                        usu.Bairro = auxLoc.Bairro;
                        usu.Uf = auxLoc.Uf;
                    }

                    auxCont = this.contDAO.ObterContato(usu.Cod_usu);
                    if(auxCont != null)
                    {
                        usu.Email = auxCont.Email;
                        usu.Telefone = auxCont.Telefone;
                        usu.Celular = auxCont.Celular;
                    }
                    
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

        public string ObterNomeUsuario(int chave)
        {
            try
            {

                this.AbrirConexao();
                cmd = new SqlCommand("SELECT * FROM [USUARIO] WHERE [COD_USU] = @COD_USU", con, tran);
                cmd.Parameters.AddWithValue("@COD_USU", chave);
                string nome = null;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nome = Convert.ToString((dr["DSC_NOME_USU"]));
                }

                if (nome == null)
                {
                    nome = "Nome Indisponivel";
                }
                return nome;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter nome do usuario: " + ex.Message);
            }
            finally
            {
                this.FecharConexao();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
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

                //setando localizacao
                this.local.Fk_cod_usu = usu.Cod_usu;
                this.local.Cep = usu.Cep;
                this.local.Endereco = usu.Endereco;
                this.local.Bairro = usu.Bairro;
                this.local.Numero = usu.Numero;
                this.local.Cidade = usu.Cidade;
                this.local.Uf = usu.Uf;

                //setando contato
                this.cont.Fk_cod_usu = usu.Cod_usu;
                this.cont.Email = usu.Email;
                this.cont.Celular = usu.Celular;
                this.cont.Telefone = usu.Telefone;

                this.localDAO.Insert(local);
                this.localDAO.Insert(local);
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

        [DataObjectMethod(DataObjectMethodType.Select)]
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

                this.localDAO.Delete(chave);
                this.contDAO.Delete(chave);

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

        [DataObjectMethod(DataObjectMethodType.Update)]
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