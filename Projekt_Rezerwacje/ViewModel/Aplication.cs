using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Rezerwacje.ViewModel
{
    using Model;
    using DAL.Entities;
    using System.Collections.ObjectModel;

    class Aplication
    {
        private Model model = new Model();

        public List<Hotel> ListOfHotels { get; set; }
        public ObservableCollection<Client> ListOfClients { get; set; }
        public Hotel PickedHotel { get; set; }
        public static List<string> Packages { get; } = new List<string> { "premium", "standard", "all inclusive" };
        public string CurrentPackage { set; get; }

        public Aplication()
        {
            ListOfClients = model.Clients;
            ListOfHotels = model.Hotels;
        }
    }
}
