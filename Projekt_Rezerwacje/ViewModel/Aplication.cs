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

    class Aplication : Changed
    { 
        private Model model = new Model();

        public List<Hotel> ListOfHotels { get; set; }
        public ObservableCollection<Client> ListOfClients { get; set; }
        public Hotel PickedHotel { get; set; }
        public static List<string> Packages { get; } = new List<string> { "premium", "standard", "all inclusive" };
        public string CurrentPackage { set; get; }
        public string SearchedClient { set; get; }
        public Client PickedClient { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                onPropertyChanged(nameof(Name));
            }
        }
        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                onPropertyChanged(nameof(LastName));
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                onPropertyChanged(nameof(Phone));
            }
        }

        public Aplication()
        {
            ListOfClients = model.Clients;
            ListOfHotels = HotelRepository.GetHotels();
        }

        public void ClearClient()
        {
            Name = "";
            LastName = "";
            Phone = "";
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

        private ICommand _addClient = null;
        public ICommand AddClient
        {
            get
            {
                if (_addClient == null)
                {
                    _addClient = new RelayCommand(
                        arg => 
                        {
                            var Client = new Client(Name, LastName, Phone);
                            
                            if (model.AddClient(Client))
                            {
                                ClearClient();
                                System.Windows.MessageBox.Show("Osoba została dodana do bazy!");
                            }
                        },
                        arg => (!(string.IsNullOrWhiteSpace(Name)) && !(string.IsNullOrWhiteSpace(LastName)) && !(string.IsNullOrWhiteSpace(Phone)))
                     );
                }
                return _addClient;
            }
        }



    }
}
