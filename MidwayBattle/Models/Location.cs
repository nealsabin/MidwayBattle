using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MidwayBattle.PresentationLayer;

namespace MidwayBattle.Models
{
    public class Location : ObservableObject
    {
        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _modifyExperiencePoints;
        private string _message;
        private ObservableCollection<GameItem> _gameItems;
        private ObservableCollection<Npc> _npcs;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public int ModifyExperiencePoints
        {
            get { return _modifyExperiencePoints; }
            set { _modifyExperiencePoints = value; }
        }
        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }
        public ObservableCollection<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }
        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }

        //
        // Stopgap to force the list of items in the location to update
        //
        // todo Velis refactor using the CollectionChanged event
        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();

            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }

        /// <summary>
        /// add selected item to location
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Add(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        /// <summary>
        /// remove selected item from location
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }

            UpdateLocationGameItems();
        }
    }
}
