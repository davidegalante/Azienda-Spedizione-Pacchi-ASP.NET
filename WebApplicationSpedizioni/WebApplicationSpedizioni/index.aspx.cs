using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationSpedizioni
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Accedi(object sender, EventArgs e)
        {
            List<Utente> ListaUtenti;
            ListaUtenti = DataAccess.getUtenti(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
            foreach (Utente u in ListaUtenti)
            {
                if ((tbUser.Text == u.Username) && (tbPassword.Text == u.Password))
                {
                    Response.Redirect("home.aspx");
                }
            }
        }
        protected void Traccia(object sender, EventArgs e)
        {
            Response.Redirect("tracciabilità.aspx");
        }
    }
}