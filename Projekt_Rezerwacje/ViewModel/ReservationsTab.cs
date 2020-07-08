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
        public Hotel SelectedHotel { get; set; }
        public static List<string> Packages { get; } = new List<string> { "premium", "standard", "all inclusive" };
        public string CurrentPackage { set; get; }
        public string SearchedClient { set; get; }
        public Client SelectedClient { get; set; }
        public Room SelectedRoom { get; set; }
        public Room SelectedReservation { get; set; }

        public ReservationsTab(Model model)
        {
            this.model = model;
            ListOfClients = model.SearchedClients;
            ListOfHotels = HotelRepository.GetHotels();
            ListOfReservations = model.Reservations;
            ListOfRooms = model.Rooms;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                onPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                onPropertyChanged(nameof(EndDate));
            }
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
                        arg => { model.GetRooms(SelectedHotel.ID, CurrentPackage); },
                        arg => SelectedHotel != null && CurrentPackage != null
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
                        arg => { model.GetReservations((int)SelectedRoom.ID); },
                        arg => SelectedRoom != null
                     );
                }
                return _getReservations;
            }
        }

        private ICommand _addReservation = null;
        public ICommand AddReservation
        {
            get
            {
                if (_addReservation == null)
                {
                    _addReservation = new RelayCommand(
                        arg =>
                        {
                            var reservation = new Reservation("F", "F", SelectedClient, StartDate, EndDate);

                            if (model.AddReservation(reservation, (int)SelectedRoom.ID))
                            {
                                System.Windows.MessageBox.Show($"Pomyślnie dodano rezerwację do bazy!");
                                //ClearClient();
                            }
                            else
                                System.Windows.MessageBox.Show($"Rezerwacja jest już w bazie!");
                        },
                        arg => SelectedClient != null && SelectedRoom != null
                     );
                }
                return _addReservation;
            }
        }
    }
}
