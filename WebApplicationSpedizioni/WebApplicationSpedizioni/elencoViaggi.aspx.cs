using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrarySpedizioni;

namespace WebApplicationSpedizioni
{
    public partial class elencoViaggi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Viaggio> myList;
            myList = DataAccess.getViaggi(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
            gvViaggi.DataSource = myList;
            Session["ListaViaggi"] = myList;
            gvViaggi.DataBind();

            //gvViaggi.DataSource = DataAccess.getViaggi(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
            //gvViaggi.DataBind();
        }
    }
}