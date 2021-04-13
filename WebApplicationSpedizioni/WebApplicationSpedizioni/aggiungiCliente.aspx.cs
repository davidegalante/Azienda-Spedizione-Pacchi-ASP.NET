using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationSpedizioni
{
    public partial class aggiungiCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void InserisciCliente(object sender, EventArgs e)
        {
            string nomeCliente = tbNome.Text;
            string cognomeCliente = tbCognome.Text;
            string indirizzoCliente = tbIndirizzo.Text;

            DataAccess.inserisciCliente(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString,
                nomeCliente, cognomeCliente, indirizzoCliente);
            string link = "aggiungiPacco.aspx?idViaggio=" + Request.QueryString["idViaggio"];
            Response.Redirect(link);
        }
        protected void TornaPacchi(object sender, EventArgs e)
        {
            string link = "aggiungiPacco.aspx?idViaggio=" + Request.QueryString["idViaggio"];
            Response.Redirect(link);
        }
    }
}