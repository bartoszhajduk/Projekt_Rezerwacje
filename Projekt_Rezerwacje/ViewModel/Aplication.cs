using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Rezerwacje.ViewModel
{
    using Model;
    using DAL.Entities;
    using DAL.Repositories;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    class Aplication
    {
        private Model model = new Model();

        public List<Hotel> ListOfHotels { get; set; }
        public ObservableCollection<Client> ListOfClients { get; set; }
        public Hotel PickedHotel { get; set; }
        public static List<string> Packages { get; } = new List<string> { "premium", "standard", "all inclusive" };
        public string CurrentPackage { set; get; }
        public string SearchedClient { set; get; }
        public Client PickedClient { get; set; }

        public Aplication()
        {
            ListOfClients = model.Clients;
            ListOfHotels = HotelRepository.GetHotels();
        }

        private ICommand _searchClient = null;
        public ICommand SearchClient
        {
            get
            {
                if (_searchClient == null)
                {
                    _searchClient = new RelayCommand(
                        arg => { model.SearchForClient(SearchedClient); },
                        arg => true
                     );
                }
                return _searchClient;
            }

        }


    }
}
