using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidwayBattle.Models;

namespace MidwayBattle.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Bobby",
                Age = 49,
                Title = Player.PositionTitle.Commander,
                Country = Character.HomeCountry.USA,
                Health = 100,
                Lives = 3,
                ExperiencePoints = 0,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(10)
                }
            };
        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }



        public static Enemy EnemyData()
        {
            return new Enemy()
            {
                Health = 100,
                Lives = 3
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
               "Enemy ship has been spotted! Send out a scout to locate the enemy vessel."
            };
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 2;
            int columns = 2;

            Map gameMap = new Map(rows, columns);

            gameMap.StandardGameItems = StandardGameItems();

            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 1,
                Name = "Northwest Quadrant",
                Description = "This is a description for the Northwest Quadrant.",
                Accessible = true,
                Message = "Be advised, enemy submarines have been in this quadrant.",
                ModifyExperiencePoints = 5,
                GameItems = new ObservableCollection<GameItem>()
                {
                    GameItemById(20)
                }
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 2,
                Name = "Northeast Quadrant",
                Description = "This is a description for the Northeast Quadrant.",
                Accessible = true,
                Message = "Be advised, enemy planes have been in this quadrant.",
                ModifyExperiencePoints = 5
            };
            gameMap.MapLocations[1, 0] = new Location()
            {
                Id = 3,
                Name = "Southwest Quadrant",
                Description = "This is a description for the Southwest Quadrant.",
                Accessible = true,
                Message = "Be advised, enemy battle ships have been in this quadrant.",
                ModifyExperiencePoints = 10,
                GameItems = new ObservableCollection<GameItem>()
                {
                    GameItemById(11)
                }
            };
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 4,
                Name = "Southeast Quadrant",
                Description = "This is a description for the Southeast Quadrant.",
                Accessible = true,
                Message = "Be advised, enemy carriers have been in this quadrant.",
                ModifyExperiencePoints = 5,
                GameItems = new ObservableCollection<GameItem>()
                {
                    GameItemById(10),
                    GameItemById(21)
                }
            };
            return gameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(10, "16 inch shell", 40, "Main armament of the battleship",15),
                new Weapon(11, "5 inch shell", 15, "Secondary armament of the battleship",5),
                new Weapon(12, "TEST",25,"TEST",50),
                new Provisions(20, "Fuel", 20, "20 barrels of fuel", 5),
                new Provisions(21, "Ship Repair Kit",10,"Use this kit to repair your ship if your ship is damaged",5)
            };
        }
    }
}
