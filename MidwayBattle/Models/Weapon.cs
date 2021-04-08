using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class Weapon : GameItem
    {
        public int Damage { get; set; }

        public Weapon(int id, string name, int damage, string description, int experiencePoints, int value)
            : base(id, name, description, experiencePoints, value)
        {
            Damage = damage;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}. Damage: {Damage}";
        }
    }
}
