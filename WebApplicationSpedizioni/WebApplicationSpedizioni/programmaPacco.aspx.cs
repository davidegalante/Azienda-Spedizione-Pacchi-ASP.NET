using ClassLibrarySpedizioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationSpedizioni
{
    public partial class programmaPacco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Pacco> PacchiNonProgrammati;
            PacchiNonProgrammati = DataAccess.getPacchi(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);

            List<Viaggio> Viaggi;
            Viaggi = DataAccess.getViaggi(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);

            if (!IsPostBack)
            {
                ddlPacchi.Items.Add(new ListItem("Nessun Pacco Selezionato"));
                ddlViaggi.Items.Add(new ListItem("Nessun Viaggio Selezionato"));

                foreach (Pacco p in PacchiNonProgrammati)
                {
                    if (p.IdViaggio == null)
                    {
                        string dettagliPacco = p.IdPacco + " - " + p.NomeCompletoMittente + " , " + p.NomeCompletoDestinatario + " , ";
                        ddlPacchi.Items.Add(new ListItem(dettagliPacco));
                    }
                }

                foreach (Viaggio v in Viaggi)
                {
                    string dettagliViaggio = v.IdViaggio + " - " + v.Data + " , " + v.NomeCorriere;
                    ddlViaggi.Items.Add(new ListItem(dettagliViaggio));
                }
            }
        }

        protected void assegnaPacco(object sender, EventArgs e)
        {
            if ((ddlPacchi.SelectedValue != "Nessun Pacco Selezionato") && (ddlViaggi.SelectedValue != "Nessun Viaggio Selezionato"))
            {
                string[] partiPacco = ddlPacchi.SelectedValue.Split('-');
                string[] partiViaggio = ddlViaggi.SelectedValue.Split('-');

                int idPacco = Convert.ToInt32(partiPacco[0]);
                int idViaggio = Convert.ToInt32(partiViaggio[0]);

                DataAccess.ModificaPacco(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, idPacco, idViaggio);
                Response.Redirect("elencoPacchi.aspx");
            }
        }
    }
}