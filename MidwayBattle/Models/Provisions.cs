using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class Provisions : GameItem
    {
        public int Value { get; set; }
        public Provisions(int id, string name, int value, string description, int experiencePoints)
            : base(id, name, description, experiencePoints)
        {
            Value = Value;
        }
        public override string InformationString()
        {
            return $"{Name}: {Description}. Value: {Value}";
        }
    }
}
