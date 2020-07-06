﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Projekt_Rezerwacje.Model;

namespace Projekt_Rezerwacje.DAL
{
    class DBConnection
    {
        MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder();

        private static string ALL_HOTELS_QUERY = "SELECT * FROM hotele";
        private static string ALL_CLIENTS_QUERY = "SELECT * FROM klienci";

        public DBConnection()
        {
            connStrBuilder.UserID = Properties.Settings.Default.userID;
            connStrBuilder.Server = Properties.Settings.Default.server;
            connStrBuilder.Database = Properties.Settings.Default.database;
            connStrBuilder.Port = Properties.Settings.Default.port;
            connStrBuilder.Password = Properties.Settings.Default.paswd;
        }

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(connStrBuilder.ToString());

    }
}
