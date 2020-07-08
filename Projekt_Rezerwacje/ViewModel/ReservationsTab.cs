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
    using System.Windows;

    class ReservationsTab : ViewModelBase
    {
        private Model model = null;

        public List<Hotel> ListOfHotels { get; set; }
        public ObservableCollection<Reservation> ListOfReservations { get; set; }
        public ObservableCollection<Client> ListOfClients { get; set; }
        public ObservableCollection<Room> ListOfRooms { get; set; }
        public Hotel PickedHotel { get; set; }
        public static List<string> Packages { get; } = new List<string> { "premium", "standard", "all inclusive" };
        public string CurrentPackage { set; get; }
        public string SearchedClient { set; get; }
        public Client PickedClient { get; set; }
        public Room PickedRoom { get; set; }

        public ReservationsTab(Model model)
        {
            this.model = model;
            ListOfClients = model.SearchedClients;
            ListOfHotels = HotelRepository.GetHotels();
            ListOfReservations = model.Reservations;
            ListOfRooms = model.Rooms;
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

        private ICommand _getRooms = null;
        public ICommand GetRooms
        {
            get
            {
                if (_getRooms == null)
                {
                    _getRooms = new RelayCommand(
                        arg => { model.GetRooms(PickedHotel.ID, CurrentPackage); },
                        arg => PickedHotel != null && CurrentPackage != null
                     );
                }
                return _getRooms;
            }
        }

        private ICommand _getReservations = null;
        public ICommand GetReservations
        {
            get
            {
                if (_getReservations == null)
                {
                    _getReservations = new RelayCommand(
                        arg => { model.GetReservations((int)PickedRoom.ID); },
                        arg => PickedRoom != null
                     );
                }
                return _getReservations;
            }
        }
    }
}
