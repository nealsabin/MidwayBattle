using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class Provisions : GameItem
    {
        //public int Value { get; set; }

        public Provisions(int id, string name, string description, int experiencePoints, int value)
            : base(id, name, description, experiencePoints, value)
        {
            //Value = value;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}. Value: {Value}";
        }
    }
        
}
