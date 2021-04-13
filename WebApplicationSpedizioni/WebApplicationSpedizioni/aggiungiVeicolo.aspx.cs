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
    public partial class aggiungiVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void TornaVeicoli(object sender, EventArgs e)
        {
            Response.Redirect("elencoVeicoli.aspx");
        }
        protected void InserisciVeicolo(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");
            if ((tbTarga.Text != "") && (tbMarca.Text != "") && (tbModello.Text != "") && (tbCapacitaMax.Text != "") && 
                (tbPesoMax.Text != "") && (regex.IsMatch(tbCapacitaMax.Text)) && (regex.IsMatch(tbPesoMax.Text)))
            {
                string targa = tbTarga.Text;
                string marca = tbMarca.Text;
                string modello = tbModello.Text;
                int capMax = Convert.ToInt32(tbCapacitaMax.Text);
                int pesoMax = Convert.ToInt32(tbPesoMax.Text);

                DataAccess.inserisciVeicolo(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString,
                    targa, marca, modello, capMax, pesoMax);
                Response.Redirect("elencoVeicoli.aspx");
            }
        }
    }
}