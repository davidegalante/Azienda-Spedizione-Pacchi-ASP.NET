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
    public partial class aggiungiPacco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<Cliente> listaClienti;
            listaClienti = DataAccess.getClienti(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString);
            if (!IsPostBack)
            {
                Session["url"] = Request.UrlReferrer.AbsoluteUri;
                ddlMittente.Items.Add(new ListItem(""));
                ddlDestinatario.Items.Add(new ListItem(""));
                foreach (Cliente c in listaClienti)
                {
                    string dettagliCliente = c.IdCliente + " - " + c.Nome + " " + c.Cognome + " , " + c.Indirizzo;
                    ddlMittente.Items.Add(new ListItem(dettagliCliente));
                    ddlDestinatario.Items.Add(new ListItem(dettagliCliente));
                }
            }
            int? idViaggio = Int32.TryParse(Request.QueryString["idViaggio"], out var valoreIntTemp) ? valoreIntTemp : (int?)null;
            if (!idViaggio.HasValue)
            {
                btnAggiungiCliente.Visible = false;
            }
        }

        protected void AggiungiPacco(object sender, EventArgs e)
        {
            lbError.Text = "";
            if ((tbVolume.Text != "") && (tbNumeroOrdineConsegna.Text != "") && (ddlMittente.SelectedValue != "") && (ddlDestinatario.SelectedValue != ""))
            {
                Regex regex = new Regex("^[0-9]+$");
                if (regex.IsMatch(tbVolume.Text) && regex.IsMatch(tbNumeroOrdineConsegna.Text))
                {
                    string[] stringaMittente = ddlMittente.SelectedValue.Split('-');
                    string[] stringaDestinatario = ddlDestinatario.SelectedValue.Split('-');
                    int idMittente = Convert.ToInt32(stringaMittente[0]);
                    int idDestinatario = Convert.ToInt32(stringaDestinatario[0]);
                    if (idMittente != idDestinatario)
                    {
                        int? idViaggio = Int32.TryParse(Request.QueryString["idViaggio"], out var valoreIntTemp) ? valoreIntTemp : (int?)null;
                        int volume = Convert.ToInt32(tbVolume.Text);
                        int nOrdineConsegna = Convert.ToInt32(tbNumeroOrdineConsegna.Text);
                        //tbVolume.Text = idViaggio.ToString();
                        DataAccess.inserisciPacco(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString,
                            idViaggio, idMittente, idDestinatario, volume, nOrdineConsegna);
                        svuotaCampi(Page.Controls);
                    }
                    else
                    {
                        lbError.Text = "Mittente e destinatario devono essere diversi!";
                    }   
                }
                else
                {
                    lbError.Text = "Inserisci solo valori validi!";
                }
            }
            else
            {
                lbError.Text = "Inserisci tutti i valori!";
            }
        }

        protected void svuotaCampi(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();
                svuotaCampi(ctrl.Controls);
            }
        }

        protected void TornaIndietro(object sender, EventArgs e)
        {
            object paginaPrecedente = Session["url"];
            Response.Redirect((string)paginaPrecedente);
        }

        protected void AggiungiCliente(object sender, EventArgs e)
        {
            string link = "aggiungiCliente.aspx?idViaggio=" + Request.QueryString["idViaggio"];
            Response.Redirect(link);
        }
    }
}