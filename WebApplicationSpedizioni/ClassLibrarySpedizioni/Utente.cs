﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySpedizioni
{
    public class Utente
    {
        private string username;
        private string password;

        public Utente(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; }
        public string Password { get => password; }
    }
}
