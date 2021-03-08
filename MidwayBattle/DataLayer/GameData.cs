using System;
using System.Collections.Generic;
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
                ExperiencePoints = 0

            };
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

            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 1,
                Name = "Northwest Quadrant",
                Description = "This is a description for the Northwest Quadrant.",
                Accessible = true,
                Message = "Be advised, enemy submarines have been in this quadrant.",
                ModifyExperiencePoints = 5
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
                ModifyExperiencePoints = 10
            };
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 4,
                Name = "Southeast Quadrant",
                Description = "This is a description for the Southeast Quadrant.",
                Accessible = true,
                Message = "Be advised, enemy carriers have been in this quadrant.",
                ModifyExperiencePoints = 5
            };
            return gameMap;
        }
    }
}
