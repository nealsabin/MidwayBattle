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
        #endregion

    }



}
