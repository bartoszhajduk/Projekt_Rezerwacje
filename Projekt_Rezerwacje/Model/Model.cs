using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Projekt_Rezerwacje.Model
{
    using DAL.Entities;
    using DAL.Repositories;

    class Model
    {
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public string SearchedClient { get; set; }

        public Model()
        {
            var clients = ClientRepository.GetClients();
            foreach (var c in clients)
                Clients.Add(c);
        }

        public void SearchForClient(string SearchedClient)
        {
            Clients.Clear();
            var clients = ClientRepository.SearchClient(SearchedClient);
            foreach (var c in clients)
                Clients.Add(c);
        }

        public bool IsClientInDataBase(Client client) => Clients.Contains(client);

        public bool AddClient(Client client)
        {
            
            if (!IsClientInDataBase(client))
            {
                if (ClientRepository.AddClient(client))
                {
                    Clients.Add(client);
                    return true;
                }
            }
            
            return false;    
        }

        /*private Telefon ZnajdzTelefonPoId(sbyte id)
        {
            foreach (var t in Telefony)
            {
                if (t.Id == id)
                    return t;
            }
            return null;
        }

        private Osoba ZnajdzOsobePoId(sbyte id)
        {
            foreach (var o in Osoby)
            {
                if (o.Id == id)
                    return o;
            }
            return null;
        }

        public ObservableCollection<Telefon> PobierzTelefonyOsoby(Osoba osoba)
        {
            var telefony = new ObservableCollection<Telefon>();
            foreach (var posiada in Posiadanie)
            {
                if (posiada.IdOsoby == osoba.Id)
                {
                    telefony.Add(ZnajdzTelefonPoId(posiada.IdTelefonu));
                }
            }

            return telefony;
        }

        public ObservableCollection<Osoba> PobierzWlascicieliTelefonu(Telefon telefon)
        {
            var osoby = new ObservableCollection<Osoba>();
            foreach (var posiada in Posiadanie)
            {
                if (posiada.IdTelefonu == telefon.Id)
                {
                    osoby.Add(ZnajdzOsobePoId(posiada.IdOsoby));
                }
            }

            return osoby;
        }

    


    

        public bool EdytujOsobeWBazie(Osoba osoba, sbyte idOsoby)
        {
            if (RepozytoriumOsoby.EdytujOsobeWBazie(osoba, idOsoby))
            {
                for (int i = 0; i < Osoby.Count; i++)
                {
                    if (Osoby[i].Id == idOsoby)
                    {
                        osoba.Id = idOsoby;
                        Osoby[i] = new Osoba(osoba);
                    }
                }
                return true;
            }
            return false;
        }*/

    }
}
