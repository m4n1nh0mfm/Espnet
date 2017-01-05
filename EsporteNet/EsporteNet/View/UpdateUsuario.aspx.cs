using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsporteNet.View
{
    public partial class UpdateUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CEP_TextChanged(object sender, EventArgs e)
        {
            WebServiceCorreios.AtendeClienteClient consultaCEP =
               new WebServiceCorreios.AtendeClienteClient();

            TextBox CEP = (TextBox)FormView2.FindControl("CEP");

            if (!String.IsNullOrEmpty(CEP.Text))
            {
                TextBox CIDADE = (TextBox)FormView2.FindControl("CIDADE");
                DropDownList ESTADO = (DropDownList)FormView2.FindControl("ESTADO");
                TextBox BAIRRO = (TextBox)FormView2.FindControl("BAIRRO");
                TextBox ENDERECO = (TextBox)FormView2.FindControl("ENDERECO");
                try
                {
                    var resposta =
                        consultaCEP.consultaCEP(CEP.Text);
                    if (resposta != null)
                    {
                        CIDADE.Text = resposta.cidade;
                        ESTADO.Text = resposta.uf;
                        BAIRRO.Text = resposta.bairro;
                        ENDERECO.Text = resposta.end;
                    }
                }
                catch (Exception ex)
                {
                    string display = ex.Message;
                    ClientScript.RegisterStartupScript(this.GetType(), "Erro!", "alert('" + display + "!');", true);
                    CIDADE.Text = "";
                    BAIRRO.Text = "";
                    ENDERECO.Text = "";
                }
                TextBox CODSUP = (TextBox)FormView2.FindControl("CODSUP");

                if (CODSUP.Text.Equals(""))
                {
                    CODSUP.Text = "0";
                }
            }
        }
    }
}