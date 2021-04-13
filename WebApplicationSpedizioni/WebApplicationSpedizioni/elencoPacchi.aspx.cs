using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrarySpedizioni;

namespace WebApplicationSpedizioni
{
    public partial class elencoPacchi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Pacco> myList;
                List<Cliente> clienti;
                List<Viaggio> viaggi;
                viaggi = DataAccess.getViaggi(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
                myList = DataAccess.getPacchi(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
                gvPacchi.DataSource = myList;
                Session["ListaPacchi"] = myList;
                gvPacchi.DataBind();
                clienti = DataAccess.getClienti(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
                Session["ListaClienti"] = clienti;
                if (!IsPostBack)
                {
                    ddlViaggi.Items.Add(new ListItem("Nessun Viaggio Selezionato"));
                    ddlMittente.Items.Add(new ListItem("Nessun Mittente Selezionato"));
                    ddlDestinatario.Items.Add(new ListItem("Nessun Destinatario Selezionato"));
                    foreach (Cliente c in clienti)
                    {
                        string dettagliCliente = c.IdCliente + " - " + c.Nome + " " + c.Cognome + " , " + c.Indirizzo;
                        ddlMittente.Items.Add(new ListItem(dettagliCliente));
                        ddlDestinatario.Items.Add(new ListItem(dettagliCliente));
                    }

                    foreach (Viaggio v in viaggi)
                    {
                        string dettagliViaggio = v.IdViaggio + " - " + v.NomeCorriere + " " + v.Targa + " , " + v.Data;
                        ddlViaggi.Items.Add(new ListItem(dettagliViaggio));
                    }
                }
            }           
        }
        protected void TornaListaViaggi(object sender, EventArgs e)
        {
            Response.Redirect("elencoViaggi.aspx");
        }

        protected void FiltraMittente(object sender, EventArgs e)
        {
            List<Pacco> PacchiFiltrati;
            string mittente = ddlMittente.SelectedValue;
            if (ddlMittente.SelectedValue != "Nessun Mittente Selezionato")
            {
                
                string[] partiMittente = mittente.Split('-');
                int idCliente = Convert.ToInt32(partiMittente[0]);
                PacchiFiltrati = new List<Pacco>();
                foreach (Pacco p in (List<Pacco>)Session["ListaPacchi"])
                {
                    if (p.Mittente.IdCliente == idCliente)
                    {
                        PacchiFiltrati.Add(p);
                    }
                }
                gvPacchi.DataSource = PacchiFiltrati;
                gvPacchi.DataBind();
            }
            ddlMittente.SelectedValue = "Nessun Mittente Selezionato";
        }

        protected void FiltraDestinatario(object sender, EventArgs e)
        {
            List<Pacco> PacchiFiltrati;
            string destinatario = ddlDestinatario.SelectedValue;
            if (ddlDestinatario.SelectedValue != "Nessun Destinatario Selezionato")
            {
                string[] partiDestinatario = destinatario.Split('-');
                int idCliente = Convert.ToInt32(partiDestinatario[0]);
                PacchiFiltrati = new List<Pacco>();
                foreach (Pacco p in (List<Pacco>)Session["ListaPacchi"])
                {
                    if (p.Destinatario.IdCliente == idCliente)
                    {
                        PacchiFiltrati.Add(p);
                    }
                }
                gvPacchi.DataSource = PacchiFiltrati;
                gvPacchi.DataBind();
            }
            ddlDestinatario.SelectedValue = "Nessun Destinatario Selezionato";
        }

        protected void FiltraVolume(object sender, EventArgs e)
        {
            List<Pacco> PacchiFiltrati;
            int volume = 0;
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(tbFiltraVolume.Text) && tbFiltraVolume.Text!="")
            {
                volume = Convert.ToInt32(tbFiltraVolume.Text);
            }

            if (volume > 0)
            {
                PacchiFiltrati = new List<Pacco>();
                foreach (Pacco p in (List<Pacco>)Session["ListaPacchi"])
                {
                    if (p.Volume > volume)
                    {
                        PacchiFiltrati.Add(p);
                    }
                }
                gvPacchi.DataSource = PacchiFiltrati;
                gvPacchi.DataBind();
            }
            tbFiltraVolume.Text = "";
        }

        protected void FiltraData(object sender, EventArgs e)
        {
            List<Pacco> PacchiFiltrati;
            DateTime data = clnData.SelectedDate;
            if (data != DateTime.MinValue)
            {
                PacchiFiltrati = new List<Pacco>();
                foreach (Pacco p in (List<Pacco>)Session["ListaPacchi"])
                {
                    if (p.Data != "Data Non Disponibile")
                    {
                        if (Convert.ToDateTime(p.Data).Date == data)
                        {
                            PacchiFiltrati.Add(p);
                        }
                    }
                    
                }
                gvPacchi.DataSource = PacchiFiltrati;
                gvPacchi.DataBind();
            }
            
        }

        protected void FiltraTutti(object sender, EventArgs e)
        {
            gvPacchi.DataSource = Session["ListaPacchi"];
            gvPacchi.DataBind();
            clnData.SelectedDate = DateTime.MinValue;
            tbFiltraVolume.Text = "";
            ddlDestinatario.SelectedValue = "Nessun Destinatario Selezionato";
            ddlMittente.SelectedValue = "Nessun Mittente Selezionato";
            ddlViaggi.SelectedValue = "Nessun Viaggio Selezionato";

        }

        protected void FiltraNonConsegnati(object sender, EventArgs e)
        {
            List<Pacco> PacchiFiltrati;
            PacchiFiltrati = new List<Pacco>();
            foreach (Pacco p in (List<Pacco>)Session["ListaPacchi"])
            {
                if (p.IdViaggio != null)
                {
                    if(DateTime.Now < Convert.ToDateTime(p.Data).Date)
                        PacchiFiltrati.Add(p);
                }
                //gvPacchi.Columns[6].Visible = false;
                gvPacchi.DataSource = PacchiFiltrati;
                gvPacchi.DataBind();
            }
        }

        protected void FiltraNonProgrammati(object sender, EventArgs e)
        {
            List<Pacco> PacchiFiltrati;
            PacchiFiltrati = new List<Pacco>();
            foreach (Pacco p in (List<Pacco>)Session["ListaPacchi"])
            {
                if (p.IdViaggio == null)
                {
                    PacchiFiltrati.Add(p);
                }
                //gvPacchi.Columns[6].Visible = false;
                gvPacchi.DataSource = PacchiFiltrati;
                gvPacchi.DataBind();
            }
        }

        protected void AggiungiPacco(object sender, EventArgs e)
        {
            if (ddlViaggi.SelectedValue == "Nessun Viaggio Selezionato")
            {
                string link = "aggiungiPacco.aspx?idViaggio=NULL";
                Response.Redirect(link);
            }
            else
            {
                string viaggio = ddlViaggi.SelectedValue;
                string[] partiViaggio = viaggio.Split('-');
                int? idViaggio = Convert.ToInt32(partiViaggio[0]);
                string link = "aggiungiPacco.aspx?idViaggio=" + idViaggio;
                Response.Redirect(link);
            }
        }

        protected void ProgrammaPacco(object sender, EventArgs e)
        {
            Response.Redirect("programmaPacco.aspx");
        }
    }
}