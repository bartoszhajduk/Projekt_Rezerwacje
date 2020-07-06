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


        public Model()
        {
            var clients = ClientRepository.GetClients();
            foreach (var c in clients)
                Clients.Add(c);
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

        public bool CzyOsobaJestJuzWRepozytorium(Osoba osoba) => Osoby.Contains(osoba);


        public bool DodajOsobeDoBazy(Osoba osoba)
        {
            if (!CzyOsobaJestJuzWRepozytorium(osoba))
            {
                if (RepozytoriumOsoby.DodajOsobeDoBazy(osoba))
                {
                    Osoby.Add(osoba);
                    return true;
                }
            }
            return false;
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
