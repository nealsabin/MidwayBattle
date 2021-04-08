using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    //public class Enemy : Character, Npc, ISpeak, IBattle
    public class Enemy : Npc, ISpeak, IBattle
    {
        Random r = new Random();

        //private int _lives;
        //private int _health;

        public List<string> Messages { get; set; }
        public BattleModeName BattleMode {get; set;}
        public Weapon CurrentWeapons { get; set; }
        public Weapon CurrentWeapon { get; set; }

        //public int Lives
        //{
        //    get { return _lives; }
        //    set { _lives = value; }
        //}
        //public int Health
        //{
        //    get { return _health; }
        //    set { _health = value; }
        //}

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Enemy()
        {

        }

        public Enemy(
            int id,
            string name,
            HomeCountry country,
            string description,
            int health,
            int lives,
            List<string> messages,
            Weapon currentWeapons,
            Weapon currentWeapon)
            : base(id, name, country, description, health, lives)
        {
            Messages = messages;
            CurrentWeapon = currentWeapon;
            CurrentWeapon = currentWeapons;
        }

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

        private string GetMessage()
        {
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        //Attack
        public int Attack()
        {
            //edit to randomize a bit
            int hitPoints = CurrentWeapon.Damage;

            if(hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        //Defend
        public int Defend()
        {
            int hitPoints = 20;

            if (hitPoints >= 0 && hitPoints <= 100)
            {
                return hitPoints;
            }
            else if (hitPoints > 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        //Retreat
        public int Retreat()
        {
            int hitPoints = 5;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }
    }
}
