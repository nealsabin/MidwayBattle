using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class Player : Character
    {
        #region Enums
        public enum PositionTitle { Captain, Commander, LieutenantCommander}
        #endregion

        #region Fields
        private int _lives;
        private int _health;
        private int _experiencePoints;
        private PositionTitle _title;
        private List<Location> _locationsVisited;
        #endregion


        #region Properties
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
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }
        public PositionTitle Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }
        public Player()
        {
            _locationsVisited = new List<Location>();
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }
        #endregion

    }

}
