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
        string query;

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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Usuario ObterUsuario(Int64 chave)
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
                    usu.Cod_usu = Convert.ToInt64((dr["COD_USU"]));
                    usu.Dsc_username = Convert.ToString((dr["DSC_USERNAME"]));
                    usu.Passoword = Convert.ToString((dr["PASSWORD"]));
                    usu.Cod_sup = Convert.ToInt64((dr["COD_SUP"]));
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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Usuario> ListarLocal(string cep, string bairro, string cidade, string uf)
        {
            try
            {
                this.AbrirConexao();
                query = @"select l.FK_COD_USU, CEP, ENDERECO, NUMERO, BAIRRO, CIDADE, UF, EMAIL, CELULAR 
	                          from [LOCAL_USU] as l join [CONTATO_USU] as c on l.FK_COD_USU = c.FK_COD_USU
                                   WHERE (@CEP IS NULL OR CEP = @CEP) AND
                                         (@BAIRRO IS NULL OR BAIRRO LIKE '%' + @BAIRRO + '%') AND
                                         (@CIDADE IS NULL OR CIDADE LIKE '%' + @CIDADE + '%') AND
                                         (@UF IS NULL OR UF = @UF)";

                cmd = new SqlCommand(query, tran.Connection, tran);
                if (String.IsNullOrEmpty(cep))
                {
                    cmd.Parameters.AddWithValue("@CEP", DBNull.Value);
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
                List<Usuario> lista = new List<Usuario>();
                dr = cmd.ExecuteReader();
                Usuario usu = new Usuario();
                if (dr.Read())
                {
                    usu.Cod_usu = Convert.ToInt16((dr["FK_COD_USU"]));
                    usu.Cep = Convert.ToString((dr["CEP"]));
                    usu.Endereco = Convert.ToString((dr["ENDERECO"]));
                    usu.Numero = Convert.ToString((dr["NUMERO"]));
                    usu.Bairro = Convert.ToString((dr["BAIRRO"]));
                    usu.Cidade = Convert.ToString((dr["CIDADE"]));
                    usu.Uf = Convert.ToString((dr["UF"]));
                    usu.Email = Convert.ToString((dr["EMAIL"]));
                    usu.Celular = Convert.ToString((dr["CELULAR"]));
                    usu.Dsc_nome_usu = ObterNomeUsuario(usu.Cod_usu);
                    lista.Add(usu);
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

        public string ObterNomeUsuario(Int64 chave)
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
                //Int64 _id = this.ObterCodigo();
                cmd = new SqlCommand(@" INSERT INTO [USUARIO] 
                                            ([DSC_USERNAME],
                                             [PASSWORD],
                                             [COD_SUP],
                                             [DSC_NOME_USU]) 
                                    VALUES (@DSC_USERNAME,
                                            @PASSWORD,
                                            @COD_SUP,
                                            @DSC_NOME_USU)
                                            ", tran.Connection, tran);
                
                //cmd.Parameters.AddWithValue("@COD_USU", usu.Cod_usu);
                cmd.Parameters.AddWithValue("@DSC_USERNAME", usu.Dsc_username);
                cmd.Parameters.AddWithValue("@PASSWORD", usu.Passoword);
                cmd.Parameters.AddWithValue("@COD_SUP", usu.Cod_sup);
                cmd.Parameters.AddWithValue("@DSC_NOME_USU", usu.Dsc_nome_usu);

                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("select @@identity", tran.Connection, tran);
                Int64 _id = Convert.ToInt64(cmd.ExecuteScalar());

                //setando localizacao
                this.local.Fk_cod_usu = _id;
                this.local.Cep = usu.Cep;
                this.local.Endereco = usu.Endereco;
                this.local.Bairro = usu.Bairro;
                this.local.Numero = usu.Numero;
                this.local.Cidade = usu.Cidade;
                this.local.Uf = usu.Uf;

                //setando contato
                this.cont.Fk_cod_usu = _id;
                this.cont.Email = usu.Email;
                this.cont.Celular = usu.Celular;
                this.cont.Telefone = usu.Telefone;

                this.localDAO.Insert(local);
                this.contDAO.Insert(cont);

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
        public List<Usuario> ListarUsuario(Int64 cod)
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
                    Usuario usu = new Usuario(Convert.ToInt64((dr["COD_USU"])));
                    usu.Cod_usu = Convert.ToInt64((dr["COD_USU"]));
                    usu.Dsc_username = Convert.ToString((dr["DSC_USERNAME"]));
                    usu.Passoword = Convert.ToString((dr["PASSWORD"]));
                    usu.Cod_sup = Convert.ToInt64((dr["COD_SUP"]));
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

        public Int64 ObterCodigo()
        {
            try
            {
                //this.AbrirConexao();
                String query = "SELECT MAX([COD_USU]) as COD_USU FROM [USUARIO]";
                cmd = new SqlCommand(query, con , tran);
                Int64 inst = 0;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        inst = Convert.ToInt64((dr["COD_USU"] == DBNull.Value ? 0 : dr["COD_USU"]));
                        dr.Close();
                    }
                }
                inst++;
                return inst;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter Codigo do Usuario: " + ex.Message);
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