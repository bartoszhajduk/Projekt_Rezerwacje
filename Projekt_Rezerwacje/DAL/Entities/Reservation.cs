using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Rezerwacje.DAL.Entities
{
    class Reservation
    {

        public int? ID { set; get; }
        public string Discount { set; get; }
        public string Ended { set; get; }
        public Client Client { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }

        public Reservation(MySqlDataReader reader)
        {
            ID = int.Parse(reader["id_r"].ToString());
            Discount = reader["zniżka"].ToString();
            Ended = reader["zakończono"].ToString();
            StartDate = DateTime.Parse(reader["od"].ToString());
            EndDate = DateTime.Parse(reader["do"].ToString());
            Client = new Client(reader);
        }

        public override string ToString()
        {
            return $"{Client.Name} {Client.LastName} {Discount} {Ended} {StartDate.ToString("dd.MM.yyyy")} {EndDate.ToString("dd.MM.yyyy")}";
        }

        /*
        public Client(string name, string lastName, string phoneNumber)
        {
            ID = null;
            Name = name.Trim();
            LastName = lastName.Trim();
            PhoneNumber = phoneNumber;
        }

        public Client(Client client)
        {
            ID = client.ID;
            Name = client.Name;
            LastName = client.LastName;
            PhoneNumber = client.PhoneNumber;
        }


        public string ToInsert()
        {
            return $"('{Name}', '{LastName}', '{PhoneNumber}')";
        }

        public override bool Equals(object obj)
        {
            var client = obj as Client;
            if (client is null) return false;
            if (Name.ToLower() != client.Name.ToLower()) return false;
            if (LastName.ToLower() != client.LastName.ToLower()) return false;
            if (PhoneNumber != client.PhoneNumber) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }*/
    }
}
