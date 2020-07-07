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
        public ObservableCollection<Client> SearchedClients { get; set; } = new ObservableCollection<Client>();
        public string SearchedClient { get; set; }

        public Model()
        {
            var clients = ClientRepository.GetClients();
            foreach (var c in clients)
            {
                Clients.Add(c);
                SearchedClients.Add(c);
            }
        }

        public void SearchForClient(string SearchedClient)
        {
            SearchedClients.Clear();
            var clients = ClientRepository.SearchClient(SearchedClient);
            foreach (var c in clients)
                SearchedClients.Add(c);
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

        public bool EditClient(Client client, int clientID)
        {
            if (ClientRepository.EditClient(client, clientID))
            {
                for (int i = 0; i < Clients.Count; i++)
                {
                    if (Clients[i].ID == clientID)
                    {
                        client.ID = clientID;
                        Clients[i] = new Client(client);
                    }
                }
                return true;
            }
            return false;
        }

        internal bool DeleteClient(Client client, int clientID)
        {
            if (IsClientInDataBase(client))
            {
                if (ClientRepository.DeleteClient(clientID))
                {
                    Clients.Remove(client);
                    return true;
                }
            }
            return false;
        }
    }
}
