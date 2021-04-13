using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationSpedizioni
{
    public partial class tracciabilità : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Pacco> listaPacchi;
            listaPacchi = DataAccess.getPacchi(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
            Session["ListaPacchi"] = listaPacchi;
        }


        protected void Traccia(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(tbIdPacco.Text) && tbIdPacco.Text != "")
            {
                List<Pacco> Pacco;
                int idPacco = Convert.ToInt32(tbIdPacco.Text);
                //fai vedere info di quel pacco
                Pacco = new List<Pacco>();
                foreach (Pacco p in (List<Pacco>)Session["ListaPacchi"])
                {
                    if (p.IdPacco == idPacco)
                    {
                        Pacco.Add(p);
                    }
                }
                gvPacchi.DataSource = Pacco;
                gvPacchi.DataBind();
            }
        }

        protected void PaginaIniziale(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}