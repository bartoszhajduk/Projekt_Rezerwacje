using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Rezerwacje.Model
{
    class Hotel
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Hotel(string ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
