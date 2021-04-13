using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationSpedizioni
{
    public partial class dettagliViaggio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idViaggio = Convert.ToInt32(Request.QueryString["idViaggio"]); //Id del viaggio recuperato tramite get/querystring
            Viaggio v = ((List<Viaggio>)Session["ListaViaggi"]).First(via => via.IdViaggio == idViaggio);
            List<Pacco> myList;
            myList = DataAccess.getPacchiPerViaggio(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, v);

            //rptPacchi.DataSource = myList;
            //rptPacchi.DataBind();

            gvPacchi.AutoGenerateColumns = false;
            gvPacchi.DataSource = myList;
            gvPacchi.DataBind();

        }

        protected void AggiungiPacco(object sender, EventArgs e)
        {
            string link = "aggiungiPacco.aspx?idViaggio=" + Request.QueryString["idViaggio"];
            Response.Redirect(link);
        }

        protected void TornaElencoViaggi(object sender, EventArgs e)
        {
            Response.Redirect("elencoViaggi.aspx");
        }
    }
}