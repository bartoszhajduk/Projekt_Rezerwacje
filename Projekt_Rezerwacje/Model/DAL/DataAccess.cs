using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Rezerwacje.Model.DAL
{
    class DataAccess
    {
        MySqlConnectionStringBuilder connStrBuilder;
        MySqlConnection connection;

        private static string ALL_HOTELS_QUERY = "SELECT * FROM hotele";
        private static string ALL_CLIENTS_QUERY = "SELECT * FROM klienci";

        public DataAccess()
        {
            connStrBuilder = new MySqlConnectionStringBuilder();
            connStrBuilder.UserID = "recepcjonista";
            connStrBuilder.Password = "haslo.123";
            connStrBuilder.Server = "localhost";
            connStrBuilder.Database = "hotel";
            connStrBuilder.Port = 3306;
        }

        public List<Hotel> AllHotels()
        {
            List<Hotel> HotelList = new List<Hotel>();

            using (connection = new MySqlConnection(connStrBuilder.ToString()))
            {
                MySqlCommand command = new MySqlCommand(ALL_HOTELS_QUERY, connection);
                connection.Open();
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        HotelList.Add(new Hotel(dataReader["id_h"].ToString(), dataReader["nazwa"].ToString()));
                    }
                }
                else
                {
                    Console.WriteLine("Brak wyników zapytania");
                }
                connection.Close();

            }

            return HotelList;
        }

        public ObservableCollection<Client> AllClients()
        {
            List<Client> ClientList = new List<Client>();

            using (connection = new MySqlConnection(connStrBuilder.ToString()))
            {
                MySqlCommand command = new MySqlCommand(ALL_CLIENTS_QUERY, connection);
                connection.Open();
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ClientList.Add(new Client(dataReader["id_k"].ToString(), dataReader["imię"].ToString(), dataReader["nazwisko"].ToString(), dataReader["telefon"].ToString()));
                    }
                }
                else
                {
                    Console.WriteLine("Brak wyników zapytania");
                }
                connection.Close();

            }
            return (new ObservableCollection<Client>(ClientList));
        }
    }
}
