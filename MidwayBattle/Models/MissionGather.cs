using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayBattle.Models
{
    public class MissionGather : Mission
    {
        private int _id;
        private string _name;
        private string _description;
        private MissionStatus _status;
        private string _statusDetail;
        private int _experiencePoints;
        private List<GameItem> _requiredGameItems;

        public List<GameItem> RequiredGameItems
        {
            get { return _requiredGameItems; }
            set { _requiredGameItems = value; }
        }

        public MissionGather()
        {

        }

        public MissionGather(int id, string name, MissionStatus status, List<GameItem> requiredGameItems)
            : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredGameItems = requiredGameItems;
        }

        public List<GameItem> GameItemsNotCompleted(List<GameItem> inventory)
        {
            List<GameItem> gameItemsToComplete = new List<GameItem>();

            foreach (var missionGameItem in _requiredGameItems)
            {
                GameItem inventoryItemMatch = inventory.FirstOrDefault(gi => gi.Id == missionGameItem.Id);
                if (inventoryItemMatch == null)
                {
                    gameItemsToComplete.Add(missionGameItem);
                }
                else
                {
                    if (inventoryItemMatch == missionGameItem)
                    {
                        gameItemsToComplete.Add(missionGameItem);
                    }
                }
            }

            return gameItemsToComplete;
        }
    }
}
