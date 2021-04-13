using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class Pacco
    {
        private int idPacco;
        private Viaggio viaggio;
        private Cliente mittente;
        private Cliente destinatario;
        private int nOrdineConsegna;
        private int volume;
        private string dataConsegna;

        public Pacco(int idPacco, Viaggio viaggio, Cliente mittente, Cliente destinatario, int nOrdineConsegna, int volume)
        {
            this.idPacco = idPacco;
            this.viaggio = viaggio;
            this.mittente = mittente;
            this.destinatario = destinatario;
            this.nOrdineConsegna = nOrdineConsegna;
            this.volume = volume;
            if (viaggio.IdViaggio != null)
            {
                this.dataConsegna = Convert.ToDateTime(viaggio.Data).AddMinutes(30*nOrdineConsegna).ToString();
            }
            else
            {
                this.dataConsegna = "Data Non Disponibile";
            }
        }

        public int IdPacco { get => idPacco; set => idPacco = value; }
        public Cliente Mittente { get => mittente; set => mittente = value; }
        public Cliente Destinatario { get => destinatario; set => destinatario = value; }
        public int NOrdineConsegna { get => nOrdineConsegna; set => nOrdineConsegna = value; }
        public int Volume { get => volume; set => volume = value; }
        public Viaggio Viaggio { get => viaggio; set => viaggio = value; }
        public string NomeMittente { get => mittente.Nome; }
        public string CognomeMittente { get => mittente.Cognome; }

        public string NomeCompletoMittente { get => NomeMittente + " " + CognomeMittente; }
        public string NomeDestinatario { get => destinatario.Nome; }
        public string CognomeDestinatario { get => destinatario.Cognome; }

        public string NomeCompletoDestinatario { get => NomeDestinatario + " " + CognomeDestinatario; }
        public int? IdViaggio { get => viaggio.IdViaggio; }

        public string Data {  get => dataConsegna; }
        public string Orario { get => Convert.ToDateTime(dataConsegna).ToString("HH:mm:ss"); }
    }
}