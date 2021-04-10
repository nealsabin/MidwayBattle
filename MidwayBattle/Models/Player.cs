using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MidwayBattle.Models
{
    public class Player : Character, IBattle
    {
        #region Enums
        public enum PositionTitle { Captain, Commander, LieutenantCommander}
        #endregion

        #region Fields
        //private int _lives;
        //private int _health;
        private int _experiencePoints;
        private Weapon _currentWeapon;
        private BattleModeName _battleMode;
        private PositionTitle _title;
        private List<Location> _locationsVisited;
        private List<Npc> _npcsEngaged;

        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _weapons;
        private ObservableCollection<GameItem> _provisions;
        private ObservableCollection<Mission> _missions;
        #endregion


        #region Properties
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
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }
        public Weapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }
        public BattleModeName BattleMode
        {
            get { return _battleMode; }
            set { _battleMode = value; }
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
        public List<Npc> NpcsEngaged
        {
            get { return _npcsEngaged; }
            set { _npcsEngaged = value; }
        }
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }
        public ObservableCollection<GameItem> Provisions
        {
            get { return _provisions; }
            set { _provisions = value; }
        }
        public ObservableCollection<Mission> Missions
        {
            get { return _missions; }
            set { _missions = value; }
        }
        #endregion

        public Player()
        {
            _locationsVisited = new List<Location>();
            _npcsEngaged = new List<Npc>();
            _inventory = new ObservableCollection<GameItem>();
            _weapons = new ObservableCollection<GameItem>();
            _provisions = new ObservableCollection<GameItem>();
            _missions = new ObservableCollection<Mission>();
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        #region Methods
        public void UpdateMissionStatus()
        {
            //
            // Note: only loop through assigned missions and cast mission to proper child class
            //
            foreach (Mission mission in _missions.Where(m => m.Status == Mission.MissionStatus.Incomplete))
            {
                if (mission is MissionTravel)
                {
                    if (((MissionTravel)mission).LocationsNotCompleted(_locationsVisited).Count == 0)
                    {
                        mission.Status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.ExperiencePoints;
                    }
                }
                else if (mission is MissionGather)
                {
                    if (((MissionGather)mission).GameItemsNotCompleted(_inventory.ToList()).Count == 0)
                    {
                        mission.Status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.ExperiencePoints;
                    }
                }
                else if (mission is MissionEngage)
                {
                    if (((MissionEngage)mission).NpcsNotCompleted(_npcsEngaged).Count == 0)
                    {
                        mission.Status = Mission.MissionStatus.Complete;
                        ExperiencePoints += mission.ExperiencePoints;
                    }
                }
                else
                {
                    throw new Exception("Unknown Mission child class.");
                }
            }
        }

        /// <summary>
        /// udpate game item category list
        /// </summary>
        public void UpdateInventoryCategories()
        {
            Weapons.Clear();
            Provisions.Clear();

            foreach (var gameItem in _inventory)
            {    
                if (gameItem is Weapon) Weapons.Add(gameItem);
                if (gameItem is Provisions) Provisions.Add(gameItem);
            }
        }
        /// <summary>
        /// add selected item to inventory
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }
        /// <summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItem"></param>
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }

        public int Attack()
        {
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
        public int Defend()
        {
            int hitPoints = CurrentWeapon.Damage - 5;

            if(hitPoints >= 0 && hitPoints <= 100)
            {
                return hitPoints;
            }
            else if(hitPoints > 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }
        public int Retreat()
        {
            int hitPoints = CurrentWeapon.Damage - 10;

            if(hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        #endregion


    }

}
