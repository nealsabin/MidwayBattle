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
    }
}
