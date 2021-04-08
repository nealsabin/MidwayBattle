using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class Citizen : Npc, ISpeak
    {
        Random r = new Random();

        public List<string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Citizen()
        {

        }

        public Citizen(
            int id, 
            string name, 
            HomeCountry country, 
            string description,
            int health,
            int lives,
            List<string> messages)
            : base(id, name, country, description, health, lives)
        {
            Messages = messages;
        }

        //generate message or use default
        public string Speak()
        {
            if(this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        //randomly select message from the list of messages
        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
