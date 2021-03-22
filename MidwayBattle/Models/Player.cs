using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _weapons;
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
        #endregion

        public Player()
        {
            _locationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItem>();
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        #region Methods
        /// <summary>
        /// udpate game item category list
        /// </summary>
        public void UpdateInventoryCategories()
        {
            Weapons.Clear();

            foreach (var gameItem in _inventory)
            {    
                if (gameItem is Weapon) Weapons.Add(gameItem);
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

        #endregion


    }

}
