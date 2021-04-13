using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class Viaggio
    {
        int? idViaggio;
        Veicolo veicolo;
        string data;
        string nomeCorriere;

        public Viaggio(int? idViaggio, Veicolo veicolo, string data, string nomeCorriere)
        {
            this.idViaggio = idViaggio;
            this.veicolo = veicolo;
            this.data = data;
            this.nomeCorriere = nomeCorriere;
        }

        public int? IdViaggio { get => idViaggio; set => idViaggio = value; }
        public Veicolo Veicolo { get => veicolo; set => veicolo = value; }
        public string Data { get => data; set => data = value; }
        public string NomeCorriere { get => nomeCorriere; set => nomeCorriere = value; }
        public string Targa { get => veicolo.Targa; }
    }
}
