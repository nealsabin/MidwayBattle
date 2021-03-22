using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExperiencePoints { get; set; }
        public string UseMessage { get; set; }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }
        public GameItem(int id, string name, string description, int experiencePoints, string useMessage = "")
        {
            Id = id;
            Name = name;
            Description = description;
            ExperiencePoints = experiencePoints;
            UseMessage = useMessage;
        }


        public virtual string InformationString()
        {
            return $"{Name}: {Description}";
        }
    }
}
