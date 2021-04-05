using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public abstract class Npc : Character
    {
        public string Description { get; set; }

        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }
        }
        public Npc()
        {

        }

        public Npc(int id, string name, HomeCountry country, string description)
            : base(id, name, country)
        {
            Id = id;
            Name = name;
            Country = country;
            Description = description;
        }

        protected abstract string InformationText();
      
    }
}
