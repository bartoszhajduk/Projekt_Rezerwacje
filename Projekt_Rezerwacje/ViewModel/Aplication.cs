using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Rezerwacje.ViewModel
{
    using Model;
    using Model.DAL;
    using System.Collections.ObjectModel;

    class Aplication
    {
        private DataAccess dataAccess;

        public List<Hotel> ListOfHotels { get { return dataAccess.AllHotels(); } }
        public ObservableCollection<Client> ListOfClients { get { return dataAccess.AllClients(); } } 
        public Hotel PickedHotel { get; set; }
        public static List<string> Packages { get; } = new List<string> { "premium", "standard", "all inclusive" };
        public string CurrentPackage { set; get; }

        public Aplication()
        {
            dataAccess = new DataAccess();
        }
    }
}
