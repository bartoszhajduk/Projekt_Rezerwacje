using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Rezerwacje.DAL.Repositories
{
    using DAL.Entities;

    class ReservationRepository
    {
        public static List<Reservation> GetReservations(int id_p)
        {
            string ALL_RESERVATIONS = "SELECT * FROM rezerwacje, klienci, pokoje_rezerwacje  " +
                $"WHERE rezerwacje.id_k = klienci.id_k AND rezerwacje.id_r = pokoje_rezerwacje.id_r AND pokoje_rezerwacje.id_p = {id_p}";

            List<Reservation> clients = new List<Reservation>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_RESERVATIONS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    clients.Add(new Reservation(reader));
                connection.Close();
            }
            return clients;
        }
    }
}
