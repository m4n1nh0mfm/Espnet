using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsporteNet.View
{
    public partial class CadUsuario : System.Web.UI.Page
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
                var resposta =
                    consultaCEP.consultaCEP(CEP.Text);

                TextBox CIDADE = (TextBox)FormView2.FindControl("CIDADE");
                CIDADE.Text = resposta.cidade;

                DropDownList ESTADO = (DropDownList)FormView2.FindControl("ESTADO");
                ESTADO.Text = resposta.uf;

                TextBox BAIRRO = (TextBox)FormView2.FindControl("BAIRRO");
                BAIRRO.Text = resposta.bairro;

                TextBox ENDERECO = (TextBox)FormView2.FindControl("ENDERECO");
                ENDERECO.Text = resposta.end;
            }
        }
    }
}