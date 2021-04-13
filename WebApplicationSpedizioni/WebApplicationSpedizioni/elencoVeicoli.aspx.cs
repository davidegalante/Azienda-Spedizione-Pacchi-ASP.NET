using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrarySpedizioni;

namespace WebApplicationSpedizioni
{
    public partial class elencoVeicoli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Veicolo> myList;
            myList = DataAccess.getVeicoli(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
            gvVeicolo.DataSource = myList;
            Session["ListaVeicoli"] = myList;
            gvVeicolo.DataBind();
        }

        protected void AggiungiVeicolo(object sender, EventArgs e)
        {
            Response.Redirect("aggiungiVeicolo.aspx");
        }

        protected void TornaListaViaggi(object sender, EventArgs e)
        {
            Response.Redirect("elencoViaggi.aspx");
        }
    }
}