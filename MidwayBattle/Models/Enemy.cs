using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class Enemy : Character
    {

        private int _lives;
        private int _health;

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }
}
