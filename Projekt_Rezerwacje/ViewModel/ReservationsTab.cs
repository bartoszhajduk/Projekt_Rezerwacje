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

    class ReservationsTab : ViewModelBase
    {
        private Model model = null;

        public List<Hotel> ListOfHotels { get; set; }
        public ObservableCollection<Client> ListOfClients { get; set; }
        public Hotel PickedHotel { get; set; }
        public static List<string> Packages { get; } = new List<string> { "premium", "standard", "all inclusive" };
        public string CurrentPackage { set; get; }
        public string SearchedClient { set; get; }
        public Client PickedClient { get; set; }


        private ICommand _searchClient = null;

        public ReservationsTab(Model model)
        {
            this.model = model;
            ListOfClients = model.SearchedClients;
            ListOfHotels = HotelRepository.GetHotels();
        }

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
