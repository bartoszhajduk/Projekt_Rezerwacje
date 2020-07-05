using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Rezerwacje.Model
{
    class Client
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string PhoneNumber { set; get; }

        public Client(string ID, string Name, string LastName, string PhoneNumber)
        {
            this.ID = ID;
            this.Name = Name;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
        }
        public override string ToString()
        {
            return $"{Name} {LastName} {PhoneNumber}";
        }
    }
}
