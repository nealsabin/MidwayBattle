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
                ExperiencePoints = 0
                ,
                //Inventory = new ObservableCollection<GameItem>()
                //{
                //    GameItemById(10)
                //},
                Missions = new ObservableCollection<Mission>()
                {
                    MissionById(1),
                    MissionById(2),
                    MissionById(3)
                }
            };
        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }
        private static Location LocationById(int id)
        {
            List<Location> locations = new List<Location>();

            foreach (Location location in GameMap().MapLocations)
            {
                if (location != null) locations.Add(location);
            }

            return locations.FirstOrDefault(i => i.Id == id);
        }
        private static Mission MissionById(int id)
        {
            return Missions().FirstOrDefault(m => m.Id == id);
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
                    GameItemById(10),
                    GameItemById(20)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3003),
                    NpcById(4001),
                }
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 2,
                Name = "Northeast Quadrant",
                Description = "This is a description for the Northeast Quadrant.",
                Accessible = true,
                Message = "Be advised, enemy planes have been in this quadrant.",
                ModifyExperiencePoints = 5,
                GameItems = new ObservableCollection<GameItem>()
                {
                    GameItemById(12)
                },
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
                    GameItemById(11),
                    GameItemById(21)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3002)
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
                    GameItemById(22)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(3001),
                    NpcById(4002)
                }
            };
            return gameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(10, "16 inch shell", 30, "Main armament of the battleship",15, 1),
                new Weapon(11, "5 inch shell", 15, "Secondary armament of the battleship",5, 1),
                new Weapon(12, "Mark 14 torpedo",40,"The standard United States Navy torpedo.",20, 1),
                new Provisions(20, "Fuel","20 barrels of fuel", 5, 20),
                new Provisions(21, "Ship Repair Kit","Use this kit to repair your ship if your ship is damaged",5, 10),
                new Provisions(22, "Crew member resupply", "Transport with additional crew. Use of item gives one additional life.", 15, 1),
            };
        }
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Enemy()
                {
                    Id = 3001,
                    Name = "Aircraft Carrier",
                    Country = Character.HomeCountry.Japan,
                    Description = "Largest aircraft carrier in the Japanese fleet. Engage with caution.",
                    Messages = new List<string>()
                    {
                        "You will be destroyed.",
                        "Prepare for battle"
                    },
                    Health = 100,
                    Lives = 3,
                    CurrentWeapon = GameItemById(10) as Weapon
                },
                new Enemy()
                {
                    Id = 3002,
                    Name = "Destroyer",
                    Country = Character.HomeCountry.Japan,
                    Description = "Japanese destroyer with impressive armament.",
                    Messages = new List<string>()
                    {
                        "You are out gunned, you don't stand a chance.",
                        "The end is near."
                    },
                    Health = 100,
                    Lives = 3,
                    CurrentWeapon = GameItemById(11) as Weapon
                },
                new Enemy()
                {
                    Id = 3003,
                    Name = "Submarine",
                    Country = Character.HomeCountry.Japan,
                    Description = "Japanese I-400 class submarine with nuclear ballistic missiles.",
                    Messages = new List<string>()
                    {
                        "This is the largest submarine in the world, you don't stand a chance.",
                        "The end is near."
                    },
                    Health = 100,
                    Lives = 3,
                    CurrentWeapon = GameItemById(11) as Weapon
                },
                new Citizen()
                {
                    Id = 4001,
                    Name = "Endurance",
                    Country = Character.HomeCountry.USA,
                    Description = "American cargo ship containing provisions.",
                    Health = 100,
                    Lives = 3,
                    Messages = new List<string>()
                    {
                        "This ship is American. DO NOT FIRE."
                    }
                },
                new Citizen()
                {
                    Id = 4002,
                    Name = "Wasen",
                    Country = Character.HomeCountry.Japan,
                    Description = "Japanese cargo ship containing provisions.",
                    Health = 100,
                    Lives = 3,
                    Messages = new List<string>()
                    {
                        "This is not a war ship. DO NOT FIRE."
                    }
                }
            };
        }

        public static List<Mission> Missions()
        {
            return new List<Mission>()
            {
                new MissionTravel()
                {
                    Id = 1,
                    Name = "Scout Area",
                    Description = "Navigate to all locations within the map.",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredLocations = new List<Location>()
                    {
                        LocationById(1),
                        LocationById(2),
                        LocationById(3),
                        LocationById(4)
                    },
                    ExperiencePoints = 20
                },
                new MissionGather()
                {
                    Id = 2,
                    Name = "Collect All Items",
                    Description = "Find and collect all items on map.",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredGameItems = new List<GameItem>()
                    {
                        GameItemById(10),
                        GameItemById(11),
                        GameItemById(12),
                    },
                    ExperiencePoints = 50
                },
                new MissionEngage()
                {
                    Id = 3,
                    Name = "Speak To",
                    Description = "Find and speak to all ships.",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredNpcs = new List<Npc>()
                    {
                        NpcById(3001),
                        NpcById(3002),
                        NpcById(3003),
                        NpcById(4001),
                        NpcById(4002)
                    },
                    ExperiencePoints = 75
                },
            };
        }
    }
}
