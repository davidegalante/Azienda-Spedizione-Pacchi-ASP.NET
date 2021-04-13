using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class DataAccess
    {
        public static List<Viaggio> getViaggi(string stringaDiConnessione)
        {
            List <Viaggio> listaViaggi = new List<Viaggio>();
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM viaggio INNER JOIN veicolo ON (viaggio.idVeicolo = veicolo.targa);";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // DataSet is used as DataSource for a Data Control (for example a Repeater)
                    foreach(DataRow dr in dt.Rows)
                    {
                        Veicolo veicolo = new Veicolo(dr["targa"].ToString(), dr["marca"].ToString(), dr["modello"].ToString(), (int)dr["capacitaMax"], (int)dr["pesoMax"]);
                        Viaggio viaggio = new Viaggio((int)dr["idViaggio"], veicolo, dr["data"].ToString(), dr["nomeCorriere"].ToString());
                        listaViaggi.Add(viaggio);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return listaViaggi;
        }

        public static List<Utente> getUtenti(string stringaDiConnessione)
        {
            List<Utente> listaUtenti = new List<Utente>();
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM utente;";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // DataSet is used as DataSource for a Data Control (for example a Repeater)
                    foreach (DataRow dr in dt.Rows)
                    {
                        Utente utente = new Utente(dr["username"].ToString(), dr["password"].ToString());
                        listaUtenti.Add(utente);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return listaUtenti;
        }

        public static List<Pacco> getPacchiPerViaggio(string stringaDiConnessione, Viaggio v)
        {
            List<Pacco> listaPacchi = new List<Pacco>();
            // Provide the query string with a parameter placeholder.
            string queryString = "select * from pacco " +
                "inner join viaggio on (viaggio.idViaggio = pacco.idViaggio)" +
                "where viaggio.idViaggio = '" + v.IdViaggio + "';";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // DataSet is used as DataSource for a Data Control (for example a Repeater)
                    foreach (DataRow dr in dt.Rows)
                    {
                        Cliente mittente = getCliente(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, (int)dr["idMittente"]);
                        Cliente destinatario = getCliente(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, (int)dr["idDestinatario"]);
                        Pacco pacco = new Pacco((int)dr["idPacco"], v, mittente, destinatario, (int)dr["numOrdineConsegna"], (int)dr["volume"]);
                        listaPacchi.Add(pacco);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return listaPacchi;
        }

        public static Cliente getCliente(string stringaDiConnessione, int idCliente)
        {
            Cliente cliente = new Cliente();
            // Provide the query string with a parameter placeholder.
            string queryString = "select * from cliente " +
                "where cliente.idCliente = '" + idCliente + "';";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // DataSet is used as DataSource for a Data Control (for example a Repeater)
                    foreach (DataRow dr in dt.Rows)
                    {
                        cliente = new Cliente((int)dr["idCliente"], dr["nome"].ToString(), dr["cognome"].ToString(), dr["indirizzo"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return cliente;
        }

        public static List<Cliente> getClienti(string stringaDiConnessione)
        {
            List<Cliente> listaClienti = new List<Cliente>();
            // Provide the query string with a parameter placeholder.
            string queryString = "select * from cliente;";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // DataSet is used as DataSource for a Data Control (for example a Repeater)
                    foreach (DataRow dr in dt.Rows)
                    {
                        Cliente cliente = new Cliente((int)dr["idCliente"], dr["nome"].ToString(), dr["cognome"].ToString(), dr["indirizzo"].ToString());
                        listaClienti.Add(cliente);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return listaClienti;
        }

        public static List<Veicolo> getVeicoli(string stringaDiConnessione)
        {
            List<Veicolo> listaVeicoli = new List<Veicolo>();
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM veicolo;";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // DataSet is used as DataSource for a Data Control (for example a Repeater)
                    foreach (DataRow dr in dt.Rows)
                    {
                        Veicolo veicolo = new Veicolo(dr["targa"].ToString(), dr["marca"].ToString(), dr["modello"].ToString(), (int)dr["capacitaMax"], (int)dr["pesoMax"]);
                        listaVeicoli.Add(veicolo);
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return listaVeicoli;
        }

        public static List<Pacco> getPacchi(string stringaDiConnessione)
        {
            List<Pacco> listaPacchi = new List<Pacco>();
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * FROM pacco left JOIN viaggio ON (pacco.idViaggio = viaggio.idViaggio)left JOIN veicolo ON (viaggio.idVeicolo = veicolo.targa);";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // DataSet is used as DataSource for a Data Control (for example a Repeater)
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!DBNull.Value.Equals(dr["idViaggio"]))
                        {
                        Veicolo veicolo = new Veicolo(dr["targa"].ToString(), dr["marca"].ToString(), dr["modello"].ToString(), (int)dr["capacitaMax"], (int)dr["pesoMax"]);
                        Cliente mittente = getCliente(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, (int)dr["idMittente"]);
                        Cliente destinatario = getCliente(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, (int)dr["idDestinatario"]);
                        Viaggio viaggio = new Viaggio((int?)dr["idViaggio"], veicolo, dr["data"].ToString(), dr["nomeCorriere"].ToString());
                        Pacco pacco = new Pacco((int)dr["idPacco"], viaggio, mittente, destinatario, (int)dr["numOrdineConsegna"], (int)dr["volume"]);
                        listaPacchi.Add(pacco);
                        }
                        else
                        {
                            Veicolo veicolo = new Veicolo("null", "null", "null", 0, 0);
                            Cliente mittente = getCliente(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, (int)dr["idMittente"]);
                            Cliente destinatario = getCliente(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSpedizioniMySQL"].ConnectionString, (int)dr["idDestinatario"]);
                            Viaggio viaggio = new Viaggio(null, veicolo, "null", "null");
                            Pacco pacco = new Pacco((int)dr["idPacco"], viaggio, mittente, destinatario, (int)dr["numOrdineConsegna"], (int)dr["volume"]);
                            listaPacchi.Add(pacco);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
            return listaPacchi;
        }

        public static void inserisciPacco(string stringaDiConnessione, int? idViaggio, int idMittente, int idDestinatario, int volume, int nOrdine)
        {
            string queryString = "";
            if (idViaggio.HasValue)
            {
                queryString = "INSERT INTO pacco (idPacco, idViaggio, idMittente, idDestinatario, volume, numOrdineConsegna) " +
                "VALUES (NULL, '" + idViaggio + "','" + idMittente + "','" + idDestinatario + "','" + volume + "' , '" + nOrdine + "');";
            }
            else
            {
                queryString = "INSERT INTO pacco (idPacco, idViaggio, idMittente, idDestinatario, volume, numOrdineConsegna) " +
                "VALUES (NULL, NULL ,'" + idMittente + "','" + idDestinatario + "','" + volume + "' , '" + nOrdine + "');";
            }
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }

        public static void ModificaPacco(string stringaDiConnessione, int idPacco, int idViaggio)
        {
            
          string queryString = "UPDATE pacco SET pacco.idViaggio = '" + idViaggio + "' where pacco.idPacco = '" + idPacco + "';";
           
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }

        public static void inserisciCliente(string stringaDiConnessione, string nome, string cognome, string indirizzo)
        {
            // Provide the query string with a parameter placeholder.
            string queryString = "INSERT INTO cliente (idCliente, nome, cognome, indirizzo) " +
                "VALUES (NULL, '" + nome + "','" + cognome + "','" + indirizzo + "');";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }

        public static void inserisciVeicolo(string stringaDiConnessione, string targa, string marca, string modello, int capMax, int pesoMax)
        {
            // Provide the query string with a parameter placeholder.
            string queryString = "INSERT INTO veicolo (targa, marca, modello, capacitaMax, pesoMax) " +
                "VALUES ('" + targa + "','" + marca + "','" + modello + "','" + capMax + "','" + pesoMax + "');";
            string messaggio = "";
            // Specify the parameter value.
            // Create and open the connection in a using block.
            using (MySqlConnection connection = new MySqlConnection(stringaDiConnessione))
            {
                // Create the Command and Parameter objects.
                MySqlCommand command = new MySqlCommand(queryString, connection);
                // Open the connection in a try/catch block. Use a DataAdapter to Fill a DataSet Object
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    messaggio = ex.Message;
                }
            }
        }
    }
}
